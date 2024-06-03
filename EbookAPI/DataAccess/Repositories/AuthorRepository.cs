using System.Collections.Generic;
using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;
using EbookAPI.DataAccess.Interfaces;
using EbookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EbookAPI.DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly eBookStoreContext _context;

        public AuthorRepository(eBookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthor(int id, Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(id);

            if (existingAuthor == null)
            {
                return null; // Or throw an exception
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.Phone = author.Phone;
            existingAuthor.Address = author.Address;
            existingAuthor.City = author.City;
            existingAuthor.State = author.State;
            existingAuthor.Zip = author.Zip;
            existingAuthor.EmailAddress = author.EmailAddress;

            await _context.SaveChangesAsync();

            return existingAuthor;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
