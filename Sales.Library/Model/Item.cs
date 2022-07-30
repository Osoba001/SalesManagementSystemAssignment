﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Library.Model
{
    public class Item
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        private int quantity;

        public virtual int Quantity
        {
            get { return quantity; }
            set { quantity = quantity+value; }
        }
        public virtual decimal Price { get; set; }
    }
}
