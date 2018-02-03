using System;
using System.Data;
using MySql.Data.MySqlClient;
using SmartMeter.Configuration;
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
        Server = Config.Instance.DatabaseServer,
        Port = Config.Instance.DatabasePort,
        UserID = Config.Instance.DatabaseUserId,
        Password = Config.Instance.DatabasePassword,
        Database = Config.Instance.DatabaseDatabase,
        SslMode = MySqlSslMode.None
      };

      return mySqlConnectionStringBuilder.ConnectionString;
    }
  }
}