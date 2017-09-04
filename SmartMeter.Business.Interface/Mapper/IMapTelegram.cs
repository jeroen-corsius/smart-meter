using System.Security.Cryptography.X509Certificates;

namespace SmartMeter.Business.Interface.Mapper {
  public interface IMapTelegram {
    Persistence.Interface.ITelegram Map(ITelegram businessTelegram);
  }
}