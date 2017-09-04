using System.Data;

namespace SmartMeter.Persistence.Interface {
  public interface IConnectDatabase {
    IDbConnection CreateConnection();
  }
}