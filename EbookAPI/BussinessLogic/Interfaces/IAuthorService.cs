using System.Collections.Generic;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BussinessLogic.DTOs;

namespace EbookAPI.BusinessLogic.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthor();
        Task<AuthorDto> GetAuthorById(int id);
        Task<AuthorDto> AddAuthor(AuthorDto authorDto);
        Task<AuthorDto> UpdateAuthor(int id, AuthorDto authorDto);
        Task<bool> DeleteAuthor(int id);
    }
}
