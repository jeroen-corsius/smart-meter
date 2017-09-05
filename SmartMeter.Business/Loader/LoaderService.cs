using System;
using System.IO;
using Newtonsoft.Json;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Loader;
using SmartMeter.Configuration;

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

          translatedFile.Delete();

          Console.WriteLine($"{DateTime.UtcNow}: Loaded '{translatedFile.Name}'");
        }
        catch (Exception ex) {
          Console.WriteLine($"An error occured while loading file '{translatedFile.FullName}': {ex}");
        }
      }
    }

    private FileInfo[] _ListTranslatedFiles() {
      string path = Config.Instance.TranslatedFilesPath;

      Directory.CreateDirectory(path);
      DirectoryInfo directoryInfo = new DirectoryInfo(path);

      //TODO: Filter for specific file extensions to prevent reading uncompleted files
      return directoryInfo.GetFiles();
    }
  }
}