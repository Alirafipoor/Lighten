using Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Products : BaseEntity<long>
    {
      
        public string Name { get; set; }
        public long Price { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
       
    }
}
