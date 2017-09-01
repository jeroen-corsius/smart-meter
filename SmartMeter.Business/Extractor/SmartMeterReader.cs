using System.IO;
using System.Text;
using RJCP.IO.Ports;
using SmartMeter.Business.Interface;
using SmartMeter.Business.Interface.Extractor;

namespace SmartMeter.Business.Extractor {
  public class SmartMeterReader : IReadSmartMeter {
    public string Read() {
      StringBuilder stringBuilder = new StringBuilder();

      using (SerialPortStream serialPortStream = new SerialPortStream("COM3", 115200, 8, Parity.None, StopBits.One)) {
        serialPortStream.Open();

        using (StreamReader streamReader = new StreamReader(serialPortStream)) {
          string line = string.Empty;

          while (!line.StartsWith('!')) {
            line = streamReader.ReadLine();
            stringBuilder.AppendLine(line);
          }
        }
      }

      return stringBuilder.ToString();
    }
  }
}