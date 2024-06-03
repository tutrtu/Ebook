using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BussinessLogic.DTOs;

namespace EbookAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            var authorList = await _authorService.GetAllAuthor();
            if (authorList == null)
                return NotFound(new { message = "Author list not found" });

            return Ok(authorList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorById(id);
            if (author == null)
                return NotFound(new { message = "Author not found" });

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorDto authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest("Author data is null.");
            }

            var addedAuthor = await _authorService.AddAuthor(authorDto);
            return Ok(addedAuthor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthor(id);
            if (!result)
                return NotFound(new { message = "Author not found" });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDto updatedAuthorDto)
        {
            if (updatedAuthorDto == null)
            {
                return BadRequest("Updated author data is null.");
            }

            var existingAuthor = await _authorService.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound(new { message = "Author not found." });
            }

            updatedAuthorDto.AuthorId = id; // Ensure the ID in the DTO matches the ID in the route

            var updatedAuthor = await _authorService.UpdateAuthor(id, updatedAuthorDto);
            if (updatedAuthor == null)
            {
                return BadRequest(new { message = "Failed to update author." });
            }

            return Ok(updatedAuthor);
        }
    }
}
