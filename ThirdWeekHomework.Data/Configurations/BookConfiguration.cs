using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.BookName).IsRequired();
            builder.Property(p => p.BookName).HasMaxLength(100);
            builder.HasKey(p => p.Id);
            builder.ToTable("Books");
        }
    }
}
