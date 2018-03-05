using System.Collections.Generic;
using System.Data;
using Dapper;
using SmartMeter.Persistence.Interface;

namespace SmartMeter.Persistence {
  public class TelegramRepository : IPersistTelegram {
    public void Save(ITelegram telegram) {
      string statement = @"
        INSERT INTO `electricity`
        (Timestamp, ElectricityConsumedTariff1, ElectricityConsumedTariff2, ElectricityDeliveredTariff1, ElectricityDeliveredTariff2, ElectrictyConsumedActual, ElectricityDeliveredActual)
        VALUES 
        (@Timestamp, @ElectricityConsumedTariff1, @ElectricityConsumedTariff2, @ElectricityDeliveredTariff1, @ElectricityDeliveredTariff2, @ElectrictyConsumedActual, @ElectricityDeliveredActual)
        ON DUPLICATE KEY UPDATE
        ElectricityConsumedTariff1 = VALUES(ElectricityConsumedTariff1),
        ElectricityConsumedTariff2 = VALUES(ElectricityConsumedTariff2),
        ElectricityDeliveredTariff1 = VALUES(ElectricityDeliveredTariff1),
        ElectricityDeliveredTariff2 = VALUES(ElectricityDeliveredTariff2),
        ElectrictyConsumedActual = VALUES(ElectrictyConsumedActual),
        ElectricityDeliveredActual = VALUES(ElectricityDeliveredActual);
      ";

      using (IDbConnection connection = new DatabaseConnection().CreateConnection()) {
        connection.Execute(statement, telegram);
      }
    }

    public IEnumerable<ITelegram> SelectLast5Minutes() {
      string statement = @"
        SELECT *
        FROM (
          SELECT *
          FROM `electricity`
          ORDER BY Timestamp DESC
          LIMIT 30
        ) e
        ORDER BY e.Timestamp;";

      using (IDbConnection connection = new DatabaseConnection().CreateConnection()) {
        return connection.Query<Telegram>(statement);
      }
    }

    public ITelegram SelectCurrent() {
      string statement = @"
        SELECT *
        FROM `electricity`
        ORDER BY Timestamp DESC
        LIMIT 1;";

      using (IDbConnection connection = new DatabaseConnection().CreateConnection()) {
        return connection.QuerySingle<Telegram>(statement);
      }
    }
  }
}