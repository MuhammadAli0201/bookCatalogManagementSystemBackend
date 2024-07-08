using BookCatalogManagementSystemBackend.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.DAL.Config
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired(true);
            builder.Property(b => b.PublicationYear).IsRequired(true);
            builder.Property(b => b.ISBN).IsRequired(true);
            builder.Property(b => b.Genre).IsRequired(true);
            builder.Property(b => b.TotalPages).IsRequired(true);

            builder.HasMany(b => b.Chapters).WithOne(c => c.Book).HasForeignKey(c => c.BookId);
            builder.HasMany(b => b.Tags).WithOne(t => t.Book).HasForeignKey(t => t.BookId);
        }
    }
}
