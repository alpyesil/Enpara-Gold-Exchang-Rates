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
