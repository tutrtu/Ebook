using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;


namespace EbookAPI.DataAccess.Interfaces
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllPublisher();
        Task<Publisher> GetPublisherById(int id);
        Task<Publisher> AddPublisher(Publisher publisher);
        Task<Publisher> UpdatePublisher(int id, Publisher publisher);
        Task<bool> DeletePublisher(int id);

    }
}
