using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Model;

namespace VendingMachine.Controllers;

public class VendingMachineController : Controller
{
    [Route(""), HttpGet]
    public Task<ActionResult<Application.Model.VendingMachine>> GetInitialVendingMachine()
    {
        var vendingMachine = new Application.Model.VendingMachine();

        return Task.FromResult<ActionResult<Application.Model.VendingMachine>>(Ok(vendingMachine));
    }

    [Route(""), HttpPost]
    public Task<ActionResult<Application.Model.VendingMachine>> ItemTransaction([FromBody] Application.Model.VendingMachine currentVendingMachine, int itemId, PaymentType paymentType)
    {
        currentVendingMachine.ItemTransaction(itemId, paymentType);

        return Task.FromResult<ActionResult<Application.Model.VendingMachine>>(Ok(currentVendingMachine));
    }
}