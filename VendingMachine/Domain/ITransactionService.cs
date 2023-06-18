using VendingMachine.Application.Models;

namespace VendingMachine.Domain;

public interface ITransactionService
{
    Task<Application.Models.VendingMachine> InitialiseVendingMachine();
    Task<Application.Models.VendingMachine> PurchaseItem(Application.Models.VendingMachine item, int itemId, PaymentType paymentType);
}