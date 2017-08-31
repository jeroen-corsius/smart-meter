using System.IO;
using SmartMeter.Business.Interface;

namespace SmartMeter.Business.Extractor {
  public class FileWriter : IWriteFile {
    private string _Contents;
    private string _Path;
    private string _Filename;

    public IWriteFile WithContents(string contents) {
      _Contents = contents;

      return this;
    }

    public IWriteFile WithPath(string path) {
      _Path = path;

      return this;
    }

    public IWriteFile WithFilename(string filename) {
      _Filename = filename;

      return this;
    }

    public void Write() {
      string fullPath = Path.Combine(_Path, _Filename);

      Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
      File.WriteAllText(fullPath, _Contents);
    }
  }
}