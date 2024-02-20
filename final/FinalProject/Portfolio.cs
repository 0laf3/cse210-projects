public class Portfolio
{
    private List<FinancialInstrument> holdings;

    public Portfolio()
    {
        holdings = new List<FinancialInstrument>();
    }

    public void AddToPortfolio(FinancialInstrument instrument)
    {
        holdings.Add(instrument);
    }

    public void DisplayPortfolio()
    {
        foreach (var instrument in holdings)
        {
            instrument.DisplayInfo();
        }
    }
}