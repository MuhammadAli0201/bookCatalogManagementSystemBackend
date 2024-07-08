using BookCatalogManagementSystemBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.Models.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationYear { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public int TotalPages { get; set; }
        public List<TagDTO> Tags { get; set; }
        public List<ChapterDTO> Chapters { get; set; }

        public Book MapDTOToModel()
        {
            return new Book
            {
                Id = Id,
                Title = Title,
                Author = Author,
                PublicationYear = PublicationYear,
                ISBN = ISBN,
                Genre = Genre,
                TotalPages = TotalPages,
                Tags = this.Tags != null ? this.Tags.Select(t => t.MapDTOToModel()).ToList() : null,
                Chapters = this.Chapters != null ? this.Chapters.Select(t => t.MapDTOToModel()).ToList() : null,
            };
        }
       
    }
}
