using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.Models;
using EbookAPI.BusinessLogic.Services;
using EbookAPI.BussinessLogic.DTOs;

namespace EbookAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GettAllBook()
        {
            var booklist = await _bookService.GetAllBooks();
            if (booklist == null)
                return NotFound(new { message = "booklist not found" });

            return Ok(booklist);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var booklist = await _bookService.GetBookById(id);
            if (booklist == null)
                return NotFound(new { message = "booklist not found" });

            return Ok(booklist);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Book data is null.");
            }

            var addedBook = await _bookService.AddBook(bookDto);
            return Ok(addedBook);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (!result)
                return NotFound(new { message = "Book not found" });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto updatedBookDto)
        {
            if (updatedBookDto == null)
            {
                return BadRequest("Updated book data is null.");
            }

            var existingBook = await _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound(new { message = "Book not found." });
            }

            updatedBookDto.BookId = id; // Ensure the ID in the DTO matches the ID in the route

            var updatedBook = await _bookService.UpdateBook(id, updatedBookDto);
            if (updatedBook == null)
            {
                return BadRequest(new { message = "Failed to update book." });
            }

            return Ok(updatedBook);
        }


    }

}
