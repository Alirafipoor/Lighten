using DAL.Common.Dto;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Product.Queries.GetAllProducts
{
    public interface IGetAllProduct
    {
        ResultDto<List<ProductDto>> Execute();
    }
}
