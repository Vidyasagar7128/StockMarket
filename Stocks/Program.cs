using System;

namespace Stocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateStocks createStocks = new CreateStocks();
            createStocks.Create();
            CreateAccount createAccount = new CreateAccount();
            createAccount.Create();
            StockAccount stockAccount = new StockAccount();
            stockAccount.HandleMenu();
        }
    }
}
