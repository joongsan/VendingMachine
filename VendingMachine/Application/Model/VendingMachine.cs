namespace VendingMachine.Application.Model;

public class VendingMachine
{
    public VendingMachine()
    {
        Items = new();
        Restock();
        NumberOfItemSold = 0;
        AvailableItems = Items.Count;
    }

    public List<Can> Items { get; }

    private const double InitialAmount = 0d;

    public int NumberOfItemSold { get; set; }
    public int AvailableItems { get; }

    public double CashAmount { get; private set; } = InitialAmount;
    public double CardAmount { get; private set; } = InitialAmount;

    private void CashDeposit(double amount)
    {
        CashAmount += amount;
    }

    private void CardDeposit(double amount)
    {
        CardAmount += amount;
    }

    public void ItemTransaction(int itemId, double amount, PaymentType paymentType)
    {
        var itemToRemove = Items.Find(x => x.Id == itemId);

        if (Items.Count <= 0 || itemToRemove == null) return;
        switch (paymentType)
        {
            case PaymentType.Card:
                CardDeposit(amount);
                break;
            case PaymentType.Cash:
                CashDeposit(amount);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(paymentType), paymentType, null);
        }

        Items.Remove(itemToRemove);

        NumberOfItemSold++;

        if (ShouldRestock())
        {
            Restock();
            CashAmount = 0;
            CardAmount = 0;
        };
    }

    private bool ShouldRestock() => Items.Count == 0;

    private void Restock()
    {
        const int maxCount = 10;

        var ranNumber = new Random(12);

        for (var index = 0; index < maxCount; index++)
        {
            var randomFlavour = (Flavour)ranNumber.Next(0, 10);

            Items.Add(new Can(index + 1, 2.50, randomFlavour));
        }
    }
}