using System.Data;
using Dapper;
using SmartMeter.Persistence.Interface;

namespace SmartMeter.Persistence {
  public class TelegramRepository : IPersistTelegram {
    public void Save(ITelegram telegram) {
      string statement = @"
        INSERT INTO `smart_meter`.`smart_meter_1`
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
  }
}