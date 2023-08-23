# Enpara Gold Exchange Rates Scraper

This is a simple application to scrape gold exchange rates from the Enpara website.

## Features

- Scrapes gold exchange rates for various currencies from the Enpara website.
- Calculates buying and selling rates along with the spread.
- Displays the results in a structured dictionary.

## Prerequisites

- .NET Core SDK 3.1 (or later)

## Usage

1. Clone this repository:

```bash
git clone https://github.com/alpyesil/Enpara-Gold-Exchang-Rates.git
```

2. Navigate to the project directory:

```bash
cd enpara-gold-exchange-rates
```

3. Run the application:

```bash
dotnet run
```

## Sample Output
```bash
The application provides output in the following format:

{
  "USD": {
    "BuyRate": 26.94,
    "SellRate": 27.87,
    "Spread": 0.93
  },
  "EUR": {
    "BuyRate": 29.0514,
    "SellRate": 30.5107,
    "Spread": 1.4592
  },
  "Gold (grams)": {
    "BuyRate": 1636.085,
    "SellRate": 1738.9363,
    "Spread": 102.8514
  },
  "EUR/USD Pair": {
    "BuyRate": 1.0784,
    "SellRate": 1.0947,
    "Spread": 0.0164
  }
}

```

## Explanation

```bash
'ConvertToDecimal': Converts a string representation of a number to a decimal.
'RemoveTL': Removes the Turkish Lira symbol from a string.
'RemoveDot': Removes the dot from a string.
'CalculateDifference': Calculates the difference between two numbers.
'GetNumberOfDecimals': Gets the number of decimals in a number.
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
