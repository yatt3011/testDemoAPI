using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using testDemoClient.Models;

namespace testDemoClient.Controllers
{
    public class PlatformwellController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        // GET: /Platform/GetPlatformwellActual
        public ActionResult GetPlatformwellActual()
        {
            IEnumerable<Platform> platforms = null;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51933/api/");
                //HTTP GET
                var responseTask = client.GetAsync("PlatformWell/GetPlatformWellActual");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Platform>>();
                    readTask.Wait();
                    platforms = readTask.Result;
                }
                else
                {
                    platforms = Enumerable.Empty<Platform>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(platforms);
        }

        // GET: /Platform/GetPlatformwellDummy
        public ActionResult GetPlatformwellDummy()
        {
            IEnumerable<PlatformDummy> platformDummies = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51933/api/");
                //HTTP GET
                var responseTask = client.GetAsync("PlatformWell/GetPlatformWellDummy");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<PlatformDummy>>();
                    readTask.Wait();
                    platformDummies = readTask.Result;
                }
                else
                {
                    platformDummies = Enumerable.Empty<PlatformDummy>();
                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(platformDummies);
        }

        public async Task<List<Platform>> GetPlatforms()
        {
            var response = await _httpClient.GetAsync("http://localhost:51933/api/platformwell/getplatformwellactual");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<Platform>>(content);
                return val;
            }
            return null;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
