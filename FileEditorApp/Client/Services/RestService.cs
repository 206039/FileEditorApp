using FileEditorApp.Shared.Commands;
using FileEditorApp.Shared.Events;
using FileEditorApp.Shared.Extrensions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileEditorApp.Client.Services
{
    public class RestService
    {
        private readonly HttpClient _httpClient;
        public RestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEvent> Execute<T>(HttpMethod method,string url, ICommand command, string token=null) where T : IEvent
        {
            var json = JsonConvert.SerializeObject(command);
            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url, UriKind.Relative),
                Content = content,
                Method = method
            };
            if(token!=null)
            {
                request.Headers.Add("authorization", $"Bearer {token}");
            }
            var response = await _httpClient.SendAsync(request);
            if(response.StatusCode==HttpStatusCode.InternalServerError)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
            else if(response.StatusCode==HttpStatusCode.Unauthorized)
            {
                return new UnauthorizedEvent();
            }
            else if(response.StatusCode==HttpStatusCode.BadRequest)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BadRequestEvent>(jsonResponse);
            }   
            else
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if(jsonResponse.IsNullOrEmpty())
                {
                    return new SuccessEvent { StatusCode=(int)response.StatusCode };
                }

                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            
        }
    }
}
