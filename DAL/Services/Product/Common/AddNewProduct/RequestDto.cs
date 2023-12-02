using Microsoft.AspNetCore.Http;

namespace DAL.Services.Product.Common.AddNewProduct
{
    public class RequestDto
    {
        public string  Name { get; set; }
        public  long Price { get; set; }
    
    }
}
