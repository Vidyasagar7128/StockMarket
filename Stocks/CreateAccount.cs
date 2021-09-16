using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stocks
{
    class CreateAccount
    {
        List<Account> accounts = new List<Account>();
        public void Create()
        {
            Account account = new Account()
            {
                name = "Gaikwad Sonu",
                mobile = 9511857145,
                buy = { },
                sell = { },
            };
            Account account1 = new Account()
            {
                name = "Gaikwad Manoj",
                mobile = 8412824420,
                buy = { },
                sell = { },
            };
            accounts.Add(account);
            accounts.Add(account1);
            String data = JsonConvert.SerializeObject(accounts);
            File.WriteAllText(@"accountList.json", data);
        }
    }
}
