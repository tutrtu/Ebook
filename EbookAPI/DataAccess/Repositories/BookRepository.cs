using System.Collections.Generic;
using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;

using EbookAPI.DataAccess.Interfaces;
using EbookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EbookAPI.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly eBookStoreContext _context;

        public BookRepository(eBookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Book> UpdateBook(int id, Book book)
        {
            // Retrieve the existing book from the database
            var existingBook = await _context.Books.FindAsync(id);

            // If the book with the specified ID doesn't exist, return null or throw an exception
            if (existingBook == null)
            {
                return null; // You can choose to return null or throw an exception here
            }

            // Update the properties of the existing book with the values from the provided book parameter
            existingBook.Title = book.Title;
            existingBook.Type = book.Type;
            existingBook.PubId = book.PubId;
            existingBook.Price = book.Price;
            existingBook.Advance = book.Advance;
            existingBook.Royalty = book.Royalty;
            existingBook.YtdSales = book.YtdSales;
            existingBook.Notes = book.Notes;
            existingBook.PublishedDate = book.PublishedDate;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated book
            return existingBook;
        }
    }
}
