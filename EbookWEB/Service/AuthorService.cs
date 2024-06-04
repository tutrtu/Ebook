using EbookAPI.DataAccess.Entites;
using EbookWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EbookWEB.Service
{
    public class AuthorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiUrl = "http://localhost:5100/api/Authors";
        }

        public async Task<List<AuthorDto>> GetAuthorsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            List<AuthorDto> authorDtos = JsonConvert.DeserializeObject<List<AuthorDto>>(responseData);

            return authorDtos;
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            AuthorDto authorDto = JsonConvert.DeserializeObject<AuthorDto>(responseData);

            return authorDto;
        }

        public async Task<AuthorDto> CreateAuthorAsync(AuthorDto author)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_apiUrl, content);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthorDto>(responseData);
        }

        public async Task<AuthorDto> UpdateAuthorAsync(int id, AuthorDto author)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}/{id}", content);
            response.EnsureSuccessStatusCode();
            string responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthorDto>(responseData);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

    }

}
