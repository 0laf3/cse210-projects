// Interface representing a financial market data provider
public interface IMarketDataProvider
{
    FinancialInstrument GetMarketData(string symbol);
}
