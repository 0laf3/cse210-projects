//representing a bond, inheriting from FinancialInstrument
public class Bond : FinancialInstrument
{
    public DateTime MaturityDate { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Bond - Symbol: {Symbol}, Price: {Price:C}, Maturity Date: {MaturityDate:d}");
    }
}
