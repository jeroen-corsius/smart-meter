using System;
using SmartMeter.Business.Interface;

namespace SmartMeter.Business {
  public class Telegram : ITelegram {
    public DateTime Timestamp { get; set; }
    public decimal ElectricityConsumedTariff1 { get; set; }
    public decimal ElectricityConsumedTariff2 { get; set; }
    public decimal ElectricityDeliveredTariff1 { get; set; }
    public decimal ElectricityDeliveredTariff2 { get; set; }
    public decimal ElectrictyConsumedActual { get; set; }
    public decimal ElectricityDeliveredActual { get; set; }
  }
}