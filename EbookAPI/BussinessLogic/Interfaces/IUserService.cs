using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;


namespace EbookAPI.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
