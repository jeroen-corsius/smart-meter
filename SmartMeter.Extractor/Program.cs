using System;
using System.Threading;
using SmartMeter.Business.Extractor;
using SmartMeter.Configuration;

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

        //TODO: Make sure setting 10 seconds as ExtractorExecutionInterval works fine (instead of using 9)
        Thread.Sleep(Config.Instance.ExtractorExecutionInterval);
      }
    }
  }
}