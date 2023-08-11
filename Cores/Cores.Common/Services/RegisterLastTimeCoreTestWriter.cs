namespace ProlecGE.ControlPisoMX.Cores
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    using Services;

    public class RegisterLastTimeCoreTestWriter : IRegisterLastTimeCoreTestWriter
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public RegisterLastTimeCoreTestWriter(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task WriteAsync(CancellationToken cancellationToken)
        {
            string? dataCalibrationFolderPath = _configuration["CoreTests:DataCalibrationFolderPath"];
            string? lastTimeTestFileName = _configuration["CoreTests:LastTimeTestFileName"];

            if ((!string.IsNullOrWhiteSpace(dataCalibrationFolderPath))
                && (!string.IsNullOrWhiteSpace(lastTimeTestFileName)))
            {
                try
                {
                    string inputFilePath = Path.Combine(dataCalibrationFolderPath, lastTimeTestFileName);

                    if (!File.Exists(inputFilePath))
                    {
                        Directory.CreateDirectory(dataCalibrationFolderPath);
                    }

                    using FileStream fileStream = File.Open(inputFilePath, FileMode.OpenOrCreate);
                    using StreamWriter writer = new(fileStream, System.Text.Encoding.UTF8);

                    await writer.WriteAsync(DateTime.UtcNow.ToString("u")).ConfigureAwait(false);
                }
                catch (FileNotFoundException ex)
                {
                    throw UserException.WithInnerException($"Actualmente no posee privilegios para acceder a la siguiente ruta {dataCalibrationFolderPath}", ex);
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw UserException.WithInnerException($"Actualmente no posee privilegios para acceder a la siguiente ruta {dataCalibrationFolderPath}", ex);
                }
            }
            else
            {
                throw new UserException("No se ha configurado la ruta del archivo de registro del tiempo de calibración.");
            }
        }

        #endregion
    }
}