using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

using VendingMachine.Application.Models;
using VendingMachine.Controllers;
using VendingMachine.Domain;

namespace VendingMachine.Tests;

[TestFixture]
public class VendingMachineControllerTests
{
    private readonly Application.Models.VendingMachine _expectedVendingMachine = new();
    
    private readonly TransactionRequest _request = new (new Application.Models.VendingMachine(), 1, PaymentType.Cash);
    private readonly Application.Models.VendingMachine _updatedVendingMachine = new();

    private Mock<ITransactionService> _transactionServiceMock = null!;
    private VendingMachineController _vendingMachineController = null!;
    
    [SetUp]
    public void Setup()
    {
        _transactionServiceMock = new Mock<ITransactionService>();
        _vendingMachineController = new VendingMachineController(_transactionServiceMock.Object);

        
        _transactionServiceMock.Setup(service => service.InitialiseVendingMachine())
                               .ReturnsAsync(_expectedVendingMachine);

        
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
}