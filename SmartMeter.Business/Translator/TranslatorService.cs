﻿using System;
using System.IO;
using Newtonsoft.Json;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Translator;
using SmartMeter.Configuration;

namespace SmartMeter.Business.Translator {
  public class TranslatorService {
    public void Execute() {
      FileInfo[] extractedFiles = _ListExtractedFiles();

      foreach (FileInfo extractedFile in extractedFiles) {
        try {
          ITranslateFile fileTranslator = new FileTranslator();
          ITelegram telegram = fileTranslator.Translate(extractedFile);
          string serializedTelegram = JsonConvert.SerializeObject(telegram);

          IWriteFile fileWriter = new FileWriter();

          fileWriter
            .WithPath(Config.Instance.TranslatedFilesPath)
            .WithFilename(_CreateFilename(extractedFile))
            .WithContents(serializedTelegram)
            .Write();

          extractedFile.Delete();

          Console.WriteLine($"{DateTime.UtcNow}: Translated '{extractedFile.Name}'");
        }
        catch (Exception ex) {
          Console.WriteLine($"An error occured while translating file '{extractedFile.FullName}': {ex}");
        }
      }
    }

    private FileInfo[] _ListExtractedFiles() {
      string path = Config.Instance.ExtractedFilesPath;

      Directory.CreateDirectory(path);
      DirectoryInfo directoryInfo = new DirectoryInfo(path);

      //TODO: Filter for specific file extensions to prevent reading uncompleted files
      return directoryInfo.GetFiles();
    }

    private string _CreateFilename(FileInfo extractedFile) {
      return $"{Path.GetFileNameWithoutExtension(extractedFile.Name)}.telegram";
    }
  }
}