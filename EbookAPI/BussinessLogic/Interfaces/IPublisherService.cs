using System.Collections.Generic;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BussinessLogic.DTOs;

namespace EbookAPI.BusinessLogic.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherDto>> GetAllPublishers();
        Task<PublisherDto> GetPublisherById(int id);
        Task<PublisherDto> AddPublisher(PublisherDto publisherDto);
        Task<PublisherDto> UpdatePublisher(int id, PublisherDto publisherDto);
        Task<bool> DeletePublisher(int id);
    }
}
