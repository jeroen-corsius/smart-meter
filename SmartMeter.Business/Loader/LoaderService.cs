using System;
using System.IO;
using Newtonsoft.Json;
using SmartMeter.Business.Interface;

namespace SmartMeter.Business.Loader {
  public class LoaderService {
    public void Execute() {
      FileInfo[] translatedFiles = _ListTranslatedFiles();

      foreach (FileInfo translatedFile in translatedFiles) {
        try {
          string serializedTelegram = File.ReadAllText(translatedFile.FullName);
          ITelegram telegram = JsonConvert.DeserializeObject<Telegram>(serializedTelegram);

          //translatedFile.Delete();
        }
        catch (Exception ex) {
          Console.WriteLine($"An error occured while loading file '{translatedFile.FullName}': {ex}");
        }
      }
    }

    private FileInfo[] _ListTranslatedFiles() {
      DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetDirectoryRoot(AppContext.BaseDirectory), "applicationdata", "smartmeter", "translated"));

      //TODO: Filter for specific file extensions to prevent reading uncompleted files
      return directoryInfo.GetFiles();
    }
  }
}