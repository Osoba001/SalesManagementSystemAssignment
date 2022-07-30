using Sales.Library.Model;

namespace Sales.Library.Events
{
    public class SaleEventArg:EventArgs
    {
        public List<Item> Items { get; set; }
    }
}
