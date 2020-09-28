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
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<LoginRequest>> Logins()
        {
            var response = await _httpClient.GetAsync("http://localhost:51933/api/account/login");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<LoginRequest>>(content);
                return val;
            }
            return null;
        }

        public ActionResult ViewLogin()
        {
            IEnumerable<LoginRequest> loginRequests = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51933/api/");
                //HTTPGET
                var responseTask = client.GetAsync("account/login");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<LoginRequest>>();
                    readTask.Wait();
                    loginRequests = readTask.Result;
                }
                else
                {
                    loginRequests = Enumerable.Empty<LoginRequest>();
                    ModelState.AddModelError(string.Empty, "Login request not found.");
                }                
            }
            return View(loginRequests);
        }

        public ActionResult Login(LoginRequest loginRequest)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51933/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<LoginRequest>("account/login", loginRequest);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Please contact administrator.");
            return View(loginRequest);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
