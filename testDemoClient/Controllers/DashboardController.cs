using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using testDemoClient.Models;

namespace testDemoClient.Controllers
{
    public class DashboardController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<List<Dashboard>> Dashboards()
        {
            var response = await _httpClient.GetAsync("http://localhost:51933/api/dashboard");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<Dashboard>>(content);
                return val;
            }
            return null;
        }

        public ActionResult Dashboard()
        {
            IEnumerable<Dashboard> dashboards = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9001/api/");
                //HTTP GET
                var responseTask = client.GetAsync("dashboard");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Dashboard>>();
                    readTask.Wait();
                    dashboards = readTask.Result;
                }
            }
            return View(dashboards);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
