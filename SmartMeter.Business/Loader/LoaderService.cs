using System;
using System.IO;
using Newtonsoft.Json;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Loader;

namespace SmartMeter.Business.Loader {
  public class LoaderService {
    public void Execute() {
      IManageTelegram telegramManager = new TelegramManager();
      FileInfo[] translatedFiles = _ListTranslatedFiles();

      foreach (FileInfo translatedFile in translatedFiles) {
        try {
          string serializedTelegram = File.ReadAllText(translatedFile.FullName);
          ITelegram telegram = JsonConvert.DeserializeObject<Telegram>(serializedTelegram);

          telegramManager.Save(telegram);

          //TODO: Remove translated file after loading
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