using Azure.Core;
using DAL.Common.Dto;
using Domain.Db;
using Domain.Entities.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;

namespace DAL.Services.Product.Common.AddNewProduct
{
    public partial class AddnewProductService : IAddNewProductService
    {
        private readonly DataBaseContext _context;
        private readonly  IHostingEnvironment _environment;
        public AddnewProductService(DataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(RequestDto dto)
        {
            Products product = new Products()
            {
                Name = dto.Name,
                Price = dto.Price,
            };
            _context.products.Add(product);

            

            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت ثبت شد"
            };
        }
        
    }
}
