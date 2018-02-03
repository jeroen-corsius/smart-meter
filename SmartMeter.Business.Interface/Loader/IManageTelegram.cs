using System.Collections.Generic;

namespace SmartMeter.Business.Interface.Loader {
  public interface IManageTelegram {
    void Save(ITelegram telegram);
    IEnumerable<ITelegram> SelectRecent();
  }
}