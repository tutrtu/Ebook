using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BussinessLogic.DTOs;


namespace EbookAPI.BusinessLogic.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooks();
        Task<BookDto> GetBookById(int id);
        Task<BookDto> AddBook(BookDto bookDto);
        Task<BookDto> UpdateBook(int id, BookDto bookDto);
        Task<bool> DeleteBook(int id);
    }
}
