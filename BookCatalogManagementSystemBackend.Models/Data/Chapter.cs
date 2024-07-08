using BookCatalogManagementSystemBackend.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.Models.Data
{
    public class Chapter
    {
        public Guid Id { get; set; }
        public int ChapterNo { get; set; }
        public string Title { get; set; } 
        public int PageCount { get; set; }
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public ChapterDTO MapModelToDTO()
        {
            return new ChapterDTO
            {
                Id = this.Id,
                ChapterNo = this.ChapterNo,
                Title = this.Title,
                PageCount = this.PageCount,
                BookId = this.BookId,
            };
        }

    }
}
