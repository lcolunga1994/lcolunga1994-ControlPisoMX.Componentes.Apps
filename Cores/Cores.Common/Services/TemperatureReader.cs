namespace ProlecGE.ControlPisoMX.Cores
{
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    using Services;

    public class TemperatureReader : ITemperatureReader
    {
        #region Fields

        private readonly SerialPort _serialPort;
        private readonly IConfiguration configuration;
        private bool isConnectedIR = false;
        private double temperature = -10d;

        #endregion

        #region Constructor

        public TemperatureReader(IConfiguration configuration)
        {
            _serialPort = new SerialPort();
            this.configuration = configuration;
        }

        #endregion

        #region Methods
        
        public async Task<double> ReadAsync(CancellationToken cancellationToken)
        {
            bool useSerialPort = configuration.GetValue<bool>("DeviceIR:UseSerialPort");

            if (useSerialPort)
            {
                string? serialPort = configuration.GetValue<string?>("DeviceIR:SerialPort");

                if (serialPort == null || string.IsNullOrWhiteSpace(serialPort))
                {
                    throw new UserException("No se ha configurado el puerto serial para leer la temperatura.");
                }

                await InitializeIRDeviceAsync();
                await ReadIRDeviceAsync();

                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                }
            }
            else
            {
                temperature = -10d;
            }

            return temperature;
        }

        private async Task InitializeIRDeviceAsync()
        {
            ReadConfigFileAsync();

            _serialPort.DataReceived += OnSerialPortDataReceived;

            await StartIRDeviceAsync();

            void ReadConfigFileAsync()
            {
                string serialPort = configuration.GetValue<string>("DeviceIR:SerialPort");

                _serialPort.PortName = serialPort;
                _serialPort.BaudRate = 9600;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One;
                _serialPort.DataBits = 8;
                _serialPort.Handshake = Handshake.XOnXOff;

                try
                {
                    _serialPort.Open();
                }
                catch
                {
                    throw new UserException(string.Format("El puerto {0} no existe.", serialPort));
                }
            }
        }

        private async Task ReadIRDeviceAsync()
        {
            temperature = -10;

            if (!isConnectedIR)
            {
                await StartIRDeviceAsync();
            }

            await SendCommandToSerialAsync("IR");
        }

        private async Task StartIRDeviceAsync()
        {
            await SendCommandToSerialAsync("E91");

            if (!isConnectedIR)
            {
                temperature = -10d;
            }
        }

        private async Task SendCommandToSerialAsync(string data)
        {
            try
            {
                temperature = -10d;

                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                _serialPort.Open();

                for (int i = 0; i <= data.Length - 1; i++)
                {
                    _serialPort.Write(data.Substring(i, 1));
                    await Task.Delay(100);
                }

                _serialPort.Write(Environment.NewLine);

                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                throw UserException.WithInnerException("Ocurrió un error al comunicarse con el puerto serial.", ex);
            }
        }

        private void OnSerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string serialPortData = _serialPort.ReadExisting();

                if (!string.IsNullOrEmpty(serialPortData))
                {
                    if (serialPortData.StartsWith("E"))
                    {
                        isConnectedIR = true;
                    }
                    else if (serialPortData.StartsWith("IR"))
                    {
                        int startTempIndex = serialPortData.IndexOf(":") + 1;
                        int endTempIndex = serialPortData.IndexOf(";");
                        string? temperatureGetted = serialPortData[startTempIndex..endTempIndex];
                        bool isNumber = double.TryParse(temperatureGetted, out double temperatureReceived);

                        temperature = isNumber ? temperatureReceived : -10;
                    }
                }
                else
                {
                    temperature = -10d;
                }
            }
            catch (Exception ex)
            {
                temperature = -10d;
                throw UserException.WithInnerException("Ocurrió un error al leer la temperatura.", ex);

            }
        }

        #endregion
    }
}