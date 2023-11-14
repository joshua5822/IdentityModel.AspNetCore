using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json.Linq;

namespace RazorWebApplication.Pages
{
    public class CallApiAsClientTypedModel : PageModel
    {
        public string Json = string.Empty;

        public async Task OnGet([FromServices] TypedClientClient client)
        {
            string response = await client.CallApi();
            Json = JArray.Parse(response).ToString();
        }
    }
}
