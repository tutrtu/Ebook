
using EbookWEB.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EbookWEB.Service
{
	public class PublisherService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiUrl;

		public PublisherService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_apiUrl = "http://localhost:5100/api/Publisher";
		}

		public async Task<List<PublisherDto>> GetPublishersAsync()
		{
			HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);
		
			string responseData = await response.Content.ReadAsStringAsync();
			List<PublisherDto> publisherDtos = JsonConvert.DeserializeObject<List<PublisherDto>>(responseData);

			return publisherDtos;
		}

		public async Task<PublisherDto> GetPublisherByIdAsync(int id)
		{
			HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
		
			string responseData = await response.Content.ReadAsStringAsync();
			PublisherDto publisherDto = JsonConvert.DeserializeObject<PublisherDto>(responseData);

			return publisherDto;
		}

		public async Task<PublisherDto> CreatePublisherAsync(PublisherDto publisher)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(publisher), Encoding.UTF8, "application/json");
			HttpResponseMessage response = await _httpClient.PostAsync(_apiUrl, content);
			
			string responseData = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<PublisherDto>(responseData);
		}

		public async Task<PublisherDto> UpdatePublisherAsync(int id, PublisherDto publisher)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(publisher), Encoding.UTF8, "application/json");
			HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}/{id}", content);
		
			string responseData = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<PublisherDto>(responseData);
		}

		public async Task DeletePublisherAsync(int id)
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
