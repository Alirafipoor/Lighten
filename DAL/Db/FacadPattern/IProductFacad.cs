using DAL.Services.Product.Common.AddNewProduct;
using DAL.Services.Product.Common.EditProduct;
using DAL.Services.Product.Common.RemoveProduct;
using DAL.Services.Product.Queries.GetAllProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Db.FacadPattern
{
    public  interface IProductFacad
    {
        IAddNewProductService AddNewProductService { get;  }
        IGetAllProduct GetAllProduct { get; }
        IEditProduct EditProduct { get; }
        IDeleteProduct DeleteProduct { get; }
    }
}
