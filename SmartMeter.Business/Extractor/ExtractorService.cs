using System;
using System.IO;
using SmartMeter.Business.Interface;

namespace SmartMeter.Business.Extractor {
  public class ExtractorService {
    public void Execute() {
      IReadSmartMeter smartMeterReader = new SmartMeterReader();
      IWriteFile fileWriter = new FileWriter();
      string fileContents = smartMeterReader.Read();

      fileWriter
        .WithPath(Path.Combine(AppContext.BaseDirectory, "files", "extracted"))
        .WithFilename(CreateFilename())
        .WithContents(fileContents)
        .Write();
    }

    public string CreateFilename() {
      return $"{DateTime.UtcNow:yyyyMMddHHmmss}.smf";
    }
  }
}