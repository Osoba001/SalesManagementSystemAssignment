namespace Sales.Library.Model
{
    public class Sale
    {
        public Sale()
        {

        }
        public Sale(List<Item> items)
        {
            SaleDate=DateTime.Now;
            Items = items;
        }
        public virtual int Id { get; set; }
        public virtual List<Item> Items { get; set; }


        private decimal _totalPrice;

        public virtual decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = Items.Sum(x => x.Price); }
        }

        public virtual DateTime SaleDate { get; set; }

    }
}
