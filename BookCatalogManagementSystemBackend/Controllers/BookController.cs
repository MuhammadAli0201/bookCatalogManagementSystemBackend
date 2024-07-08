using BookCatalogManagementSystemBackend.DAL.Interfaces;
using BookCatalogManagementSystemBackend.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalogManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.Get();
            return Ok(books);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string query)
        {
            var books = await _bookRepository.GetSearch(query);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BookDTO bookDTO)
        {
            var book = bookDTO.MapDTOToModel();
            if (book.Id == Guid.Empty)
                book = await _bookRepository.Add(book);
            else
                book = await _bookRepository.Update(book);

            if (book == null) return BadRequest();

            return Ok(book.MapModelToDTO());
        }
        
        [HttpDelete]
        public async Task<IActionResult> Index(Guid id)
        {
            var book = await _bookRepository.GetSingle(id);
            if (book == null) return NotFound();

            book = await _bookRepository.Delete(id);
            return Ok(book.MapModelToDTO());
        }
    }
}
