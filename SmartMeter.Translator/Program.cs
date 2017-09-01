﻿using System;
using System.IO;
using System.Threading;
using SmartMeter.Business.Translator;

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

        Thread.Sleep(TimeSpan.FromSeconds(10));
      }
    }
  }
}