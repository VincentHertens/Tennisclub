using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tennisclub_WPF
{
    public static class WebAPI
    {
        private const string BaseUrl = "https://localhost:44364/api/";

        public static readonly HttpClient Client = new HttpClient();

        public static async Task<T> Get<T>(string path) 
            where T : class
        {
            var url = $"{BaseUrl}{path}";
            var response = await Client.GetAsync(url);

            if (!response.IsSuccessStatusCode) 
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T> Post<T, TCreateDto>(string path, TCreateDto createDto)
            where T : class
            where TCreateDto : class
        {
            var url = $"{BaseUrl}{path}";
            var response = await Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(createDto), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode) 
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T> Put<T, TUpdateDto>(string path, TUpdateDto updateDto)
            where T : class
            where TUpdateDto : class
        {
            var url = $"{BaseUrl}{path}";
            var response = await Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(updateDto), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode) 
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task Delete(string path)
        {
            var url = $"{BaseUrl}{path}";
            await Client.DeleteAsync(url);

            //if (!response.IsSuccessStatusCode) return null;

            //var json = await response.Content.ReadAsStringAsync();

            //return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
