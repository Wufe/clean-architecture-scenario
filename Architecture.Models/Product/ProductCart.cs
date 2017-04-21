namespace Architecture.Models.Product
{
    public class ProductCart : ProductBase, IProductCart
    {
        public double Quantity { get; set; }
    }
}
