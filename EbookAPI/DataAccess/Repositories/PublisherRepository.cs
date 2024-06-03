using System.Collections.Generic;
using System.Threading.Tasks;
using EbookAPI.DataAccess.Entites;
using EbookAPI.DataAccess.Interfaces;
using EbookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EbookAPI.DataAccess.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly eBookStoreContext _context;

        public PublisherRepository(eBookStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAllPublisher()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task<Publisher> AddPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher> UpdatePublisher(int id, Publisher publisher)
        {
            var existingPublisher = await _context.Publishers.FindAsync(id);
            if (existingPublisher == null)
            {
                return null; // or throw an exception
            }

            // Update properties
            existingPublisher.PublisherName = publisher.PublisherName;
            existingPublisher.PublisherName = publisher.PublisherName;
            existingPublisher.City = publisher.City;
            existingPublisher.State = publisher.State;
            existingPublisher.Country = publisher.Country;
            

            await _context.SaveChangesAsync();
            return existingPublisher;
        }

        public async Task<bool> DeletePublisher(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return false;
            }

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
