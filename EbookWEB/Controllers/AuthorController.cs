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

        private bool IsUserAuthenticated()
        {
            var userJson = HttpContext.Session.GetString("user");
            return !string.IsNullOrEmpty(userJson);
        }
        public async Task<IActionResult> Index(int? searchId)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToAction("Auth", "Account");
            }
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

        [HttpPost]
        public async Task<IActionResult> Authors(string fname, string lname, string email)
        {
            AuthorDto author = new AuthorDto
            {
                FirstName = fname,
                LastName = lname,
                EmailAddress = email
            };

            await _authorService.CreateAuthorAsync(author);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuthorDto author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            await _authorService.UpdateAuthorAsync(id, author);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return RedirectToAction("Index");
        }
    }
}
