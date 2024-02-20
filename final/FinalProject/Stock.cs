
public class Stock : FinancialInstrument
{
    public int SharesOwned { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Stock - Symbol: {Symbol}, Price: {Price:C}, Shares Owned: {SharesOwned}");
    }
}