using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks
{
    class Account
    {
        public String name { get; set; }
        public long mobile { get; set; }
        public dynamic buy { get; set; }
        public List<Stocks> sell { get; set; }
    }
}
