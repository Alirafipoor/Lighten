using DAL.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Product.Common.RemoveProduct
{
    public  interface IDeleteProduct
    {
        ResultDto Execute(long id);
    }
}
