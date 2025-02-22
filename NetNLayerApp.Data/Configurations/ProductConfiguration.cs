﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetNLayerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Data.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product> 
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); //bir bir artsin

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)"); //toplam 18 karakter olabilir max, virgulden sonra 2 karakter alabilecek max 

            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            //IsDeleted tanimlanmadi, zaten default olarak false degeri alacak.

            builder.ToTable("Products");
        }
    }
}
