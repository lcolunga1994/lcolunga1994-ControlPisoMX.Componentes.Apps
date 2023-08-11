namespace ProlecGE.ControlPisoMX.Cores
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Timers;

    using Microsoft.Extensions.Configuration;

    using Services;

    public class CoreTestValuesFileReader : ICoreTestValuesReader
    {
        #region Fields

        private bool isTimeOut = true;
        private System.Timers.Timer aTimer;
        private readonly IConfiguration _configuration;
        private string? outputFilePath = null;

        #endregion

        #region Constructor

        public CoreTestValuesFileReader(IConfiguration configuration)
        {
            this._configuration = configuration;
            aTimer = new System.Timers.Timer();
        }

        #endregion

        #region Methods

        public async Task<CoreTestsValues> ReadAsync(double testVoltage, CancellationToken cancellationToken)
        {
            CoreTestsValues? coreTestValues = new(0, 0, 0, 0, 0);

            try
            {
                string? coreTestFolderPath = _configuration["CoreTests:FolderPath"];
                string? inputFileName = _configuration["CoreTests:InputFileName"];
                string? inputFilePath = Path.Combine(coreTestFolderPath, inputFileName);
                string? outputFileName = _configuration["CoreTests:OutputFileName"];

                outputFilePath = Path.Combine(coreTestFolderPath, outputFileName);

                if (string.IsNullOrWhiteSpace(coreTestFolderPath) ||
                    string.IsNullOrWhiteSpace(inputFileName) ||
                    string.IsNullOrWhiteSpace(outputFileName))
                {
                    throw new UserException("No se ha configurado la ruta de la carpeta donde se guardará y obtendrá la información.");
                }

                try
                {
                    if (!Directory.Exists(coreTestFolderPath))
                    {
                        Directory.CreateDirectory(coreTestFolderPath);
                    }
                }
                catch (Exception)
                {
                    throw new UserException($"No se pudo crear el directorio {coreTestFolderPath}");
                }

                if (File.Exists(inputFilePath))
                {
                    File.Delete(inputFilePath);
                }
#if !DEBUG
                if (File.Exists(outputFilePath))
                {
                    File.Delete(outputFilePath);
                }
#endif

                using FileStream? fileStream = File.Open(inputFilePath, FileMode.OpenOrCreate);
                using StreamWriter? writer = new(fileStream);

                writer.Write(testVoltage);
                writer.Close();
                fileStream.Close();
                fileStream.Dispose();

                await Task.Delay(100, cancellationToken)
                    .ConfigureAwait(false);

                SetTimer();

                if (!aTimer.Enabled)
                {
                    System.Diagnostics.Debug.WriteLine("El timer esta deshabilitado.");
                }

                do
                {
                    if (File.Exists(outputFilePath))
                    {
                        if (!IsFileLocked(new FileInfo(outputFilePath)))
                        {
                            string[] lines = await File.ReadAllLinesAsync(outputFilePath, cancellationToken).ConfigureAwait(false);

                            string? line = lines.FirstOrDefault();

                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                string[] values = line.Split(',');

                                if (values.Length > 1)
                                {
                                    lines = values;
                                }

                                if (lines.Count(l => !string.IsNullOrWhiteSpace(l)) < 5)
                                {
                                    throw new UserException("El archivo no posee la información completa.");
                                }

                                _ = double.TryParse(lines.ElementAtOrDefault(0), out double averageVoltage);
                                _ = double.TryParse(lines.ElementAtOrDefault(1), out double current);
                                _ = double.TryParse(lines.ElementAtOrDefault(2), out double watts);
                                _ = double.TryParse(lines.ElementAtOrDefault(3), out double rmsVoltage);
                                _ = double.TryParse(lines.ElementAtOrDefault(4), out double temperature);

                                coreTestValues.AverageVoltage = averageVoltage;
                                coreTestValues.Current = current;
                                coreTestValues.Watts = watts;
                                coreTestValues.RMSVoltage = rmsVoltage;
                                coreTestValues.Temperature = temperature;
                            }

                            if (File.Exists(inputFilePath))
                            {
                                File.Delete(inputFilePath);
                            }
#if !DEBUG
                            if (File.Exists(outputFilePath))
                            {
                                File.Delete(outputFilePath);
                            }
#endif
                            aTimer.Enabled = false;

                            isTimeOut = false;
                        }
                    }
                } while (aTimer.Enabled);

                if (isTimeOut)
                {
                    throw new UserException("No se ha generado el archivo de valores de medición.");
                }
            }
            catch (Exception ex)
            {
                throw UserException.WithInnerException("Ocurrió un error al leer los valores de medición.", ex);
            }

            return coreTestValues;
        }

        private static bool IsFileLocked(FileInfo file)
        {
            FileStream? stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return false;
        }

        private void SetTimer()
        {
            try
            {
                int timerSeconds = _configuration.GetValue<int>("CoreTests:CheckFileExistsTimerSeconds");

                if (timerSeconds == 0)
                {
                    throw new UserException("No se ha configurado el valor del temporizador de lectura.");
                }

                aTimer = new System.Timers.Timer(timerSeconds * 1000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = false;
                aTimer.Enabled = true;
                aTimer.Start();
            }
            catch (Exception ex)
            {
                throw UserException.WithInnerException("Ocurrió un error al establecer el tiempo máximo para obtener los valores de medición", ex);
            }
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            if (!File.Exists(outputFilePath))
            {
                isTimeOut = true;
            }
        }

        #endregion
    }

    public class CoreTestsValues
    {
        #region Properties

        public double AverageVoltage { get; set; }

        public double RMSVoltage { get; set; }

        public double Current { get; set; }

        public double Temperature { get; set; }

        public double Watts { get; set; }

        #endregion

        #region Constructor

        public CoreTestsValues(
            double averageVoltage,
            double rmsVoltage,
            double current,
            double temperature,
            double watts)
        {
            AverageVoltage = averageVoltage;
            RMSVoltage = rmsVoltage;
            Current = current;
            Temperature = temperature;
            Watts = watts;
        }

        public CoreTestsValues()
        {
        }

        #endregion
    }
}