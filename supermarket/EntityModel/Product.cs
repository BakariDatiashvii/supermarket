using System.ComponentModel.DataAnnotations;

namespace supermarket.EntityModel
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; } 
        public int  SupermarketId { get; set; }
        public Supermarket Supermarketi { get; set; }
    }
}
