using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartMeter.Business.Tests {
  [TestClass]
  public class FileWriterTests {
    [TestInitialize]
    public void CleanOutputDirectory() {
      string outputDirectory = Path.Combine(AppContext.BaseDirectory, "output-files");
      if (Directory.Exists(outputDirectory)) Directory.Delete(outputDirectory, true);
    }

    [TestMethod]
    public void CreatesFileWithCorrectFilename() {
      string expectedFilename = $"{DateTime.UtcNow:yyyyMMddHHmmss}.smf";

      FileWriter fileWriter = new FileWriter();
      fileWriter
        .WithContents("Test Contents")
        .WithPath(Path.Combine(AppContext.BaseDirectory, "output-files"))
        .WithFilename(expectedFilename)
        .Write();

      Assert.IsTrue(File.Exists(Path.Combine(AppContext.BaseDirectory, "output-files", expectedFilename)));
    }

    [TestMethod]
    public void CreatesFileWithCorrectContents() {
      string filename = $"{DateTime.UtcNow:yyyyMMddHHmmss}.smf";
      string expectedFileContents = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt");

      FileWriter fileWriter = new FileWriter();
      fileWriter
        .WithContents(expectedFileContents)
        .WithPath(Path.Combine(AppContext.BaseDirectory, "output-files"))
        .WithFilename(filename)
        .Write();

      string fullFilePath = Path.Combine(AppContext.BaseDirectory, "output-files", filename);
      string actualFileContents = File.ReadAllText(fullFilePath);

      Assert.AreEqual(expectedFileContents, actualFileContents);
    }
  }
}