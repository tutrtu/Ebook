using System.Collections.Generic;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BussinessLogic.DTOs;
using EbookAPI.DataAccess.Entites;
using EbookAPI.DataAccess.Interfaces;

namespace EbookAPI.BusinessLogic.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<IEnumerable<PublisherDto>> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublisher();
            var publisherDtos = new List<PublisherDto>();
            foreach (var publisher in publishers)
            {
                publisherDtos.Add(new PublisherDto
                {
                    PubId = publisher.PubId,
                    PublisherName = publisher.PublisherName,
                     
                    City = publisher.City,
                    State = publisher.State,
                    Country = publisher.Country
                   
                });
            }
            return publisherDtos;
        }

        public async Task<PublisherDto> GetPublisherById(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if (publisher == null)
                return null;

            return new PublisherDto
            {
                PubId = publisher.PubId,
                PublisherName = publisher.PublisherName,

                City = publisher.City,
                State = publisher.State,
                Country = publisher.Country

            };
        }

        public async Task<PublisherDto> AddPublisher(PublisherDto publisherDto)
        {
            var publisher = new Publisher
            {
                
                PublisherName = publisherDto.PublisherName,
               
                City = publisherDto.City,
                State = publisherDto.State,
                Country = publisherDto.Country
                
            };

            var addedPublisher = await _publisherRepository.AddPublisher(publisher);
            return new PublisherDto
            {
                PubId = addedPublisher.PubId,
                PublisherName = addedPublisher.PublisherName,
              
                City = addedPublisher.City,
                State = addedPublisher.State,
                Country = addedPublisher.Country
               
            };
        }

        public async Task<PublisherDto> UpdatePublisher(int id, PublisherDto publisherDto)
        {
            var publisher = new Publisher
            {
                PubId = id,
                PublisherName = publisherDto.PublisherName,

                City = publisherDto.City,
                State = publisherDto.State,
                Country = publisherDto.Country
            };

            var updatedPublisher = await _publisherRepository.UpdatePublisher(id, publisher);
            if (updatedPublisher == null)
                return null;

            return new PublisherDto
            {
                
                PublisherName = updatedPublisher.PublisherName,
                
                City = updatedPublisher.City,
                State = updatedPublisher.State,
                Country = updatedPublisher.Country
                
            };
        }

        public async Task<bool> DeletePublisher(int id)
        {
            return await _publisherRepository.DeletePublisher(id);
        }
    }
}
