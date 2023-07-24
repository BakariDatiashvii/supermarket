namespace supermarket.ProductDTO
{
    public class AddProductDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int SupermarketId { get; set; }
    }
}
