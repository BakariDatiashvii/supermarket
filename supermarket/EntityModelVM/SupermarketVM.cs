using supermarket.EntityModel;

namespace supermarket.EntityModelVM
{
    public class SupermarketVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductVM> Porductebi { get; set; }
    }
}
