using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartMeter.UI.Models;

namespace SmartMeter.UI.Controllers {
  public class HomeController : Controller {
    public async Task<IActionResult> Index() {
      using (HttpClient httpClient = new HttpClient()) {
        try {
          httpClient.BaseAddress = new Uri("http://192.168.178.28:5000");
          HttpResponseMessage response = await httpClient.GetAsync("/api/electricity/current");
          response.EnsureSuccessStatusCode();

          string stringResult = await response.Content.ReadAsStringAsync();
          CurrentElectricityModel currentElectricityModel = JsonConvert.DeserializeObject<CurrentElectricityModel>(stringResult);

          return View(currentElectricityModel);
        }
        catch (HttpRequestException exception) {
          return BadRequest("Error fetching eletricity data");
        }
      }
    }
  }
}