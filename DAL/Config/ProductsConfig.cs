using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Config
{
    public class ProductsConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x=>x.Price).IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}
