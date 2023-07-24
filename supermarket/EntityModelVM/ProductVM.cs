using supermarket.EntityModel;

namespace supermarket.EntityModelVM
{
    public class ProductVM
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int SupermarketId { get; set; }
        public SupermarketVM Supermarketi { get; set; }
    }
}
