using EbookWEB.Service;
using Microsoft.AspNetCore.Mvc;
using EbookWEB.Models;

namespace EbookWEB.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IActionResult> Index(int? searchId)
        {
            List<AuthorDto> authors;
            if (searchId.HasValue)
            {
                var author = await _authorService.GetAuthorByIdAsync(searchId.Value);
                authors = author != null ? new List<AuthorDto> { author } : new List<AuthorDto>();
            }
            else
            {
                authors = await _authorService.GetAuthorsAsync();
            }
            return View(authors);
        }
    }
}
