using System.Net.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json.Linq;

namespace RazorWebApplication.Pages
{
    public class CallApiAsClientModel : PageModel
    {
        private readonly IHttpClientFactory httpClientFactory;

        public string Json = string.Empty;

        public CallApiAsClientModel(IHttpClientFactory httpClientFactory) 
            : base()
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task OnGet()
        {
            HttpClient client = httpClientFactory.CreateClient("client");

            string response = await client.GetStringAsync("test");
            Json = JArray.Parse(response).ToString();
        }
    }
}
