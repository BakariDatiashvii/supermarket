
using supermarket.SupermarketiDTO;

namespace supermarket.SupermarketServise
{
    public interface ISupermarketServise
    {
       Task<ServiceResponse<List<GetSupermarketDTO>>> GetSupermarkets();
        Task<ServiceResponse<GetSupermarketDTO>> GetSupermarket(int Id);
        Task<ServiceResponse<AddSupermarketDTO>> AddSupermarket(AddSupermarketDTO addsupermarketdto);
        Task<ServiceResponse<UpdateSupermarketDTO>> UpdateSupermarket(UpdateSupermarketDTO Updatesupermarketdto);

        Task<ServiceResponse<GetSupermarketDTO>> DeleteSupermarkets( int Id);
    }
}
