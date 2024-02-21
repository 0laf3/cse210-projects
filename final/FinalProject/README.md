# Stock tracking Application

This Application implements a Stock tracking Application with classes representing abstract and concrete  Stock tracking Application, a market data provider interface, a specific market data provider implementation, and a portfolio class to manage a collection of  Stock tracking Application.


## Overview

The Stock tracking Applications consists of the following components:

1. **FinancialInstrument (Abstract Class):**
   - Represents a generic Stock tracking Application with properties `Symbol` and `Price`.
   - Declares an abstract method `DisplayInfo()`.

2. **Stock (Concrete Class):**
   - Inherits from `FinancialInstrument`.
   - Adds a property `SharesOwned`.
   - Implements the abstract method `DisplayInfo()` to display stock-specific information.

3. **Bond (Concrete Class):**
   - Inherits from `FinancialInstrument`.
   - Adds a property `MaturityDate`.
   - Implements the abstract method `DisplayInfo()` to display bond-specific information.

4. **IMarketDataProvider (Interface):**
   - Declares a method `GetMarketData(string symbol)` to retrieve Stock tracking Applicationdata.

5. **AlphaVantageMarketDataProvider (Class):**
   - Implements the `IMarketDataProvider` interface.
   - Simulates fetching market data (stock information in this case) from a provider (e.g., Alpha Vantage) by generating random data.

6. **Portfolio (Class):**
   - Manages a collection of  Stock tracking Application using a `List<FinancialInstrument>`.
   - Provides methods to add instruments to the portfolio and display portfolio information.

7. **Program (Main Class):**
   - In the `Main` method:
      - Instantiates an `AlphaVantageMarketDataProvider` as a market data provider.
      - Retrieves market data for three  Stock tracking Application (two stocks and one bond).
      - Creates a `Portfolio` and adds the retrieved instruments to it.
      - Displays information about the Financial instruments in the portfolio.
