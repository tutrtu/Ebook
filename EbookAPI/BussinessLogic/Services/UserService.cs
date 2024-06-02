using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.DataAccess.Interfaces;
using EbookAPI.DataAccess.Entites;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BusinessLogic.Interfaces;

namespace EbookAPI.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
                return null;

            return new UserDto
            {
                UserId = user.UserId,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Role = user.Role.RoleDesc
            };
        }
    }
}
