using System;

namespace SmartMeter.Persistence.Interface {
  public interface ITelegram {
    DateTime Timestamp { get; set; }
    decimal ElectricityConsumedTariff1 { get; set; }
    decimal ElectricityConsumedTariff2 { get; set; }
    decimal ElectricityDeliveredTariff1 { get; set; }
    decimal ElectricityDeliveredTariff2 { get; set; }
    decimal ElectrictyConsumedActual { get; set; }
    decimal ElectricityDeliveredActual { get; set; }
  }
}