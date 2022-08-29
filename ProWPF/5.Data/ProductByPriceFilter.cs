using StoreDataBase.Model;

namespace ProWPF.Data
{
    class ProductByPriceFilter
    {
        public decimal MinimumPrice { get; set; }

        public ProductByPriceFilter(decimal minimumPrice)
        {
            MinimumPrice = minimumPrice;
        }

        //符号条件的返回true，否则返回false
        public bool FilterItem(object item)
        {
            Product product = item as Product;
            return product != null && product.UnitCost > MinimumPrice;
        }
    }
}
