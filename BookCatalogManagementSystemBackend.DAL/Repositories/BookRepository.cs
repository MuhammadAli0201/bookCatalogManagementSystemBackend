using BookCatalogManagementSystemBackend.DAL.Interfaces;
using BookCatalogManagementSystemBackend.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogManagementSystemBackend.DAL.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDBContext _context;

        public BookRepository(AppDBContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public async override Task<List<Book>> Get()
        {
            try
            {
                var result = await _context.Books.Include(b => b.Chapters).Include(b => b.Tags).ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Book>> GetSearch(string query)
        {
            try
            {
                if(!String.IsNullOrEmpty(query))
                {
                    return await _context.Books.Include(b => b.Chapters).Include(b => b.Tags).Where(b => b.Title.ToLower().Contains(query) || b.Author.ToLower().Contains(query) || b.ISBN.ToLower().Contains(query)).ToListAsync();                    
                }
                else
                {
                    return await Get();
                }
            }
            catch
            {
                throw;
            }
        }

        public async override Task<Book> GetSingle(Guid id)
        {
            try
            {
                var result = await _context.Books.Include(b => b.Chapters).Include(b => b.Tags).FirstOrDefaultAsync(b => b.Id.Equals(id));
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
