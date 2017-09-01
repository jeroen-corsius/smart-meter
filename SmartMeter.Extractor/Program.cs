using System;
using System.Threading;
using SmartMeter.Business.Extractor;

namespace SmartMeter.Extractor {
  class Program {
    static void Main(string[] args) {
      while (true) {
        try {
          ExtractorService extractorService = new ExtractorService();
          extractorService.Execute();
        }
        catch (Exception ex) {
          Console.WriteLine($"An error occured while extracing files: {ex}");
        }

        Thread.Sleep(TimeSpan.FromSeconds(9));
      }
    }
  }
}