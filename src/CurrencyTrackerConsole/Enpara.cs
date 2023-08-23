using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace CurrencyTrackerConsole
{
    public class Enpara
    {
        private Dictionary<string, Dictionary<string, double>> enpara =
            new Dictionary<string, Dictionary<string, double>>();

        private int afterDecimal = 4;
        private string[] items = { "USD", "EUR", "Gold (grams)", "EUR/USD Pair" };
        private string enparaURL = "https://www.qnbfinansbank.enpara.com/hesaplar/doviz-ve-altin-kurlari";

        public Enpara()
        {
            string webContent = new WebClient().DownloadString(enparaURL);

            string divPattern = @"<div class=""enpara-gold-exchange-rates__table-item(.*?)"">(.*?)<\/div>";
            string spanPattern = @"<span>(.*?)<\/span>";

            MatchCollection divMatches  = Regex.Matches(webContent, divPattern, RegexOptions.Singleline);

            for (int i = 0; i < divMatches.Count; i++)
            {
                MatchCollection spanMatches = Regex.Matches(divMatches[i].Groups[2].Value, spanPattern,
                    RegexOptions.Singleline);

                enpara[items[i]] = new Dictionary<string, double>
                {
                    { "BuyRate", GetNumberOfDecimals(ConvertToDecimal(RemoveTL(RemoveDot(spanMatches[1].Groups[1].Value)))) },
                    { "SellRate", GetNumberOfDecimals(ConvertToDecimal(RemoveTL(RemoveDot(spanMatches[2].Groups[1].Value)))) },
                    {
                        "Spread",
                        GetNumberOfDecimals(CalculateDifference(RemoveDot(spanMatches[1].Groups[1].Value),
                            RemoveDot(spanMatches[2].Groups[1].Value)))
                    }
                };
            }
        }

        private double GetNumberOfDecimals(double value)
        {
            return Math.Round(value, afterDecimal);
        }

        private double ConvertToDecimal(string value)
        {
            return double.Parse(value.Replace(",", "."));
        }

        private string RemoveDot(string value)
        {
            return value.Replace(".", "");
        }

        private string RemoveTL(string value)
        {
            return value.Replace(" TL", "");
        }

        private double CalculateDifference(string str1, string str2)
        {
            return ConvertToDecimal(RemoveTL(str2)) - ConvertToDecimal(RemoveTL(str1));
        }

        public void DecimalPlaces(int value)
        {
            if (value >= 0 && value <= 6)
            {
                afterDecimal = value;
                enpara.Clear();
            }
        }

        public string JSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(enpara, Newtonsoft.Json.Formatting.Indented);
        }

        private double BuyingRate(string str)
        {
            return enpara[str]["buyingRate"];
        }

        private double SellingRate(string str)
        {
            return enpara[str]["sellingRate"];
        }

        private double Spread(string str)
        {
            return BuyingRate(str) - SellingRate(str);
        }
    }
}
