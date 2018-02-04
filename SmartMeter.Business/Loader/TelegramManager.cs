using System.Collections.Generic;
using SmartMeter.Business.Interface.Loader;
using SmartMeter.Business.Interface.Mapper;
using SmartMeter.Business.Mapper;
using SmartMeter.Persistence;
using SmartMeter.Persistence.Interface;
using ITelegram = SmartMeter.Business.Interface.ITelegram;

namespace SmartMeter.Business.Loader {
  public class TelegramManager : IManageTelegram {
    public void Save(Business.Interface.ITelegram telegram) {
      IMapTelegram telegramMapper = new TelegramMapper();
      Persistence.Interface.ITelegram persistenceTelegram = telegramMapper.Map(telegram);

      IPersistTelegram telegramRepository = new TelegramRepository();
      telegramRepository.Save(persistenceTelegram);
    }

    public IEnumerable<Business.Interface.ITelegram> SelectRecent() {
      IPersistTelegram telegramRepository = new TelegramRepository();
      IEnumerable<Persistence.Interface.ITelegram> persistenceTelegrams = telegramRepository.SelectRecent();

      IMapTelegram telegramMapper = new TelegramMapper();
      return telegramMapper.Map(persistenceTelegrams);
    }

    public ITelegram SelectCurrent() {
      IPersistTelegram telegramRepository = new TelegramRepository();
      Persistence.Interface.ITelegram persistenceTelegram = telegramRepository.SelectCurrent();

      IMapTelegram telegramMapper = new TelegramMapper();
      return telegramMapper.Map(persistenceTelegram);
    }
  }
}