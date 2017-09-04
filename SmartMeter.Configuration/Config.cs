using System;
using System.IO;
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
    public string ExtractedFilesPath { get; private set; }

    private Config() {
      _LoadConfiguration();
    }

    private void _LoadConfiguration() {
      IConfigurationRoot configurationRoot = new ConfigurationBuilder()
        .AddJsonFile("config.json")
        .Build();

      SerialPort = configurationRoot["Serial:Port"];
      SerialBaud = Convert.ToInt32(configurationRoot["Serial:Baud"]);
      SerialDataBits = Convert.ToInt32(configurationRoot["Serial:DataBits"]);
      SerialParity = Convert.ToInt32(configurationRoot["Serial:Parity"]);
      SerialStopBits = Convert.ToInt32(configurationRoot["Serial:StopBits"]);
      ExtractorExecutionInterval = TimeSpan.FromSeconds(Convert.ToInt32(configurationRoot["ExtractorExecutionInterval"]));
      ExtractedFilesPath = configurationRoot["ExtractedFilesPath"];
    }
  }
}