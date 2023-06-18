namespace VendingMachine.Application.Models;

/// <summary>
/// Represents an abstract base class for items in a vending machine.
/// </summary>
public abstract class Item
{
    public int Id { get; set; }
    public double Price { get; }
}