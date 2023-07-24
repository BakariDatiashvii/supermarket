using AutoMapper;
using supermarket.DBcontext;
using supermarket.EntityModel;
using supermarket.ProductDTO;
using supermarket.SupermarketiDTO;
using System.Collections.Generic;

namespace supermarket.SupermarketServise
{
    public class SupermarketServise : ISupermarketServise
    {
        private readonly SupermarketProductDBcontext _conetxt;

        public readonly IMapper _mapper;
        public SupermarketServise(SupermarketProductDBcontext context, IMapper mapper)
        {
            _conetxt = context;
            _mapper = mapper;
        }

       
        public async Task<ServiceResponse<AddSupermarketDTO>> AddSupermarket(AddSupermarketDTO addsupermarketdto)
        {
            var supermarketi = new Supermarket()
            {
                Id = addsupermarketdto.Id,
                Name = addsupermarketdto.Name,
                Description = addsupermarketdto.Description
            };
            _conetxt.supermarkets.Add(supermarketi);
            _conetxt.SaveChanges();
            var addsupermarket = new AddSupermarketDTO()
            {
                Id = supermarketi.Id,
                Name = supermarketi.Name,
                Description = supermarketi.Description

            };

            var serviseresponse = new ServiceResponse<AddSupermarketDTO>();
            serviseresponse.Data = addsupermarket;
            serviseresponse.Success = true;
            serviseresponse.Massage = "warmaebulia";
            return serviseresponse;

        }

        public async Task<ServiceResponse<GetSupermarketDTO>> DeleteSupermarkets(int Id)
        {
            var supermarketi = _conetxt.supermarkets
                .Include(x => x.Porductebi)
                .FirstOrDefault(z=> z.Id == Id);


            var supermarkets = new GetSupermarketDTO()
            {
                Id = supermarketi.Id,
                Name = supermarketi.Name,
                Description = supermarketi.Description,
                addSupermarketDTOs = supermarketi.Porductebi.Select(x => new AddProductDTO()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    ProductDescription = x.ProductDescription,
                    SupermarketId = x.SupermarketId

                }).ToList(),
                
            };

            foreach (var item in supermarketi.Porductebi)
            {
                _conetxt.products.Remove(item);
                

            }

            _conetxt.supermarkets.Remove(supermarketi);
            
            _conetxt.SaveChanges();


            var servise = new ServiceResponse<GetSupermarketDTO>();
            servise.Data = supermarkets;
            servise.Success = true;

            return servise;

        }




        public async Task<ServiceResponse<GetSupermarketDTO>> GetSupermarket(int Id)
        {
            // ინქლუდით და მაპერით 

            var supermarketi = _conetxt.supermarkets
                .Include(x => x.Porductebi)
                .FirstOrDefault(x => x.Id == Id);

            var supermarketmap = _mapper.Map<GetSupermarketDTO>(supermarketi);
            supermarketmap.addSupermarketDTOs = _mapper.Map<List<AddProductDTO>>(supermarketi.Porductebi);

            var serviserespons = new ServiceResponse<GetSupermarketDTO>();
            serviserespons.Data = supermarketmap;

            return serviserespons;

            // მაპერის გარეშე ხელით გაწერა

            //var supermarketi = _conetxt.supermarkets
            //    .Include(x => x.Porductebi)
            //    .FirstOrDefault(x => x.Id == Id);

            //var supermarkets = new GetSupermarketDTO()
            //{
            //    Id = supermarketi.Id,
            //    Name = supermarketi.Name,
            //    Description = supermarketi.Description,
            //    addSupermarketDTOs = supermarketi.Porductebi.Select(x => new AddProductDTO()
            //    {
            //        ProductId = x.ProductId,
            //        ProductName = x.ProductName,
            //        ProductPrice = x.ProductPrice,
            //        ProductDescription = x.ProductDescription,
            //        SupermarketId = x.SupermarketId

            //    }).ToList(),

            //};


            //var serviserespons = new ServiceResponse<GetSupermarketDTO>();
            //serviserespons.Data = supermarkets;

            //return serviserespons;



        }

        public async Task<ServiceResponse<List<GetSupermarketDTO>>> GetSupermarkets()
        {
            // new mwthod
            var marketi = _conetxt.supermarkets.Include(x => x.Porductebi)
                .Select(x => _mapper.Map<GetSupermarketDTO>(x)).ToList();

            var produqti = _conetxt.products.Include(x => x.Supermarketi)
                .Select(x => _mapper.Map<AddProductDTO>(x)).ToList();

            foreach (var item in marketi)
            {
                item.addSupermarketDTOs = produqti.Where(x=> x.SupermarketId == item.Id).ToList();
            }


            //var marketi = _conetxt.supermarkets.Include(x => x.Porductebi)
            //    .Select(x => _mapper.Map<GetSupermarketDTO>(x.Porductebi
            //    .Select(z => _mapper.Map<AddProductDTO>(z)))).ToList();


            var serviceResponse = new ServiceResponse<List<GetSupermarketDTO>>();
            serviceResponse.Success = true;
            serviceResponse.Data = marketi;
            return serviceResponse;

            //// მაპერით ვავსებთ DTO ინქლუდის გარეშე ხელით

            //var supermarkets = _conetxt.supermarkets.ToList();

            //var produqti = _conetxt.products.ToList();

            //var mappedSupermarkets = _mapper.Map<List<GetSupermarketDTO>>(supermarkets);

            //var mappedProducts = _mapper.Map<List<AddProductDTO>>(produqti);

            //foreach (var item in mappedSupermarkets)
            //{
            //    item.addSupermarketDTOs = mappedProducts
            //        .Where(x => x.SupermarketId == item.Id)
            //        .Select(z => _mapper
            //        .Map<AddProductDTO>(z))
            //        .ToList();
            //}

            //var serviceResponse = new ServiceResponse<List<GetSupermarketDTO>>();
            //serviceResponse.Success = true;
            //serviceResponse.Data = mappedSupermarkets;
            //return serviceResponse;

            //// აქ ხელით ვუტოლებთ DTO - ს

            //var supermaketebi = _conetxt.supermarkets.Select(x => new GetSupermarketDTO()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    addSupermarketDTOs = new List<AddProductDTO>()

            //}).ToList();

            //foreach (var item in supermaketebi)
            //{
            //    item.addSupermarketDTOs = _conetxt.products.Where(x => x.SupermarketId == item.Id).Select(z => new AddProductDTO()
            //    {
            //        ProductId = z.ProductId,
            //        ProductName = z.ProductName,
            //        ProductPrice = z.ProductPrice,
            //        ProductDescription = z.ProductDescription,
            //        SupermarketId = z.SupermarketId

            //    }).ToList();
            //}

            //var servise = new ServiceResponse<List<GetSupermarketDTO>>();
            //servise.Success = true;
            //servise.Data = supermaketebi;
            //return  servise;
        }

        public Task<ServiceResponse<UpdateSupermarketDTO>> UpdateSupermarket(UpdateSupermarketDTO Updatesupermarketdto)
        {
            throw new NotImplementedException();
        }
    }
}
