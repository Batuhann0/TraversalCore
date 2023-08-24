using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TraversalCore.Areas.Admin.Models;

namespace TraversalCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]")]

    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region Ziyaretçi Listeleme
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:48661/api/Visitor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                //DeserializeObject, Json formatında olan string'i bir object'e çevirir. 
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View();
        } 
        #endregion

        #region Api ile Ziyaretçi Ekleme
        [HttpGet]
        public IActionResult CreateVisitor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitor(VisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            //SerializeObject ise bir object'i Json türünde bir string degere çevirir.
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:48661/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        } 
        #endregion
    }
}
