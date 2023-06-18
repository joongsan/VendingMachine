using VendingMachine.Application.Models;

namespace VendingMachine.Domain;

/// <summary>
/// Interface for a transaction service responsible for vending machine operations.
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Initializes a vending machine.
    /// </summary>
    /// <returns>The initialized vending machine.</returns>
    Task<Application.Models.VendingMachine> InitialiseVendingMachine();

    /// <summary>
    /// Purchases an item from the vending machine.
    /// </summary>
    /// <param name="item">The current vending machine.</param>
    /// <param name="itemId">The ID of the item to purchase.</param>
    /// <param name="paymentType">The payment type for the transaction.</param>
    /// <returns>The updated vending machine after the purchase.</returns>
    Task<Application.Models.VendingMachine> PurchaseItem(Application.Models.VendingMachine item, int itemId, PaymentType paymentType);
}