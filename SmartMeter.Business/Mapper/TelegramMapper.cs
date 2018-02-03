using System.Collections.Generic;
using System.Linq;
using SmartMeter.Business.Interface;
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

    public Business.Interface.ITelegram Map(Persistence.Interface.ITelegram persistenceTelegram) {
      return new Telegram() {
        Timestamp = persistenceTelegram.Timestamp,
        ElectricityConsumedTariff1 = persistenceTelegram.ElectricityConsumedTariff1,
        ElectricityConsumedTariff2 = persistenceTelegram.ElectricityConsumedTariff2,
        ElectricityDeliveredTariff1 = persistenceTelegram.ElectricityDeliveredTariff1,
        ElectricityDeliveredTariff2 = persistenceTelegram.ElectricityDeliveredTariff2,
        ElectrictyConsumedActual = persistenceTelegram.ElectrictyConsumedActual,
        ElectricityDeliveredActual = persistenceTelegram.ElectricityDeliveredActual,
      };
    }

    public IEnumerable<ITelegram> Map(IEnumerable<Persistence.Interface.ITelegram> persistenceTelegrams) {
      return persistenceTelegrams.Select(Map);
    }
  }
}