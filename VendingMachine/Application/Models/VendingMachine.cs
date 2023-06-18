using System.Collections;

namespace VendingMachine.Application.Models;

/// <summary>
/// Represents a vending machine.
/// </summary>
public class VendingMachine
{
    public VendingMachine()
    {
        Items = new List<Can>();
    }

    public List<Can> Items { get; set; }

    public int NumberOfItemSold { get; set; }
    public int AvailableItems { get; set; }

    public double CashAmount { get; set; }
    public double CardAmount { get; set; }

    /// <summary>
    /// Deposits cash into the vending machine.
    /// </summary>
    /// <param name="amount">The amount of cash to deposit.</param>
    public void CashDeposit(double amount)
    {
        CashAmount += amount;
    }

    /// <summary>
    /// Deposits funds from a card into the vending machine.
    /// </summary>
    /// <param name="amount">The amount of funds to deposit.</param>
    public void CardDeposit(double amount)
    {
        CardAmount += amount;
    }
}