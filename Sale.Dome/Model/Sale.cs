using Sale.Dome.Model;

namespace Sales.Library.Model
{
    public class Sale: BaseEntity
    {
        public Sale()
        {
            Items = new();
            SaleDate =DateTime.Now;
        }
  
        public virtual decimal TotalPrice  { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual DateTime SaleDate { get; set; }

    }
}
