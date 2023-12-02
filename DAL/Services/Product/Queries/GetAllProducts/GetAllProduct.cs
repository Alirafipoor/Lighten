using DAL.Common.Dto;
using Domain.Db;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services.Product.Queries.GetAllProducts
{
    public class GetAllProduct : IGetAllProduct
    {
        private readonly DataBaseContext _context;
        public GetAllProduct(DataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<ProductDto>> Execute()
        {
            var product = _context.products.ToList().Select(x => new ProductDto
            {
                Name = x.Name,
                Price = x.Price,
                Id= x.Id,
                
                  
            }).ToList();

            return new ResultDto<List<ProductDto>>()
            {
                Data = product,
                IsSuccess = true
            };
        }
    }
}
