using System.Collections;

using VendingMachine.Application.Models;

namespace VendingMachine.Domain;

public class TransactionServices : ITransactionService
{
    private const double FixedAmount = 2.50;

    public Task<Application.Models.VendingMachine> InitialiseVendingMachine()
    {
        var newVendingMachine = new Application.Models.VendingMachine();

        Restock(newVendingMachine.Items);
        
        newVendingMachine.CashAmount = 0d;
        newVendingMachine.CardAmount = 0d;
        newVendingMachine.AvailableItems = newVendingMachine.Items.Count;

        return Task.FromResult(newVendingMachine);
    }

    public Task<Application.Models.VendingMachine> PurchaseItem(Application.Models.VendingMachine currentVendingMachine, int itemId, PaymentType paymentType)
    {
        var items = currentVendingMachine.Items;

        var itemToRemove = items.Find(x => x.Id == itemId);

        if (items.Count <= 0 || itemToRemove == null) return Task.FromResult(new Application.Models.VendingMachine());
        switch (paymentType)
        {
            case PaymentType.Card:
                currentVendingMachine.CardDeposit(FixedAmount);
                break;
            case PaymentType.Cash:
                currentVendingMachine.CashDeposit(FixedAmount);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null);
        }

        items.Remove(itemToRemove);

        currentVendingMachine.NumberOfItemSold++;
        currentVendingMachine.AvailableItems = items.Count;

        if (!ShouldRestock(items)) return Task.FromResult(currentVendingMachine);

        Restock(items);
        currentVendingMachine.CashAmount = 0d;
        currentVendingMachine.CardAmount = 0d;

        return Task.FromResult(currentVendingMachine);
    }

    private static void Restock(ICollection<Can> items)
    {
        const int maxCount = 10;

        var ranNumber = new Random(12);

        for (var index = 0; index < maxCount; index++)
        {
            var randomFlavour = (Flavour)ranNumber.Next(0, 10);

            items.Add(new Can(index + 1, FixedAmount, randomFlavour));
        }
    }

    private static bool ShouldRestock(ICollection items) => items.Count == 0;
}