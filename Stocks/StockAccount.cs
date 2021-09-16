using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks
{
    class StockAccount
    {
        public void HandleMenu()
        {
            Console.WriteLine("1.Market 2.Create Stocks 3.Your Account");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine("Shares");
                    CreateStocks createStocks1 = new CreateStocks();
                    createStocks1.ShowStocks();
                    HandleMenu();
                    break;
                case 2:
                    CreateStocks createStocks = new CreateStocks();
                    createStocks.CustomCreate();
                    HandleMenu();
                    break;
                case 3:
                    Console.WriteLine("Account");
                    Console.Write("Symbol/Name : ");
                    String symbol = Console.ReadLine();
                    Console.Write("Amount/Share : ");
                    double amount = double.Parse(Console.ReadLine());
                    ManageShares manageShares = new ManageShares();
                    manageShares.Buy(symbol,amount);
                    HandleMenu();
                    break;
                default:
                    Console.WriteLine("You choose wrong Option");
                    HandleMenu();
                    break;
            }
        }
    }
}
