using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BussinessLogic.DTOs;
using EbookAPI.DataAccess.Entites;

using EbookAPI.DataAccess.Interfaces;

namespace EbookAPI.BussinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthor()
        {
            var authors = await _authorRepository.GetAllAuthor();
            return authors.Select(author => new AuthorDto
            {
                AuthorId = author.AuthorId,
                LastName = author.LastName,
                FirstName = author.FirstName,
                Phone = author.Phone,
                Address = author.Address,
                City = author.City,
                State = author.State,
                Zip = author.Zip,
                EmailAddress = author.EmailAddress
            }).ToList();
        }

        public async Task<AuthorDto> GetAuthorById(int id)
        {
            var author = await _authorRepository.GetAuthorById(id);
            if (author == null)
                return null;

            return new AuthorDto
            {
                AuthorId = author.AuthorId,
                LastName = author.LastName,
                FirstName = author.FirstName,
                Phone = author.Phone,
                Address = author.Address,
                City = author.City,
                State = author.State,
                Zip = author.Zip,
                EmailAddress = author.EmailAddress
            };
        }

        public async Task<AuthorDto> AddAuthor(AuthorDto authorDto)
        {
            var author = new Author
            {
                LastName = authorDto.LastName,
                FirstName = authorDto.FirstName,
                Phone = authorDto.Phone,
                Address = authorDto.Address,
                City = authorDto.City,
                State = authorDto.State,
                Zip = authorDto.Zip,
                EmailAddress = authorDto.EmailAddress
            };

            var addedAuthor = await _authorRepository.AddAuthor(author);
            authorDto.AuthorId = addedAuthor.AuthorId;
            return authorDto;
        }

        public async Task<AuthorDto> UpdateAuthor(int id, AuthorDto authorDto)
        {
            var existingAuthor = await _authorRepository.GetAuthorById(id);
            if (existingAuthor == null)
                return null;

            existingAuthor.LastName = authorDto.LastName;
            existingAuthor.FirstName = authorDto.FirstName;
            existingAuthor.Phone = authorDto.Phone;
            existingAuthor.Address = authorDto.Address;
            existingAuthor.City = authorDto.City;
            existingAuthor.State = authorDto.State;
            existingAuthor.Zip = authorDto.Zip;
            existingAuthor.EmailAddress = authorDto.EmailAddress;

            var updatedAuthor = await _authorRepository.UpdateAuthor(id, existingAuthor);
            return new AuthorDto
            {
                AuthorId = updatedAuthor.AuthorId,
                LastName = updatedAuthor.LastName,
                FirstName = updatedAuthor.FirstName,
                Phone = updatedAuthor.Phone,
                Address = updatedAuthor.Address,
                City = updatedAuthor.City,
                State = updatedAuthor.State,
                Zip = updatedAuthor.Zip,
                EmailAddress = updatedAuthor.EmailAddress
            };
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            return await _authorRepository.DeleteAuthor(id);
        }
    }
}
