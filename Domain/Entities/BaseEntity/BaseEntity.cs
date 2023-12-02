using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BaseEntity
{
    public  class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime InsertTime { get; set; }=DateTime.Now;
        public bool IsRemove { get; set; }
    }
    public abstract class BaseEntity:BaseEntity<long> { }

}
