using System.Collections.Generic;
using SmartMeter.Business.Interface.Loader;
using SmartMeter.Business.Interface.Mapper;
using SmartMeter.Business.Mapper;
using SmartMeter.Persistence;
using SmartMeter.Persistence.Interface;

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
  }
}