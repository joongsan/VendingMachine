namespace VendingMachine.Application.Models;

public sealed class Can
{
    /// <summary>
    /// Represents a can, which is one of the different categories of items in a vending machine.
    /// </summary>
    public Can(int id, double price, Flavour flavour)
    {
        Id = id;
        Price = price;
        Flavour = flavour;
    }
    
    public int Id { get; }
    public double Price { get; }
    public Flavour Flavour { get; }
}