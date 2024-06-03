using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;


namespace EbookAPI.DataAccess.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthor();
        Task<Author> GetAuthorById(int id);
        Task<Author> AddAuthor(Author author);
        Task<Author> UpdateAuthor(int id, Author author);
        Task<bool> DeleteAuthor(int id);

    }
}
