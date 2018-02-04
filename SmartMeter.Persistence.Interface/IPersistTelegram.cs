using System.Collections.Generic;

namespace SmartMeter.Persistence.Interface {
  public interface IPersistTelegram {
    void Save(ITelegram telegram);
    IEnumerable<ITelegram> SelectRecent();
    ITelegram SelectCurrent();
  }
}