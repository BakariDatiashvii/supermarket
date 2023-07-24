using Microsoft.AspNetCore.Mvc;
using supermarket.ProductDTO;
using supermarket.ProductServise;

namespace supermarket.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductServise _productServise;
        public ProductController(IProductServise productServise)
        {
            _productServise = productServise;
        }
        [HttpPost("product-damateba")]
        public async Task<ActionResult<ServiceResponse<AddProductDTO>>> addproduct(AddProductDTO productDTO)
        {
            //if (productDTO == null)
            //{
            //    return  BadRequest(new { error = "Invalid product data" });
            //}

            return await _productServise.AddProduct(productDTO);

        }

        [HttpGet("product-tavisi-marketit")]
        public async Task<ActionResult<ServiceResponse<GetProductDTO>>> getproductsupermarketi (int ID)
        {
            return await _productServise.GetProduct(ID);
        }

        [HttpGet("yvela-produqtiswamogeba-supermarket")]
        public async Task<ActionResult<ServiceResponse<List<GetProductDTO>>>> allproductmarket()
        {
            return await _productServise.GetProducts(); 
        }

        [HttpDelete("delepte-produqti-super")]

        public async Task<ActionResult<ServiceResponse<GetProductDTO>>> delproductsup (int ID)
        {
            return await _productServise.GetProduct(ID); 
        }
    }

}
