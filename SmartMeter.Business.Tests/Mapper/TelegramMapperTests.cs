using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMeter.Business.Interface.Mapper;
using SmartMeter.Business.Mapper;

namespace SmartMeter.Business.Tests.Mapper {
  [TestClass]
  public class TelegramMapperTests {
    [TestMethod]
    public void MapsToPersistenceCorrectly() {
      Business.Interface.ITelegram businessTelegram = new Telegram {
        Timestamp = DateTime.UtcNow,
        ElectricityConsumedTariff1 = 123.456m,
        ElectricityConsumedTariff2 = 234.567m,
        ElectricityDeliveredTariff1 = 345.678m,
        ElectricityDeliveredTariff2 = 456.789m,
        ElectrictyConsumedActual = 358.023m,
        ElectricityDeliveredActual = 802.467m,
      };

      IMapTelegram telegramMapper = new TelegramMapper();
      Persistence.Interface.ITelegram persistenceTelegram = telegramMapper.Map(businessTelegram);

      Assert.AreEqual(businessTelegram.Timestamp, persistenceTelegram.Timestamp);
      Assert.AreEqual(businessTelegram.ElectricityConsumedTariff1, persistenceTelegram.ElectricityConsumedTariff1);
      Assert.AreEqual(businessTelegram.ElectricityConsumedTariff2, persistenceTelegram.ElectricityConsumedTariff2);
      Assert.AreEqual(businessTelegram.ElectricityDeliveredTariff1, persistenceTelegram.ElectricityDeliveredTariff1);
      Assert.AreEqual(businessTelegram.ElectricityDeliveredTariff2, persistenceTelegram.ElectricityDeliveredTariff2);
      Assert.AreEqual(businessTelegram.ElectrictyConsumedActual, persistenceTelegram.ElectrictyConsumedActual);
      Assert.AreEqual(businessTelegram.ElectricityDeliveredActual, persistenceTelegram.ElectricityDeliveredActual);
    }
  }
}