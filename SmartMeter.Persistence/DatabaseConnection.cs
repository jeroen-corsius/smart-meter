using System.Data;
using MySql.Data.MySqlClient;
using SmartMeter.Persistence.Interface;

namespace SmartMeter.Persistence {
  public class DatabaseConnection : IConnectDatabase {
    private readonly string _ConnectionString;

    public DatabaseConnection() {
      _ConnectionString = _CreateConnectionString();
    }

    public IDbConnection CreateConnection() {
      return new MySqlConnection(_ConnectionString);
    }

    private string _CreateConnectionString() {
      MySqlConnectionStringBuilder mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder {
        Server = "127.0.0.1",
        Port = 3306,
        UserID = "smart_meter_loader",
        Password = "iZv$lQJlyYCO%XFtOF^9Qqoa1Q%!k51b",
        Database = "smart_meter",
        SslMode = MySqlSslMode.None
      };

      return mySqlConnectionStringBuilder.ConnectionString;
    }
  }
}