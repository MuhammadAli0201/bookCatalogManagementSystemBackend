using BookCatalogManagementSystemBackend.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.Models.Data
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public TagDTO MapModelToDTO()
        {
            return new TagDTO
            {
                Id = this.Id,
                TagName = this.TagName,
                BookId = this.BookId,
            };
        }
    }
} 
