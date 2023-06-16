namespace VendingMachine.Application.Model;

public sealed class Can
{
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