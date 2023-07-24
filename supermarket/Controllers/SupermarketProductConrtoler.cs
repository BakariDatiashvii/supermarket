using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using supermarket.DBcontext;
using supermarket.EntityModel;
using supermarket.EntityModelVM;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace supermarket.Controllers
{
    public class SupermarketProductConrtoler : ControllerBase
    {
        private readonly SupermarketProductDBcontext _conetxt;

        public SupermarketProductConrtoler(SupermarketProductDBcontext context)
        {
            _conetxt = context;
        }

       

        [HttpPost("supermarketis_sheqmna")]
        public ActionResult<bool> supermarketissheqmna (SupermarketVM sheqmna) // გადავეცით ბაზის მსგავსი კლასი
        {
            var supermarketi = new Supermarket()
            {
                Id = sheqmna.Id,
                Name = sheqmna.Name,
                Description = sheqmna.Description
            };
            _conetxt.supermarkets.Add(supermarketi);
            _conetxt.SaveChanges();
            return true;
        }

        [HttpPost("produqtebis_sheqmna")]
        public ActionResult<bool> produqtebissheqmna (ProductVM sheqmnapro)
        {
            var produqtebi = new Product()
            {
                ProductId = sheqmnapro.ProductId,
                ProductName = sheqmnapro.ProductName,
                ProductPrice = sheqmnapro.ProductPrice,
                ProductDescription = sheqmnapro.ProductDescription,
                SupermarketId = sheqmnapro.SupermarketId
            };
            _conetxt.products.Add(produqtebi); 
            _conetxt.SaveChanges();
            return true;

        }
        [HttpDelete("supermarketis-washla")] 
        public ActionResult<bool> supermarketiswashla (int deleteID)
        {
            var deletesup = _conetxt.supermarkets.FirstOrDefault(x => x.Id == deleteID);
            if (deletesup == null)
            {
                return false;
            }
            _conetxt.supermarkets.Remove(deletesup);
            _conetxt.SaveChanges();
            return true;
        }
        [HttpDelete("Productebis-washla")]
        public ActionResult<bool> poductebiswashla (int deleteproductID)
        {
            var deletepro = _conetxt.products.FirstOrDefault(x => x.ProductId == deleteproductID);
            if (deletepro == null)
            {
                return false;
            }
            _conetxt.products.Remove(deletepro);
            _conetxt.SaveChanges();
            return true;
        }
        [HttpPut("Update-supermarketi")]
        public ActionResult<bool> updatesupermarketi (int findID, SupermarketVM updatesupermarket)
        {
            var napovnimarkti = _conetxt.supermarkets.FirstOrDefault(x=> x.Id == findID);
            if (napovnimarkti == null)
            {
                return false;
            }

            napovnimarkti.Name = updatesupermarket.Name;
            napovnimarkti.Description = updatesupermarket.Description;
            _conetxt.supermarkets.Update(napovnimarkti);
            _conetxt.SaveChanges();
            return true;

        }
        [HttpPut("Update-product")]
        public ActionResult<bool> updateproduct (int findID, ProductVM updateproduct)
        {
            var naponviproduqti = _conetxt.products.FirstOrDefault(x=> x.ProductId == findID);
            if (naponviproduqti == null)
            {
                return false;
            }
            
            naponviproduqti.ProductName = updateproduct.ProductName;
            naponviproduqti.ProductPrice = updateproduct.ProductPrice;
            naponviproduqti.ProductDescription =    updateproduct.ProductDescription;
            naponviproduqti.SupermarketId = updateproduct.SupermarketId;
            _conetxt.products.Update(naponviproduqti);
            _conetxt.SaveChanges();
            return true;
        }
        [HttpGet("produqtis-povna-supermarketshi")]
        public ActionResult<ProductVM> produqtispovna (int findID)
        {
            var produqtisfind = _conetxt.products.FirstOrDefault(x=>x.ProductId == findID);

            if (produqtisfind == null)
            {
                return null;
            }
            var dasabrunebeliproduqti = new ProductVM()
            {
                ProductId = produqtisfind.ProductId,
                ProductName = produqtisfind.ProductName,
                ProductPrice = produqtisfind.ProductPrice,
                ProductDescription = produqtisfind.ProductDescription,
                SupermarketId = produqtisfind.SupermarketId,
                Supermarketi = new SupermarketVM()

            };

             var kavshirisup = _conetxt.supermarkets.FirstOrDefault(x=> x.Id == dasabrunebeliproduqti.SupermarketId);

            dasabrunebeliproduqti.Supermarketi.Id = kavshirisup.Id;
            dasabrunebeliproduqti.Supermarketi.Name = kavshirisup.Name;
            dasabrunebeliproduqti.Supermarketi.Description = kavshirisup.Description;

            return dasabrunebeliproduqti;
        }
        [HttpGet("supermarketshi-povna-produqtis")]
        public ActionResult<SupermarketVM> supermarketispovna(int supermarktID)
        {
            
            var povnasuper = _conetxt.supermarkets.FirstOrDefault(x => x.Id == supermarktID);
            if (povnasuper == null)
            {
                return null;
            }

            var shenaxvasupVM = new SupermarketVM()
            {
                Id = povnasuper.Id,
                Name = povnasuper.Name,
                Description = povnasuper.Description,
                Porductebi = new List<ProductVM>()
            };

            //var produqtisfind = _conetxt.products.Where(x=> x.SupermarketId == shenaxvasupVM.Id).Select(x=> new ProductVM()
            //{
            //    ProductId = x.ProductId,
            //    ProductName = x.ProductName,
            //    ProductPrice = x.ProductPrice,
            //    ProductDescription = x.ProductDescription,
            //    SupermarketId = x.SupermarketId
            //} ).ToList();



            //foreach (var product in produqtisfind)
            //{
            //    shenaxvasupVM.Porductebi.Add(product);
            //}

            // meore varianti
            shenaxvasupVM.Porductebi = _conetxt.products.Where(x=> x.SupermarketId == shenaxvasupVM.Id && x.ProductPrice > 2 ).Select(x=> new ProductVM()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductDescription = x.ProductDescription,
                SupermarketId = x.SupermarketId


            }).ToList();



            return shenaxvasupVM;
        }
        [HttpGet(" Yvela -supermarketshi-povna-produqtis")]

        public ActionResult <List<SupermarketVM>> supermarketispovna()
        {
            
            var z = _conetxt.supermarkets.Select(x => new SupermarketVM()
            {
                Id = x.Id,
                Name = x.Name,
                Description= x.Description,
                Porductebi= new List<ProductVM>()
            }).ToList();

            
            foreach (var item in z)
            {
               item.Porductebi = _conetxt.products.Where(x=> x.SupermarketId == item.Id).Select(x => new ProductVM()
               {
                   ProductId = x.ProductId,
                   ProductName = x.ProductName,
                   ProductPrice = x.ProductPrice,
                   ProductDescription = x.ProductDescription,
                   SupermarketId = x.SupermarketId



               }).ToList();
            }
            // while ვცადოთ ხვალ
            //var t = new List<SupermarketVM>();
            //int x = 0;
            //for (int i = 0; i < z.Count; i++)
            //{
            //    for (int j = 0; j < z[i].Porductebi.Count; j++)
            //    {
                    

            //        if (x > j)
            //        {
            //            t.Add(z[i]);
            //        }
            //        x++;
            //    }

            //}


            return z;



        }

    }
}

