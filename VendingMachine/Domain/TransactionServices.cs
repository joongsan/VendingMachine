using System.Collections;

using VendingMachine.Application.Models;

namespace VendingMachine.Domain;

/// <summary>
/// Transaction service implementation for vending machine operations.
/// </summary>
public class TransactionServices : ITransactionService
{
    private const double FixedAmount = 2.50;

    public Task<Application.Models.VendingMachine> InitialiseVendingMachine()
    {
        // Create a new vending machine instance
        var newVendingMachine = new Application.Models.VendingMachine();

        // Restock the vending machine items
        Restock(newVendingMachine.Items);
        
        // Set cash and card amounts to 0 initially, and set available items count
        newVendingMachine.CashAmount = 0d;
        newVendingMachine.CardAmount = 0d;
        newVendingMachine.AvailableItems = newVendingMachine.Items.Count;

        // Return the initialized vending machine
        return Task.FromResult(newVendingMachine);
    }

    public Task<Application.Models.VendingMachine> PurchaseItem(Application.Models.VendingMachine currentVendingMachine, int itemId, PaymentType paymentType)
    {
        var items = currentVendingMachine.Items;

        // Find the item to remove
        var itemToRemove = items.Find(x => x.Id == itemId);

        // If there are no items or the item to remove is not found, return an empty vending machine
        if (items.Count <= 0 || itemToRemove == null) return Task.FromResult(new Application.Models.VendingMachine());

        // Process the payment based on the payment type
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

        // Remove the purchased item
        items.Remove(itemToRemove);

        // Update the statistics
        currentVendingMachine.NumberOfItemSold++;
        currentVendingMachine.AvailableItems = items.Count;

        // If the vending machine needs to be restocked, restock it and reset cash and card amounts
        if (!ShouldRestock(items)) 
            return Task.FromResult(currentVendingMachine);

        Restock(items);
        currentVendingMachine.CashAmount = 0d;
        currentVendingMachine.CardAmount = 0d;
        currentVendingMachine.AvailableItems = items.Count;
        currentVendingMachine.NumberOfItemSold = 0;

        // Return the updated vending machine
        return Task.FromResult(currentVendingMachine);
    }

    private static void Restock(ICollection<Can> items)
    {
        const int maxCount = 10;

        var ranNumber = new Random(12);

        for (var index = 0; index < maxCount; index++)
        {
            // Generate a random flavour for each item
            var randomFlavour = (Flavour)ranNumber.Next(0, 10);

            // Add the restocked item to the collection
            items.Add(new Can(index + 1, FixedAmount, randomFlavour));
        }
    }

    private static bool ShouldRestock(ICollection items) => items.Count == 0;
}