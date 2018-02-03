using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SmartMeter.API.Controllers {
  [Route("api/[controller]")]
  public class ElectricityController : Controller {
    [HttpGet("Recent")]
    public IEnumerable<string> GetRecent() {
      return new string[] { "value1", "value2" };
    }
  }
}