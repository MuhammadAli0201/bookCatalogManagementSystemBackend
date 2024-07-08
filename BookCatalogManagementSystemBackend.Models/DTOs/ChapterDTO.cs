using BookCatalogManagementSystemBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.Models.DTO
{
    public class ChapterDTO
    {
        public Guid Id { get; set; }
        public int ChapterNo { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public Guid BookId { get; set; }

        public Chapter MapDTOToModel()
        {
            return new Chapter
            {
                Id=this.Id,
                ChapterNo=this.ChapterNo,
                Title=this.Title,
                PageCount=this.PageCount,
                BookId=this.BookId,
            };
        }
    }
}
