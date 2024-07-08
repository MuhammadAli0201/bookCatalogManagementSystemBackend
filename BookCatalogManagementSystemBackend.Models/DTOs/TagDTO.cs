using BookCatalogManagementSystemBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.Models.DTO
{
    public class TagDTO
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
        public Guid BookId { get; set; }        

        public Tag MapDTOToModel()
        {
            return new Tag{
                Id=this.Id,
                TagName=this.TagName,
                BookId=this.BookId,
            };
        }
    }
} 
