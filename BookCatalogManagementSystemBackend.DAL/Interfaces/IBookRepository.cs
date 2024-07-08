using BookCatalogManagementSystemBackend.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.DAL.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        public Task<List<Book>> GetSearch(string query);
    }
}
