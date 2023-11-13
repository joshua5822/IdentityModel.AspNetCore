using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MvcCode;

using Newtonsoft.Json.Linq;

namespace Web.Pages
{
    public class RazorCallApiModel : PageModel
    {
        public string Json = string.Empty;

        public async Task OnGet([FromServices] TypedUserClient client)
        {
            //await CallApiFromTypedClient(client);
            await CallApiFromTypedUser(client);
        }

        private async Task CallApiFromTypedClient(TypedClientClient client)
        {
            string response = await client.CallApi();
            Json = JArray.Parse(response).ToString();
        }

        private async Task CallApiFromTypedUser(TypedUserClient client)
        {
            string response = await client.CallApi();
            Json = JArray.Parse(response).ToString();
        }
    }
}
