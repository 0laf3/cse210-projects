//representing a generic financial instrument
public abstract class FinancialInstrument
{
    public string Symbol { get; set; }
    public decimal Price { get; set; }

    public abstract void DisplayInfo();
}