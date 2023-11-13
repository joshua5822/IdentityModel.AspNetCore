using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

namespace MvcCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TypedClientClient client2;

        public HomeController(IHttpClientFactory httpClientFactory, TypedClientClient client)
        {
            _httpClientFactory = httpClientFactory;
            client2 = client;
        }

        [AllowAnonymous]
        public IActionResult Index() => View();

        public IActionResult Secure() => View();

        public IActionResult Logout() => SignOut("cookie", "oidc");

        public async Task<IActionResult> CallApiAsUser()
        {
            HttpClient client = _httpClientFactory.CreateClient("user_client");

            string response = await client.GetStringAsync("test");
            ViewBag.Json = JArray.Parse(response).ToString();

            return View("CallApi");
        }

        public async Task<IActionResult> CallApiAsUserTyped([FromServices] TypedUserClient client)
        {
            string response = await client.CallApi();
            ViewBag.Json = JArray.Parse(response).ToString();

            return View("CallApi");
        }

        [AllowAnonymous]
        public async Task<IActionResult> CallApiAsClient()
        {
            HttpClient client = _httpClientFactory.CreateClient("client");

            string response = await client.GetStringAsync("test");
            ViewBag.Json = JArray.Parse(response).ToString();

            return View("CallApi");
        }

        [AllowAnonymous]
        public async Task<IActionResult> CallApiAsClientTyped([FromServices] TypedClientClient client)
        {
            string response = await client.CallApi();
            ViewBag.Json = JArray.Parse(response).ToString();

            return View("CallApi");
        }

        public async Task<IActionResult> CallApiAsConstructedClientTyped()
        {
            string response = await client2.CallApi();
            ViewBag.Json = JArray.Parse(response).ToString();

            return View("CallApi");
        }
    }
}