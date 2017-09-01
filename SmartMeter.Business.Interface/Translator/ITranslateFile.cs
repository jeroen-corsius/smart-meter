using System.IO;

namespace SmartMeter.Business.Interface.Translator {
  public interface ITranslateFile {
    ITelegram Translate(FileInfo file);
  }
}