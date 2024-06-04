using EbookWEB.Models;
using EbookWEB.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EbookWEB.Controllers
{
	public class PublisherController : Controller
	{
		private readonly PublisherService _publisherService;

		public PublisherController(PublisherService publisherService)
		{
			_publisherService = publisherService;
		}

		private bool IsUserAuthenticated()
		{
			var userJson = HttpContext.Session.GetString("user");
			return !string.IsNullOrEmpty(userJson);
		}

		public async Task<IActionResult> Index(int? searchId)
		{
			if (!IsUserAuthenticated())
			{
				return RedirectToAction("Auth", "Account");
			}

			List<PublisherDto> publishers;
			if (searchId.HasValue)
			{
				var publisher = await _publisherService.GetPublisherByIdAsync(searchId.Value);
				publishers = publisher != null ? new List<PublisherDto> { publisher } : new List<PublisherDto>();
			}
			else
			{
				publishers = await _publisherService.GetPublishersAsync();
			}

			return View(publishers);
		}

		[HttpPost]
		public async Task<IActionResult> Create(string name, string city, string state, string counntry)
		{
			PublisherDto publisher = new PublisherDto
			{
				PublisherName = name,
				City = city,
				State = state,
				Country = counntry
			};

			await _publisherService.CreatePublisherAsync(publisher);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var publisher = await _publisherService.GetPublisherByIdAsync(id);
			if (publisher == null)
			{
				return NotFound();
			}
			return View(publisher);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PublisherDto publisher)
		{
			if (id != publisher.PubId)
			{
				return BadRequest();
			}

			await _publisherService.UpdatePublisherAsync(id, publisher);
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _publisherService.DeletePublisherAsync(id);
			return RedirectToAction("Index");
		}
	}
}
