using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;


namespace EbookAPI.DataAccess.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(int id, Book book);
        Task<bool> DeleteBook(int id);

    }
}
