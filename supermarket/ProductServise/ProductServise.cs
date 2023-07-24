using supermarket.DBcontext;
using supermarket.EntityModel;
using supermarket.EntityModelVM;
using supermarket.ProductDTO;
using supermarket.SupermarketiDTO;

namespace supermarket.ProductServise
{
    public class ProductServise : IProductServise
    {

        private readonly SupermarketProductDBcontext _conetxt;

        public ProductServise(SupermarketProductDBcontext context)
        {
            _conetxt = context;
        }

        public async Task<ServiceResponse<AddProductDTO>> AddProduct(AddProductDTO addProductDTO)
        {
            var producti = new Product()
            {
                ProductId = addProductDTO.ProductId,
                ProductName = addProductDTO.ProductName,

                ProductPrice = addProductDTO.ProductPrice,
                ProductDescription = addProductDTO.ProductDescription,
                SupermarketId = addProductDTO.SupermarketId

            };

            _conetxt.products.Add(producti);
            _conetxt.SaveChanges();

            var Addproductidto = new AddProductDTO()
            {
                ProductId = producti.ProductId,
                ProductName = producti.ProductName,

                ProductPrice = producti.ProductPrice,
                ProductDescription = producti.ProductDescription,
                SupermarketId = producti.SupermarketId
            };

            var Serviseresp = new ServiceResponse<AddProductDTO>();
            Serviseresp.Data = Addproductidto;
            Serviseresp.Success = true;
            Serviseresp.Massage = "warmaebulia";
            return Serviseresp;
        }

        public async Task<ServiceResponse<GetProductDTO>> DeleteProducts(int Id)
        {
            var delete = _conetxt.products.Include(x => x.Supermarketi).FirstOrDefault(z => z.ProductId == Id);
            var getdelete = new GetProductDTO()
            {
                ProductId = delete.ProductId,
                ProductName = delete.ProductName,
                ProductPrice = delete.ProductPrice,
                ProductDescription = delete.ProductDescription,
                SupermarketId = delete.SupermarketId,
                supermarketi = new AddSupermarketDTO()
                {
                    Id = delete.Supermarketi.Id,
                    Name = delete.Supermarketi.Name,
                    Description = delete.Supermarketi.Description
                },

            };

            _conetxt.products.Remove(delete);
            _conetxt.SaveChanges();

            var servise = new ServiceResponse<GetProductDTO>();
            servise.Data = getdelete;
            servise.Success = true;
            servise.Massage = "warmaebulia";
            return servise;

        }

        public async Task<ServiceResponse<GetProductDTO>> GetProduct(int Id)
        {
            var produqti = _conetxt.products.FirstOrDefault(x=> x.ProductId == Id);
            var getproductdto = new GetProductDTO()
            {
                ProductId = produqti.ProductId,
                ProductName = produqti.ProductName,
                ProductPrice = produqti.ProductPrice,
                ProductDescription = produqti.ProductDescription,
                SupermarketId = produqti.SupermarketId,

                supermarketi = new AddSupermarketDTO()
                
            };

            var supermarketi = _conetxt.supermarkets.FirstOrDefault(x=> x.Id == getproductdto.SupermarketId);

            getproductdto.supermarketi.Id = supermarketi.Id;
            getproductdto.supermarketi.Name = supermarketi.Name;
            getproductdto.supermarketi.Description = supermarketi.Description;
            

            var serviserest = new ServiceResponse<GetProductDTO>();
            serviserest.Data = getproductdto;
            serviserest.Success = true;
            serviserest.Massage = "warmaebulia";
            return serviserest;

        }

        public async Task<ServiceResponse<List<GetProductDTO>>> GetProducts()
        {
            var produqtebi = _conetxt.products.Include(x=> x.Supermarketi).Select(z=> new GetProductDTO()
            {
                ProductId = z.ProductId,
                ProductName = z.ProductName,
                ProductPrice = z.ProductPrice,
                ProductDescription  = z.ProductDescription,
                SupermarketId =z.SupermarketId,
                supermarketi  =  new AddSupermarketDTO()
                {
                    Id = z.Supermarketi.Id,
                    Name = z.Supermarketi.Name,
                    Description  = z.Supermarketi.Description
                },
            }).ToList();

            var serviseresponse = new ServiceResponse<List<GetProductDTO>>();
            serviseresponse.Data = produqtebi;
            serviseresponse.Success = true;
            serviseresponse.Massage = "warmaebulia";
            return serviseresponse;
        }

        public Task<ServiceResponse<UpdateProductDTO>> UpdateProduct(UpdateProductDTO UpdateProductDTO)
        {
            throw new NotImplementedException();
        }
    }
}
