using DAL.Common.Dto;
using Domain.Db;

namespace DAL.Services.Product.Common.RemoveProduct
{
    public class DeleteProduct : IDeleteProduct
    {
        private readonly DataBaseContext _context;
        public DeleteProduct(DataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long id)
        {
            var product = _context.products.Find(id);

            _context.products.Remove(product);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت حذف شد"
            };
        }
    }
}
