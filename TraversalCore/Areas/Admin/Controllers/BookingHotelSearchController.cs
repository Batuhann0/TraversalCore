using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TraversalCore.Areas.Admin.Models;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/properties/list-by-map?arrival_date=2023-09-15&departure_date=2023-09-20&room_qty=1&guest_qty=1&bbox=14.291283%2C14.948423%2C120.755688%2C121.136864&search_id=none&children_age=11%2C5&price_filter_currencycode=USD&categories_filter=class%3A%3A1%2Cclass%3A%3A2%2Cclass%3A%3A3&languagecode=en-us&travel_purpose=leisure&children_qty=2&order_by=popularity"),
                Headers =
    {
        { "X-RapidAPI-Key", "5ed620b542msh779a437d268921dp110c8djsnb56cbb50c79d" },
        { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelViewModel>(bodyReplace);
                return View(values.result);
            }         

        }
   

    [HttpGet]
    public IActionResult GetCityDestID()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetCityDestID(string p)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
            Headers =
    {
        { "X-RapidAPI-Key", "cb5ee15da1mshb46d59d679af3abp1fe84cjsn167590fdc0cc" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            return View();
        }
    }
    }
}

