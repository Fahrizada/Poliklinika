using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http;
using Flurl;
using System.Threading.Tasks;
using PoliklinikaAPI.ViewModels;
using PoliklinikaAPI.Helpers;

namespace PoliklinikaDesktop
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private string _route=null;
        public APIService(string route)
        {
            _route = route;

            if(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                Username = "";
                Password = "";
            }
        }
        public async Task<T> Get<T>(object search)
        {

            var result = $"{Properties.Settings.Default.APIurl}/{_route}";

            if (search != null)
            {
                result += "?";
                result += await search.ToQueryString();
            }

            return await result.WithBasicAuth(Username, Password).GetJsonAsync<T>();

        }
        public async Task<T> GetById<T>(object id)
        {
            var result =  $"{Properties.Settings.Default.APIurl}/{_route}/{id}";

            return await result.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        
        public async Task<T> Insert<T>(object request)
        {
            var result = $"{Properties.Settings.Default.APIurl}/{_route}";

            return await result.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object request)
        {
            var result = $"{Properties.Settings.Default.APIurl}/{_route}";

            return await result.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Delete<T>(object id)
        {
            var result = $"{Properties.Settings.Default.APIurl}/{_route}/{id}";

            return await result.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
        }

        public async void UpdatePassword<T>(object request)
        {
            var result = $"{Properties.Settings.Default.APIurl}/{_route}/update-password";

            await result.WithBasicAuth(Username, Password).PostJsonAsync(request);
        }
    }
}
