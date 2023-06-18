using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using VendingMachine.Application.Models;
using VendingMachine.Domain;

namespace VendingMachine.Controllers;

/// <summary>
/// Controller responsible for handling vending machine-related actions.
/// </summary>
public class VendingMachineController : Controller
{
    private readonly ITransactionService _transactionService;

    public VendingMachineController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [Route(""), HttpGet]
    public async Task<IStatusCodeActionResult> GetInitialVendingMachine()
    {
        var newVendingMachine = await _transactionService.InitialiseVendingMachine();

        return Ok(newVendingMachine);
    }

    [Route(""), HttpPost]
    public async Task<IStatusCodeActionResult> ItemTransaction([FromBody] TransactionRequest request)
    {
        var updatedVendingMachine = await _transactionService.PurchaseItem(request.CurrentVendingMachine,
                                                                           request.ItemId,
                                                                           request.PaymentType);

        return Ok(updatedVendingMachine);
    }
}