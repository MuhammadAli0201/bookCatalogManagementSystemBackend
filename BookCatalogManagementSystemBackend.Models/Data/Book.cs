using BookCatalogManagementSystemBackend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.Models.Data
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationYear { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public int TotalPages { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Chapter> Chapters { get; set; }

        public BookDTO MapModelToDTO()
        {
            return new BookDTO
            {
                Id = Id,
                Title = Title,
                Author = Author,
                PublicationYear = PublicationYear,
                ISBN = ISBN,
                Genre = Genre,
                TotalPages = TotalPages,
                Tags = this.Tags != null ? this.Tags.Select(t => t.MapModelToDTO()).ToList() : null,
                Chapters = this.Chapters != null ? this.Chapters.Select(t => t.MapModelToDTO()).ToList() : null,
            };
        }

    }
}
