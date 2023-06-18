namespace VendingMachine.Application.Models;

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