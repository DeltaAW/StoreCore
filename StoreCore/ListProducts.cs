using System;
using System.Collections.Generic;
using System.Text;

namespace StoreCore
{
    internal class ListProducts
    {
        public string Name { get; set; }
        //private decimal Price { get; set; }
        //private int Quantity { get; set; }

        public ListProducts(string name) //, decimal price, int quanity)
        {
            Name = name;
            //Price = price;
            //Quantity = quanity;
        }
    }
}
