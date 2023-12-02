using DAL.Common.Dto;
using Domain.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Product.Common.EditProduct
{
    public  interface IEditProduct
    {
        ResultDto Execute(string name, long price, long id);
    }

    public class EditProduct : IEditProduct
    {
        private readonly DataBaseContext _context;
        public EditProduct(DataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(string name, long price,long id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return new ResultDto
                {
                    Message = "چنین محصولی وجود ندارد",
                    IsSuccess = false
                };
            }
            product.Price = price;
            product.Name = name;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "تغییرات با موفقیت انجام شد"
            };

        }
    }
}
