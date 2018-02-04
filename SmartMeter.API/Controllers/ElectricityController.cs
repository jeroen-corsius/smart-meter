using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Loader;
using SmartMeter.Business.Loader;

namespace SmartMeter.API.Controllers {
  [Route("api/[controller]")]
  public class ElectricityController : Controller {
    [HttpGet("Recent")]
    public IActionResult GetRecent() {
      IManageTelegram telegramManager = new TelegramManager();
      IEnumerable<ITelegram> telegrams = telegramManager.SelectRecent();

      return Ok(telegrams);
    }
  }
}