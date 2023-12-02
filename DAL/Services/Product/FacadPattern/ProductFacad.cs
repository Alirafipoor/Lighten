using DAL.Db.FacadPattern;
using DAL.Services.Product.Common.AddNewProduct;
using DAL.Services.Product.Common.EditProduct;
using DAL.Services.Product.Common.RemoveProduct;
using DAL.Services.Product.Queries.GetAllProducts;
using Domain.Db;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Product.FacadPattern
{
    public  class ProductFacad:IProductFacad
    {
        private readonly DataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(DataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IAddNewProductService addNewProductService;
        public IAddNewProductService AddNewProductService
        {
            get
            {
                return addNewProductService = addNewProductService ?? new  AddnewProductService(_context,_environment);
            }
        }

        private IGetAllProduct _getallProduct;
        public IGetAllProduct GetAllProduct
        {
            get
            {
                return _getallProduct = _getallProduct ?? new GetAllProduct(_context);
            }
        }

        private IEditProduct _editproduct;
        public IEditProduct EditProduct
        {
            get
            {
                return _editproduct=_editproduct ?? new EditProduct(_context);
            }
        }

        private IDeleteProduct _deleteProduct;
        public IDeleteProduct DeleteProduct
        {
            get
            {
                return _deleteProduct=_deleteProduct ?? new DeleteProduct(_context);
            }
        }
    }
}
