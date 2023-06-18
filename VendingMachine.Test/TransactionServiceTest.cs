using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

using VendingMachine.Application.Models;
using VendingMachine.Controllers;
using VendingMachine.Controllers.Models;
using VendingMachine.Domain;

namespace VendingMachine.Tests;

[TestFixture]
public class VendingMachineControllerTests
{
    private readonly Application.Models.VendingMachine _expectedVendingMachine = new();
    
    private readonly TransactionRequest _request = new (new Application.Models.VendingMachine(), 1, PaymentType.Cash);
    private readonly Application.Models.VendingMachine _updatedVendingMachine = new();

    private Mock<ITransactionService> _transactionServiceMock = null!;
    private ITransactionService _transactionService = null!;
    private VendingMachineController _vendingMachineController = null!;

    private const int ItemId = 1;
    private const PaymentType PaymentType = Application.Models.PaymentType.Cash;
    
    [SetUp]
    public void Setup()
    {
        // Create a mock for the ITransactionService interface
        _transactionServiceMock = new Mock<ITransactionService>();

        // Create an instance of the actual implementation of ITransactionService
        _transactionService = new TransactionServices();

        // Create an instance of the VendingMachineController and pass the mock object as a dependency
        _vendingMachineController = new VendingMachineController(_transactionServiceMock.Object);

        // Setup the behavior of the mocked InitializeVendingMachine method
        _transactionServiceMock.Setup(service => service.InitialiseVendingMachine())
                               .ReturnsAsync(_expectedVendingMachine);

        // Setup the behavior of the mocked PurchaseItem method
        _transactionServiceMock.Setup(service => service.PurchaseItem(_request.CurrentVendingMachine, _request.ItemId, _request.PaymentType))
                               .ReturnsAsync(_updatedVendingMachine);
    }

    [Test]
    public async Task GetInitialVendingMachine_ReturnsOkWithInitializedVendingMachine()
    {
        var result = await _vendingMachineController.GetInitialVendingMachine();

        result.Should().BeOfType<OkObjectResult>()
              .Which.Value.Should().BeSameAs(_expectedVendingMachine);
    }

    [Test]
    public async Task ItemTransaction_ReturnsOkWithUpdatedVendingMachine()
    {
        var result = await _vendingMachineController.ItemTransaction(_request);

        result.Should().BeOfType<OkObjectResult>()
              .Which.Value.Should().BeSameAs(_updatedVendingMachine);
    }
    
    [Test]
    public async Task InitialiseVendingMachine_ShouldInitializeVendingMachine()
    {
        var result = await _transactionService.InitialiseVendingMachine();
        
        result.Should().NotBeNull();
        result.CashAmount.Should().Be(0d);
        result.CardAmount.Should().Be(0d);
        result.NumberOfItemSold.Should().Be(0);
        result.AvailableItems.Should().Be(10);
        result.Items.Should().HaveCount(10);
    }

    [Test]
    public async Task PurchaseItem_WithValidItemAndPaymentType_ShouldReturnUpdatedVendingMachine()
    {
        var vendingMachine = new Application.Models.VendingMachine
        {
            Items = new List<Can>
            {
                new(1, 2.50, Flavour.Coke),
                new(2, 2.50, Flavour.PepsiMax)
            },
            CashAmount = 0d,
            CardAmount = 0d,
            NumberOfItemSold = 0,
            AvailableItems = 2
        };
        
        var result = await _transactionService.PurchaseItem(vendingMachine, ItemId, PaymentType);
        
        result.Should().NotBeNull();
        result.CashAmount.Should().Be(2.50);
        result.CardAmount.Should().Be(0d);
        result.NumberOfItemSold.Should().Be(1);
        result.AvailableItems.Should().Be(1);
        result.Items.Should().HaveCount(1);
        result.Items.Should().NotContain(can => can.Id == ItemId);
    }

    [Test]
    public async Task PurchaseItem_LastAvailableItem_ShouldRestockVendingMachine()
    {
        var vendingMachine = new Application.Models.VendingMachine
                             {
                                 Items = new List<Can>
                                         {
                                             new(1, 2.50, Flavour.Coke)
                                         },
                                 CashAmount = 0d,
                                 CardAmount = 0d,
                                 NumberOfItemSold = 0,
                                 AvailableItems = 2
                             };
        
        var result = await _transactionService.PurchaseItem(vendingMachine, ItemId, PaymentType);

        result.Should().NotBeNull();
        result.CashAmount.Should().Be(0d);
        result.CardAmount.Should().Be(0d);
        result.NumberOfItemSold.Should().Be(0);
        result.AvailableItems.Should().Be(10);
        result.Items.Should().HaveCount(10);
    }
}