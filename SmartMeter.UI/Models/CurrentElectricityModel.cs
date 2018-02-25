using System;
using Newtonsoft.Json;

namespace SmartMeter.UI.Models {
  public class CurrentElectricityModel {
    public DateTime Timestamps { get; set; }
    public decimal ConsumedTariff1 { get; set; }
    public decimal ConsumedTariff2 { get; set; }
    public decimal DeliveredTariff1 { get; set; }
    public decimal DeliveredTariff2 { get; set; }
    [JsonProperty(PropertyName = "electrictyConsumedActual")]
    public decimal ConsumedActual { get; set; }
    [JsonProperty(PropertyName = "electricityDeliveredActual")]
    public decimal DeliveredActual { get; set; }
  }
}