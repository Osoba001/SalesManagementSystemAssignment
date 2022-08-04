namespace Sales.Library.Model
{
    public class Sale
    {
        public Sale()
        {
             Items = new();
             SaleDate =DateTime.Now;
        }
        public virtual int Id { get; set; }
        public virtual List<Item> Items { get; set; }

        public virtual decimal TotalPrice
        {
            get { return Items.Sum(x => x.Price); }
        }
        public virtual int Quantity
        {
            get { return Items.Count; }
        }
        public virtual DateTime SaleDate { get; set; }

    }
}
