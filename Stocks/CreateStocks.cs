using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Stocks
{
    class CreateStocks
    {
        List<Stocks> myStockList = new List<Stocks>();
        List<Stocks> showStockList = new List<Stocks>();

        public void Create()
        {
            for (int i = 1; i <= 3; i++)
            {
                int number = new Random().Next(1, 21);
                double price = new Random().Next(500, 1500);
                Stocks stocks = new Stocks()
                {
                    stockName = $"{i}.PVT.LTD",
                    numberOfShare = number,
                    priceOfShare = Math.Round(price / number, 2),
                    totalSharePrice = price,
                    date = DateTime.Now
                };
                myStockList.Add(stocks);
                //myStockList.Add(CustomCreate());
                String myStock = JsonConvert.SerializeObject(myStockList);
                File.WriteAllText(@"stockList.json", myStock);

                String file = File.ReadAllText(@"stockList.json");
                showStockList = JsonConvert.DeserializeObject<List<Stocks>>(file);
                
            }
            for(int i = 0; i < showStockList.Count; i++)
            {
                if(showStockList[i].stockName== "1.PVT.LTD")
                {
                    Console.WriteLine(showStockList[0].priceOfShare);
                    showStockList[i].stockName = "TATA.PVT.LTD";
                    Console.WriteLine(showStockList[0].stockName);
                }
            }
            foreach(var i in showStockList)
            {
                Console.WriteLine(i.stockName);
            }
            String upDateStock = JsonConvert.SerializeObject(showStockList);
            File.WriteAllText(@"stockList.json", upDateStock);
        }

        public Stocks CustomCreate()
        {
            Console.WriteLine("Create Stocks for Company");
            Console.WriteLine();
            Console.Write("Enter Stock Name for Company : ");
            String companyName = Console.ReadLine();
            Console.Write("How Many Shares : ");
            int shares = int.Parse(Console.ReadLine());
            Console.Write("Price of Share : ");
            double price = double.Parse(Console.ReadLine());

            Stocks stocks = new Stocks()
            {
                stockName = companyName,
                numberOfShare = shares,
                priceOfShare = price,
                totalSharePrice = price*shares,
            };
            return stocks;
        }
       public void ShowStocks()
        {
            String file = File.ReadAllText(@"stockList.json");
            showStockList = JsonConvert.DeserializeObject<List<Stocks>>(file);
            foreach (var i in showStockList)
            {
                Console.WriteLine($"{i.stockName} | {i.numberOfShare} | {i.priceOfShare} | {i.totalSharePrice} | {i.date}");
            }
        }
    }
}
