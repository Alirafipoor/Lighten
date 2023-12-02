using Domain.Entities.BaseEntity;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category:BaseEntity<long>
    {
       
        public string Name { get; set; }

        public virtual ICollection<Products> products { get; set; }
    }
}
