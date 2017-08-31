namespace SmartMeter.Business.Interface.Extractor {
  public interface IWriteFile {
    IWriteFile WithContents(string contents);
    IWriteFile WithPath(string path);
    IWriteFile WithFilename(string filename);
    void Write();
  }
}