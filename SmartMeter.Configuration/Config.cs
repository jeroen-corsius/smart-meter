using System;
using Microsoft.Extensions.Configuration;

namespace SmartMeter.Configuration {
  public class Config {
    private static Config _Instance;

    public static Config Instance {
      get {
        if (_Instance == null) {
          _Instance = new Config();
        }
        return _Instance;
      }
    }

    public string SerialPort { get; private set; }
    public int SerialBaud { get; private set; }
    public int SerialDataBits { get; private set; }
    public int SerialParity { get; private set; }
    public int SerialStopBits { get; private set; }
    public TimeSpan ExtractorExecutionInterval { get; private set; }
    public TimeSpan TranslatorExecutionInterval { get; private set; }
    public TimeSpan LoaderExecutionInterval { get; private set; }
    public string ExtractedFilesPath { get; private set; }
    public string TranslatedFilesPath { get; private set; }
    public string DatabaseServer { get; private set; }
    public uint DatabasePort { get; private set; }
    public string DatabaseUserId { get; private set; }
    public string DatabasePassword { get; private set; }
    public string DatabaseDatabase { get; private set; }

    private Config() {
      _LoadConfiguration();
    }

    private void _LoadConfiguration() {
      IConfigurationRoot configurationRoot = new ConfigurationBuilder()
        .AddJsonFile("config.json")
        .AddEnvironmentVariables()
        .Build();
      
      SerialPort = configurationRoot["Serial:Port"];
      SerialBaud = Convert.ToInt32(configurationRoot["Serial:Baud"]);
      SerialDataBits = Convert.ToInt32(configurationRoot["Serial:DataBits"]);
      SerialParity = Convert.ToInt32(configurationRoot["Serial:Parity"]);
      SerialStopBits = Convert.ToInt32(configurationRoot["Serial:StopBits"]);
      ExtractorExecutionInterval = TimeSpan.FromSeconds(Convert.ToInt32(configurationRoot["ExtractorExecutionInterval"]));
      TranslatorExecutionInterval = TimeSpan.FromSeconds(Convert.ToInt32(configurationRoot["TranslatorExecutionInterval"]));
      LoaderExecutionInterval = TimeSpan.FromSeconds(Convert.ToInt32(configurationRoot["LoaderExecutionInterval"]));
      ExtractedFilesPath = configurationRoot["ExtractedFilesPath"];
      TranslatedFilesPath = configurationRoot["TranslatedFilesPath"];
      DatabaseServer = configurationRoot.GetSection("SMARTMETER_DATABASE_SERVER").Value;
      DatabasePort = Convert.ToUInt32(configurationRoot.GetSection("SMARTMETER_DATABASE_PORT").Value);
      DatabaseUserId = configurationRoot.GetSection("SMARTMETER_DATABASE_USERID").Value;
      DatabasePassword = configurationRoot.GetSection("SMARTMETER_DATABASE_PASSWORD").Value;
      DatabaseDatabase = configurationRoot.GetSection("SMARTMETER_DATABASE_DATABASE").Value;
    }
  }
}