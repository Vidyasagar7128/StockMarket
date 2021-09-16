using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stocks
{
    class ManageShares
    {
        List<Stocks> showStockList = new List<Stocks>();
        List<Account> showDematAccounts = new List<Account>();
        LinkedList<Stocks> stockList = new LinkedList<Stocks>();
        List<Stocks> uploadStockList = new List<Stocks>();
        List<Stocks> stockListSave = new List<Stocks>();
        
        public void Buy(String symbol,double price)
        {
            uploadStockList = FixBuy(symbol, price);
            //fetch Demat Account
            String file1 = File.ReadAllText(@"accountList.json");
            showDematAccounts = JsonConvert.DeserializeObject<List<Account>>(file1);
            Console.Write("Enter Mobile : ");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine($"{symbol} Company shares Buying... for : {price}");
            //Buying Process
            foreach (var i in showDematAccounts)
            {
                if (i.mobile == mobile)
                {
                    Console.WriteLine($"Hey! {i.name} are you using {i.mobile} Number.!");
                    i.buy = uploadStockList;
                    Console.WriteLine(i.mobile);
                }
            }
            String updateStock = JsonConvert.SerializeObject(showDematAccounts);
            File.WriteAllText(@"accountList.json", updateStock);
        }
        //////////// Picking Shares
        public List<Stocks> FixBuy(String symbol, double price)
        {
            ///fetch Stocks
            String file = File.ReadAllText(@"stockList.json");
            showStockList = JsonConvert.DeserializeObject<List<Stocks>>(file);
            foreach (Stocks i in showStockList)
            {
                if (i.stockName == symbol)
                {
                    Console.WriteLine($"Today's Price : {i.priceOfShare}");
                    Stocks stocks = new Stocks()
                    {
                        stockName = i.stockName,
                        numberOfShare = i.numberOfShare,
                        priceOfShare = price,
                        date = DateTime.Now
                    };
                    stockListSave.Add(stocks);
                }
            }
            foreach (var i in stockList)
            {
                Console.WriteLine(i.priceOfShare);
            }
            return stockListSave;
        }
    }
}

/*
 {
                if (i.mobile == mobile)
                {
                    Console.WriteLine($"{i.name},{i.mobile}");
                }
            }




for (int i = 0; i < showDematAccounts.Count; i++)
            {
                if (showDematAccounts[i].mobile == mobile)
                {
                    Console.WriteLine($"Hey! {showDematAccounts[i].name} are you using {showDematAccounts[i].mobile} Number.!");
                    showDematAccounts[i].buy = FixBuy(symbol,price);
                    Console.WriteLine(showDematAccounts[i].mobile);
                }
            }
 */