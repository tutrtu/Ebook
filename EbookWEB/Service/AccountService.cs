using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EbookAPI.BussinessLogic.DTOs;
using EbookAPI.BusinessLogic.DTOs;

namespace EbookWEB.Service
{
    public class AccountService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiUrl = "http://localhost:5100/api/User/getUserByEmailAndPassword";
        }

        public async Task<UserDto> GetAccountByEmailAndPassword(string email, string password)
        {
            // Prepare query string parameters
            var queryString = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password }
            };

            // Format query string
            var queryStringParams = new FormUrlEncodedContent(queryString);

            // Send request with query string
            HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl + "?" + queryStringParams);
            
            string responseData = await response.Content.ReadAsStringAsync();
            UserDto account = JsonConvert.DeserializeObject<UserDto>(responseData);
            return account;
        }
    }
}
