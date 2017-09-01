using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Translator;

namespace SmartMeter.Business.Tests.Translator {
  [TestClass]
  public class FileTranslatorTests {
    [TestMethod]
    public void TranslatesWithCorrectTimestamp() {
      DateTime expectedTimestamp = new DateTime(2017, 08, 31, 10, 55, 07);
      string filePath = $"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt";
      FileInfo fileInfo = new FileInfo(filePath);

      FileTranslator fileTranslator = new FileTranslator();
      ITelegram telegram = fileTranslator.Translate(fileInfo);

      Assert.AreEqual(expectedTimestamp, telegram.Timestamp);
    }
    
    [TestMethod]
    public void TranslatesWithCorrectElectricityConsumedTariff1() {
      decimal expectedElectricityConsumedTariff1 = 3478.720m;
      string filePath = $"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt";
      FileInfo fileInfo = new FileInfo(filePath);

      FileTranslator fileTranslator = new FileTranslator();
      ITelegram telegram = fileTranslator.Translate(fileInfo);

      Assert.AreEqual(expectedElectricityConsumedTariff1, telegram.ElectricityConsumedTariff1);
    }
    
    [TestMethod]
    public void TranslatesWithCorrectElectricityConsumedTariff2() {
      decimal expectedElectricityConsumedTariff2 = 1356.036m;
      string filePath = $"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt";
      FileInfo fileInfo = new FileInfo(filePath);

      FileTranslator fileTranslator = new FileTranslator();
      ITelegram telegram = fileTranslator.Translate(fileInfo);

      Assert.AreEqual(expectedElectricityConsumedTariff2, telegram.ElectricityConsumedTariff2);
    }

    [TestMethod]
    public void TranslatesWithCorrectElectricityDeliveredTariff1() {
      decimal expectedElectricityDeliveredTariff1 = 2186.133m;
      string filePath = $"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt";
      FileInfo fileInfo = new FileInfo(filePath);

      FileTranslator fileTranslator = new FileTranslator();
      ITelegram telegram = fileTranslator.Translate(fileInfo);

      Assert.AreEqual(expectedElectricityDeliveredTariff1, telegram.ElectricityDeliveredTariff1);
    }

    [TestMethod]
    public void TranslatesWithCorrectElectricityDeliveredTariff2() {
      decimal expectedElectricityDeliveredTariff2 = 5560.591m;
      string filePath = $"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt";
      FileInfo fileInfo = new FileInfo(filePath);

      FileTranslator fileTranslator = new FileTranslator();
      ITelegram telegram = fileTranslator.Translate(fileInfo);

      Assert.AreEqual(expectedElectricityDeliveredTariff2, telegram.ElectricityDeliveredTariff2);
    }

    [TestMethod]
    public void TranslatesWithCorrectElectricityConsumedActual() {
      decimal expectedElectricityConsumedActual = 1.04m;
      string filePath = $"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt";
      FileInfo fileInfo = new FileInfo(filePath);

      FileTranslator fileTranslator = new FileTranslator();
      ITelegram telegram = fileTranslator.Translate(fileInfo);

      Assert.AreEqual(expectedElectricityConsumedActual, telegram.ElectrictyConsumedActual);
    }

    [TestMethod]
    public void TranslatesWithCorrectElectricityDeliveredActual() {
      decimal expectedElectricityDeliveredActual = 0.848m;
      string filePath = $"{Directory.GetCurrentDirectory()}/Files/CreatesFileWithCorrectContents.txt";
      FileInfo fileInfo = new FileInfo(filePath);

      FileTranslator fileTranslator = new FileTranslator();
      ITelegram telegram = fileTranslator.Translate(fileInfo);

      Assert.AreEqual(expectedElectricityDeliveredActual, telegram.ElectricityDeliveredActual);
    }
  }
}