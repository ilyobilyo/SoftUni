using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReadApiDemo.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ReadApiDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private string baseUrl = "https://localhost:8080/api/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var recipeModel = new List<ProductModel>();

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var dataFromApi = await client.GetAsync("Product");

                if (dataFromApi.IsSuccessStatusCode)
                {
                    var results = dataFromApi.Content.ReadAsStringAsync().Result;

                    recipeModel = JsonConvert.DeserializeObject<List<ProductModel>>(results);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

            return View(recipeModel);
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductModel model)
		{
			if (!ModelState.IsValid)
			{
                return View();
			}

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var dataToApi = await client.PostAsJsonAsync("Product", model);

                if (dataToApi.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("_Error");
                }
            }

		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}