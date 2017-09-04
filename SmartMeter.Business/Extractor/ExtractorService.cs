using System;
using System.IO;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Extractor;

namespace SmartMeter.Business.Extractor {
  public class ExtractorService {
    public void Execute() {
      IReadSmartMeter smartMeterReader = new SmartMeterReader();
      IWriteFile fileWriter = new FileWriter();
      string fileContents = smartMeterReader.Read();

      fileWriter
        .WithPath(Path.Combine(Directory.GetDirectoryRoot(AppContext.BaseDirectory), "applicationdata", "smartmeter", "extracted"))
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