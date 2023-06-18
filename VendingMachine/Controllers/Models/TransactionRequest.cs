using VendingMachine.Application.Models;

namespace VendingMachine.Controllers.Models;

/// <summary>
/// Represents a request for a transaction in a vending machine.
/// </summary>
public class TransactionRequest
{
    public TransactionRequest(Application.Models.VendingMachine currentVendingMachine, int itemId, PaymentType paymentType)
    {
        CurrentVendingMachine = currentVendingMachine;
        ItemId = itemId;
        PaymentType = paymentType;
    }

    public Application.Models.VendingMachine CurrentVendingMachine { get; set; }
    public int ItemId { get; set; }
    public PaymentType PaymentType { get; set; }
}