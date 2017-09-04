using System;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Extractor;
using SmartMeter.Configuration;

namespace SmartMeter.Business.Extractor {
  public class ExtractorService {
    public void Execute() {
      IReadSmartMeter smartMeterReader = new SmartMeterReader();
      IWriteFile fileWriter = new FileWriter();
      string fileContents = smartMeterReader.Read();

      fileWriter
        .WithPath(Config.Instance.ExtractedFilesPath)
        .WithFilename(CreateFilename())
        .WithContents(fileContents)
        .Write();

      Console.WriteLine($"{DateTime.UtcNow}: Extracted data from smart meter");
    }

    public string CreateFilename() {
      return $"{DateTime.UtcNow:yyyyMMddHHmmss}.smf";
    }
  }
}