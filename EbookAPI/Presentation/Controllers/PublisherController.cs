using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BusinessLogic.DTOs;
using EbookAPI.BussinessLogic.DTOs;

namespace EbookAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publisherList = await _publisherService.GetAllPublishers();
            if (publisherList == null)
                return NotFound(new { message = "publisherList not found" });

            return Ok(publisherList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var publisher = await _publisherService.GetPublisherById(id);
            if (publisher == null)
                return NotFound(new { message = "Publisher not found" });

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher([FromBody] PublisherDto publisherDto)
        {
            if (publisherDto == null)
            {
                return BadRequest("Publisher data is null.");
            }

            var addedPublisher = await _publisherService.AddPublisher(publisherDto);
            return Ok(addedPublisher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var result = await _publisherService.DeletePublisher(id);
            if (!result)
                return NotFound(new { message = "Publisher not found" });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, [FromBody] PublisherDto updatedPublisherDto)
        {
            if (updatedPublisherDto == null)
            {
                return BadRequest("Updated publisher data is null.");
            }

            var existingPublisher = await _publisherService.GetPublisherById(id);
            if (existingPublisher == null)
            {
                return NotFound(new { message = "Publisher not found." });
            }

            updatedPublisherDto.PubId = id; // Ensure the ID in the DTO matches the ID in the route

            var updatedPublisher = await _publisherService.UpdatePublisher(id, updatedPublisherDto);
            if (updatedPublisher == null)
            {
                return BadRequest(new { message = "Failed to update publisher." });
            }

            return Ok(updatedPublisher);
        }
    }
}
