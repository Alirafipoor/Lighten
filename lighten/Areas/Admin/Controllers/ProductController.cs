using Azure.Core;
using DAL.Db.FacadPattern;
using DAL.Services.Product.Common.AddNewProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lighten.Areas.Admin.Controllers
{
    [Area("admin")]
   
    public class ProductController : Controller
    {
        
        private readonly IProductFacad _productfacad;
        public ProductController(IProductFacad productfacad)
        {
            _productfacad = productfacad;
        }
        
        public IActionResult Index()
        {

            return View(_productfacad.GetAllProduct.Execute().Data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(RequestDto dto)
        {
           
            return View(_productfacad.AddNewProductService.Execute(dto).Message);
        }
        [HttpPost]
        public IActionResult Edit(string name,long price,long id)
        {
            var message=_productfacad.EditProduct.Execute(name, price,id);
            return Json(message);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            
            return Json(_productfacad.DeleteProduct.Execute(id));
        }
    }
}
