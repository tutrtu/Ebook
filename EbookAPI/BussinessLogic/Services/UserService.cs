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
                Password = user.Password,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Role = user.Role.RoleDesc
            };
        }

        public async Task<UserDto> RegisterUserAsync(UserDto newUser)
        {
            var existingUser = await _userRepository.GetUserByEmailAndPasswordAsync(newUser.EmailAddress, newUser.Password);
            if (existingUser != null)
            {
                // User with the same email already exists
                return null;
            }

            var user = new User
            {
                EmailAddress = newUser.EmailAddress,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                MiddleName = newUser.MiddleName,
                LastName = newUser.LastName,
                
                RoleId = 2
            };

            // Add the user to the repository
            var addedUser = await _userRepository.AddUserAsync(newUser.EmailAddress, newUser.Password);

            return new UserDto
            {
                UserId = newUser.UserId,
                EmailAddress = newUser.EmailAddress,
                Password = newUser.Password,
                FirstName = newUser.FirstName,
                MiddleName = newUser.MiddleName,
                LastName = newUser.LastName,
                Role = "User"
            };
        }


        private UserDto MapUserToDto(User user)
        {
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
     