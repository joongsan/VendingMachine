using System.Collections;

namespace VendingMachine.Application.Models;

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

    public void CashDeposit(double amount)
    {
        CashAmount += amount;
    }

    public void CardDeposit(double amount)
    {
        CardAmount += amount;
    }
}