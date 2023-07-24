using Microsoft.AspNetCore.Mvc;
using supermarket.ProductServise;
using supermarket.SupermarketiDTO;
using supermarket.SupermarketServise;

namespace supermarket.Controllers
{
    public class SupermarketController
    {

        private readonly ISupermarketServise _SupermarketServise;
        public SupermarketController(ISupermarketServise SupermarketServise)
        {
            _SupermarketServise = SupermarketServise;
        }
        [HttpPost("create-supermarket")]

        public async Task<ActionResult<ServiceResponse<AddSupermarketDTO>>> Addsupermarketi(AddSupermarketDTO addSupermarketDTO)
        {
            return await _SupermarketServise.AddSupermarket(addSupermarketDTO);    
        }

        [HttpGet("supermarketi-tavisi-produqtebit")]

        public async Task<ActionResult<ServiceResponse<GetSupermarketDTO>>> getsupermarketproduqtit(int Id)
        {
            return await _SupermarketServise.GetSupermarket(Id);
        }

        [HttpGet("supermarket-produqtit")]
        public async Task<ActionResult<ServiceResponse<List<GetSupermarketDTO>>>> getsupermatproduct()
        {
            return await _SupermarketServise.GetSupermarkets();
        }

        [HttpDelete("delete-supermarket-product")]
        public async Task<ActionResult<ServiceResponse<GetSupermarketDTO>>>  deletesup (int ID)
        {
            return await _SupermarketServise.DeleteSupermarkets(ID);
        }
    }
}
