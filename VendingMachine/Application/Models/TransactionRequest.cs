namespace VendingMachine.Application.Models;

/// <summary>
/// Represents a request for a transaction in a vending machine.
/// </summary>
public class TransactionRequest
{
    public TransactionRequest(VendingMachine currentVendingMachine, int itemId, PaymentType paymentType)
    {
        CurrentVendingMachine = currentVendingMachine;
        ItemId = itemId;
        PaymentType = paymentType;
    }

    public VendingMachine CurrentVendingMachine { get; set; }
    public int ItemId { get; set; }
    public PaymentType PaymentType { get; set; }
}