using supermarket.ProductDTO;

namespace supermarket.SupermarketiDTO
{
    public class GetSupermarketDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<AddProductDTO> addSupermarketDTOs { get; set; }
    }
}
