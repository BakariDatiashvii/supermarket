using AutoMapper;
using supermarket.ProductDTO;
using supermarket.SupermarketiDTO;

namespace supermarket
{
    public class AutoMapper: Profile
    {

        public AutoMapper() 
        {
            CreateMap<Supermarket, AddSupermarketDTO>();
            CreateMap<Supermarket, GetSupermarketDTO>();

            CreateMap<Product, AddProductDTO>();
            CreateMap<Product, GetProductDTO>();
        }


    }
}
