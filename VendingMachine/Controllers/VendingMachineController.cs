using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Model;

namespace VendingMachine.Controllers;

public class VendingMachineController : Controller
{
    [Route(""), HttpGet]
    public async Task<ActionResult<Application.Model.VendingMachine>> GetInitialVendingMachine()
    {
        var vendingMachine = new Application.Model.VendingMachine();

        return Ok(vendingMachine);
    }

    [Route("/{itemId:min(1)}"), HttpPut]
    public async Task<ActionResult<Application.Model.VendingMachine>> ItemTransaction(Application.Model.VendingMachine vendingMachine, int itemId, double amount, PaymentType paymentType)
    {
        vendingMachine.ItemTransaction(itemId, amount, paymentType);

        return Ok(vendingMachine);
    }
}