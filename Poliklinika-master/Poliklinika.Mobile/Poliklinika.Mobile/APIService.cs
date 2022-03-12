using Poliklinika.Mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;

namespace Poliklinika.Mobile
{
    class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }
#if DEBUG
        private string _apiUrl = "http://localhost:53943/api";
#endif
#if RELEASE
        private string _apiUrl = "http://mywebsite.com/api/";
#endif
        public async Task<T> Get<T>(object search)
        {

            var result = $"{_apiUrl}/{_route}";

            if (search != null)
            {
                result += "?";
                result += await search.ToQueryString();
            }
            return await result.WithBasicAuth(Username, Password).GetJsonAsync<T>();

        }
        public async Task<T> GetById<T>(object id)
        {
            var result = $"{_apiUrl}/{_route}/{id}";

            return await result.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var result = $"{_apiUrl}/{_route}";

            return await result.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object request)
        {
            var result = $"{_apiUrl}/{_route}";

            return await result.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Delete<T>(object id)
        {
            var result = $"{_apiUrl}/{_route}/{id}";

            return await result.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
        }

        public async void UpdatePassword<T>(object request)
        {
            var result = $"{_apiUrl}/{_route}/update-password";

            await result.WithBasicAuth(Username, Password).PostJsonAsync(request);
        }
    }
}

