using supermarket.ProductDTO;
using supermarket.SupermarketiDTO;

namespace supermarket.ProductServise
{
    public interface IProductServise
    {
        Task<ServiceResponse<List<GetProductDTO>>> GetProducts();
        Task<ServiceResponse<GetProductDTO>> GetProduct(int Id);
        Task<ServiceResponse<AddProductDTO>> AddProduct(AddProductDTO addProductDTO);
        Task<ServiceResponse<UpdateProductDTO>> UpdateProduct(UpdateProductDTO UpdateProductDTO);

        Task<ServiceResponse<GetProductDTO>> DeleteProducts(int Id);
    }
}
