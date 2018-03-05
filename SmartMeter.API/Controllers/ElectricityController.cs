using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Loader;
using SmartMeter.Business.Loader;

namespace SmartMeter.API.Controllers {
  [Route("api/[controller]")]
  public class ElectricityController : Controller {
    [HttpGet("Last5Minutes")]
    public IActionResult GetLast5Minutes() {
      IManageTelegram telegramManager = new TelegramManager();
      IEnumerable<ITelegram> telegrams = telegramManager.SelectLast5Minutes();

      return Ok(telegrams);
    }

    [HttpGet("Current")]
    public IActionResult GetCurrent() {
      IManageTelegram telegramManager = new TelegramManager();
      ITelegram telegram = telegramManager.SelectCurrent();

      return Ok(telegram);
    }
  }
}