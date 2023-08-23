using System;

namespace CurrencyTrackerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Enpara enpara = new Enpara();
            Console.WriteLine(enpara.JSON());
        }
    }
}
