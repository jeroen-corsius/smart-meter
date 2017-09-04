using System;
using System.Threading;
using SmartMeter.Business.Translator;
using SmartMeter.Configuration;

namespace SmartMeter.Translator {
  class Program {
    static void Main(string[] args) {
      while (true) {
        try {
          TranslatorService translatorService = new TranslatorService();
          translatorService.Execute();
        }
        catch (Exception ex) {
          Console.WriteLine($"An error occured while translating files: {ex}");
        }

        Thread.Sleep(Config.Instance.TranslatorExecutionInterval);
      }
    }
  }
}