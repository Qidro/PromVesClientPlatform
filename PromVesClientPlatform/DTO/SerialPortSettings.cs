using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace PromVesClientPlatform.DTO
{
    public class ConfigurationSetting
    {
        public List<SerialPortSettings> SerialPorts { get; set; } = new();
    }
    public class SerialPortSettings
    {
        public int Id { get; set; }

        public string PortName { get; set; } = string.Empty;

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public Parity Parity { get; set; }

        public StopBits StopBits { get; set; }

        public Handshake Handshake { get; set; }
    }
}
