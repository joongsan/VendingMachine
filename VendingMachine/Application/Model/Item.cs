namespace VendingMachine.Application.Model;

public abstract class Item
{
    public int Id { get; set; }
    public double Price { get; }

    protected Item(int id, double price)
    {
       
    }
}