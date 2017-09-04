using System;
using System.Threading;
using SmartMeter.Business.Loader;

namespace SmartMeter.Loader {
  class Program {
    static void Main(string[] args) {
      while (true) {
        try {
          LoaderService loaderService = new LoaderService();
          loaderService.Execute();
        }
        catch (Exception ex) {
          Console.WriteLine($"An error occured while loading files: {ex}");
        }

        Thread.Sleep(TimeSpan.FromSeconds(10));
      }
    }
  }
}