using System;
using System.IO;

namespace SmartMeter.Business {
  public class FileWriter {
    private string _Contents;
    private string _Path;
    private string _Filename;

    public FileWriter WithContents(string contents) {
      _Contents = contents;

      return this;
    }

    public FileWriter WithPath(string path) {
      _Path = path;

      return this;
    }

    public FileWriter WithFilename(string filename) {
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