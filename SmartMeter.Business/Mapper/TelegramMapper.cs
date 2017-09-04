using SmartMeter.Business.Interface.Mapper;

namespace SmartMeter.Business.Mapper {
  public class TelegramMapper : IMapTelegram {
    public Persistence.Interface.ITelegram Map(Business.Interface.ITelegram businessTelegram) {
      return new Persistence.Telegram() {
        Timestamp = businessTelegram.Timestamp,
        ElectricityConsumedTariff1 = businessTelegram.ElectricityConsumedTariff1,
        ElectricityConsumedTariff2 = businessTelegram.ElectricityConsumedTariff2,
        ElectricityDeliveredTariff1 = businessTelegram.ElectricityDeliveredTariff1,
        ElectricityDeliveredTariff2 = businessTelegram.ElectricityDeliveredTariff2,
        ElectrictyConsumedActual = businessTelegram.ElectrictyConsumedActual,
        ElectricityDeliveredActual = businessTelegram.ElectricityDeliveredActual,
      };
    }
  }
}