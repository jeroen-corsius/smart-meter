using System.IO;
using System.Text;
using RJCP.IO.Ports;
using SmartMeter.Business.Interface.Extractor;
using SmartMeter.Configuration;

namespace SmartMeter.Business.Extractor {
  public class SmartMeterReader : IReadSmartMeter {
    public string Read() {
      StringBuilder stringBuilder = new StringBuilder();

      using (SerialPortStream serialPortStream = _CreateSerialPortStream()) {
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

    private static SerialPortStream _CreateSerialPortStream() {
      string port = Config.Instance.SerialPort;
      int baud = Config.Instance.SerialBaud;
      int dataBits = Config.Instance.SerialDataBits;
      Parity parity = (Parity) Config.Instance.SerialParity;
      StopBits stopBits = (StopBits) Config.Instance.SerialStopBits;

      return new SerialPortStream(port, baud, dataBits, parity, stopBits);
    }
  }
}