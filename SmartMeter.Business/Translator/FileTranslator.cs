using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Translator;

namespace SmartMeter.Business.Translator {
  public class FileTranslator : ITranslateFile {
    public ITelegram Translate(FileInfo file) {
      string fileContents = File.ReadAllText(file.FullName);

      //TODO: Move regex patterns to property attributes
      Regex timestampRegex = new Regex("(?<=1\\.0\\.0)(?:\\()[^\\d]*(\\d+)[^\\d]*(?:\\))", RegexOptions.Multiline);
      Match timestampMatch = timestampRegex.Match(fileContents);
      string timestampMatchValue = timestampMatch.Groups[1].Value;
      DateTime timestamp = DateTime.ParseExact(timestampMatchValue, "yyMMddHHmmss", CultureInfo.InvariantCulture);

      Regex electrictyConsumedTariff1 = new Regex("(?<=1\\.8\\.1)(?:\\()(\\d+\\.\\d+)(?:\\*kWh\\))", RegexOptions.Multiline);
      Match electricityConsumedTariff1Match = electrictyConsumedTariff1.Match(fileContents);
      string electricityConsumedTariff1MatchValue = electricityConsumedTariff1Match.Groups[1].Value;
      decimal electricityConsumedTariff1 = decimal.Parse(electricityConsumedTariff1MatchValue);

      Regex electrictyConsumedTariff2 = new Regex("(?<=1\\.8\\.2)(?:\\()(\\d+\\.\\d+)(?:\\*kWh\\))", RegexOptions.Multiline);
      Match electricityConsumedTariff2Match = electrictyConsumedTariff2.Match(fileContents);
      string electricityConsumedTariff2MatchValue = electricityConsumedTariff2Match.Groups[1].Value;
      decimal electricityConsumedTariff2 = decimal.Parse(electricityConsumedTariff2MatchValue);

      Regex electrictyDeliveredTariff1 = new Regex("(?<=2\\.8\\.1)(?:\\()(\\d+\\.\\d+)(?:\\*kWh\\))", RegexOptions.Multiline);
      Match electricityDeliveredTariff1Match = electrictyDeliveredTariff1.Match(fileContents);
      string electricityDeliverdTariff1MatchValue = electricityDeliveredTariff1Match.Groups[1].Value;
      decimal electricityDeliveredTariff1 = decimal.Parse(electricityDeliverdTariff1MatchValue);

      Regex electrictyDeliveredTariff2 = new Regex("(?<=2\\.8\\.2)(?:\\()(\\d+\\.\\d+)(?:\\*kWh\\))", RegexOptions.Multiline);
      Match electricityDeliveredTariff2Match = electrictyDeliveredTariff2.Match(fileContents);
      string electricityDeliveredTariff2MatchValue = electricityDeliveredTariff2Match.Groups[1].Value;
      decimal electricityDeliveredTariff2 = decimal.Parse(electricityDeliveredTariff2MatchValue);

      Regex electrictyConsumedActual = new Regex("(?<=1\\.7\\.0)(?:\\()(\\d+\\.\\d+)(?:\\*kW\\))", RegexOptions.Multiline);
      Match electricityConsumedActualMatch = electrictyConsumedActual.Match(fileContents);
      string electricityConsumedActualMatchValue = electricityConsumedActualMatch.Groups[1].Value;
      decimal electricityConsumedActual = decimal.Parse(electricityConsumedActualMatchValue);

      Regex electrictyDeliveredActual = new Regex("(?<=2\\.7\\.0)(?:\\()(\\d+\\.\\d+)(?:\\*kW\\))", RegexOptions.Multiline);
      Match electricityDeliveredActualMatch = electrictyDeliveredActual.Match(fileContents);
      string electricityDeliveredActualMatchValue = electricityDeliveredActualMatch.Groups[1].Value;
      decimal electricityDeliveredActual = decimal.Parse(electricityDeliveredActualMatchValue);

      return new Telegram() {
        Timestamp = timestamp,
        ElectricityConsumedTariff1 = electricityConsumedTariff1,
        ElectricityConsumedTariff2 = electricityConsumedTariff2,
        ElectricityDeliveredTariff1 = electricityDeliveredTariff1,
        ElectricityDeliveredTariff2 = electricityDeliveredTariff2,
        ElectrictyConsumedActual = electricityConsumedActual,
        ElectricityDeliveredActual = electricityDeliveredActual,
      };
    }
  }
}