using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tennisclub_UI
{
    public static class WebAPI
    {
        private const string BaseUrl = "https://localhost:44364/";

        public static readonly HttpClient Client = new HttpClient();

        public static async Task<T> Get<T>(string path) where T : class
        {
            var url = $"{BaseUrl}{path}";
            var response = await Client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T> Post<T, TUpdateDto>(string path, TUpdateDto item) 
            where T : class 
            where TUpdateDto : class
        {
            var url = $"{BaseUrl}{path}";
            var response = await Client.PostAsync(url , new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }        
    }
}
