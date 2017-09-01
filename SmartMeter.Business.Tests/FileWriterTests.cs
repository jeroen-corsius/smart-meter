using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMeter.Business.Extractor;

namespace SmartMeter.Business.Tests {
  [TestClass]
  public class FileWriterTests {
    [TestInitialize]
    public void CleanOutputDirectory() {
      string outputDirectory = Path.Combine(Directory.GetDirectoryRoot(AppContext.BaseDirectory), "applicationdata", "smartmeter", "extracted");
      if (Directory.Exists(outputDirectory)) Directory.Delete(outputDirectory, true);
    }

    [TestMethod]
    public void CreatesFileWithCorrectFilename() {
      string expectedFilename = $"{DateTime.UtcNow:yyyyMMddHHmmss}.smf";

      FileWriter fileWriter = new FileWriter();
      fileWriter
        .WithPath(Path.Combine(Directory.GetDirectoryRoot(AppContext.BaseDirectory), "applicationdata", "smartmeter", "extracted"))
        .WithFilename(expectedFilename)
        .WithContents("Test Contents")
        .Write();

      Assert.IsTrue(File.Exists(Path.Combine(Directory.GetDirectoryRoot(AppContext.BaseDirectory), "applicationdata", "smartmeter", "extracted", expectedFilename)));
    }

    [TestMethod]
    public void CreatesFileWithCorrectContents() {
      string filename = $"{DateTime.UtcNow:yyyyMMddHHmmss}.smf";
      string expectedFileContents = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt");

      FileWriter fileWriter = new FileWriter();
      fileWriter
        .WithPath(Path.Combine(Directory.GetDirectoryRoot(AppContext.BaseDirectory), "applicationdata", "smartmeter", "extracted"))
        .WithFilename(filename)
        .WithContents(expectedFileContents)
        .Write();

      string fullFilePath = Path.Combine(Directory.GetDirectoryRoot(AppContext.BaseDirectory), "applicationdata", "smartmeter", "extracted", filename);
      string actualFileContents = File.ReadAllText(fullFilePath);

      Assert.AreEqual(expectedFileContents, actualFileContents);
    }
  }
}