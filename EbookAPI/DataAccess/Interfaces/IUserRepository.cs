using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;


namespace EbookAPI.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
