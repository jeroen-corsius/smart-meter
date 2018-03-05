using System.Collections.Generic;

namespace SmartMeter.Business.Interface.Loader {
  public interface IManageTelegram {
    void Save(ITelegram telegram);
    IEnumerable<ITelegram> SelectLast5Minutes();
    ITelegram SelectCurrent();
  }
}