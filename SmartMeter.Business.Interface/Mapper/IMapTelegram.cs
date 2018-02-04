using System.Collections.Generic;

namespace SmartMeter.Business.Interface.Mapper {
  public interface IMapTelegram {
    Persistence.Interface.ITelegram Map(ITelegram businessTelegram);
    Business.Interface.ITelegram Map(Persistence.Interface.ITelegram persistenceTelegram);
    IEnumerable<ITelegram> Map(IEnumerable<Persistence.Interface.ITelegram> persistenceTelegrams);
  }
}