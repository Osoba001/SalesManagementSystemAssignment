using Sales.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Dome.DTO
{
    public class CreateSaleCommand
    {
        public CreateSaleCommand()
        {
            Items = new List<Item>();
        }
        public int Quantity
        {
            get { return Items.Count; }
            protected set { }
        }
        public decimal TotalPrice
        {
            get { return Items.Sum(x => x.Price); }
            protected set { }
        }
        public List<Item> Items { get; set; }
    }
}
