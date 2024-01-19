﻿using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(
                customerId => customerId.Value, value => new CustomerId(value));

            builder.Property(c => c.Email).HasMaxLength(256);
            builder.Property(c => c.FirstName).HasMaxLength(256);
            builder.Property(c => c.LastName).HasMaxLength(256);

            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
