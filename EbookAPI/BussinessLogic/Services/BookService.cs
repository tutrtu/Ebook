using System.Collections.Generic;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BussinessLogic.DTOs;
using EbookAPI.DataAccess.Entites;

using EbookAPI.DataAccess.Interfaces;

namespace EbookAPI.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            var bookDtos = new List<BookDto>();
            foreach (var book in books)
            {
                bookDtos.Add(new BookDto
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Type = book.Type,
                    PubId = book.PubId,
                    Price = book.Price,
                    Advance = book.Advance,
                    Royalty = book.Royalty,
                    YtdSales = book.YtdSales,
                    Notes = book.Notes,
                    PublishedDate = book.PublishedDate
                });
            }
            return bookDtos;
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return null;

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Type = book.Type,
                PubId = book.PubId,
                Price = book.Price,
                Advance = book.Advance,
                Royalty = book.Royalty,
                YtdSales = book.YtdSales,
                Notes = book.Notes,
                PublishedDate = book.PublishedDate
            };
        }

        public async Task<BookDto> AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Type = bookDto.Type,
                PubId = bookDto.PubId,
                Price = bookDto.Price,
                Advance = bookDto.Advance,
                Royalty = bookDto.Royalty,
                YtdSales = bookDto.YtdSales,
                Notes = bookDto.Notes,
                PublishedDate = bookDto.PublishedDate
            };

            var addedBook = await _bookRepository.AddBook(book);
            return new BookDto
            {
                BookId = addedBook.BookId,
                Title = addedBook.Title,
                Type = addedBook.Type,
                PubId = addedBook.PubId,
                Price = addedBook.Price,
                Advance = addedBook.Advance,
                Royalty = addedBook.Royalty,
                YtdSales = addedBook.YtdSales,
                Notes = addedBook.Notes,
                PublishedDate = addedBook.PublishedDate
            };
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }

        public async Task<BookDto> UpdateBook(int id, BookDto updatedBookDto)
        {
            // Retrieve the existing book by ID
            var existingBook = await _bookRepository.GetBookById(id);
            if (existingBook == null)
            {
                // Book with the specified ID not found
                return null;
            }

            // Update the properties of the existing book with the values from the updated book DTO
            existingBook.Title = updatedBookDto.Title;
            existingBook.Type = updatedBookDto.Type;
            existingBook.PubId = updatedBookDto.PubId;
            existingBook.Price = updatedBookDto.Price;
            existingBook.Advance = updatedBookDto.Advance;
            existingBook.Royalty = updatedBookDto.Royalty;
            existingBook.YtdSales = updatedBookDto.YtdSales;
            existingBook.Notes = updatedBookDto.Notes;
            existingBook.PublishedDate = updatedBookDto.PublishedDate;

            // Update the book in the repository
            var updatedBook = await _bookRepository.UpdateBook(id, existingBook);

            // If the update was successful, return the updated book DTO
            if (updatedBook != null)
            {
                return new BookDto
                {
                    BookId = updatedBook.BookId,
                    Title = updatedBook.Title,
                    Type = updatedBook.Type,
                    PubId = updatedBook.PubId,
                    Price = updatedBook.Price,
                    Advance = updatedBook.Advance,
                    Royalty = updatedBook.Royalty,
                    YtdSales = updatedBook.YtdSales,
                    Notes = updatedBook.Notes,
                    PublishedDate = updatedBook.PublishedDate
                };
            }

            // Return null or handle the case where the update failed
            return null;
        }

    }
}
