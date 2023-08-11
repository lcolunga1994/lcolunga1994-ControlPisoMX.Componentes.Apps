namespace ProlecGE.ControlPisoMX.Cores
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Configuration;

    using Services;

    public class CalibrationStatusValidateReader : ICalibrationStatusValidateReader
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public CalibrationStatusValidateReader(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        #endregion

        #region Methods

        public async Task<bool> ReadAsync(CancellationToken cancellationToken)
        {
            bool result = true;

            try
            {
                string? dataCalibrationFolderPath = _configuration["CoreTests:DataCalibrationFolderPath"];
                string? lastTimeTestFileName = _configuration["CoreTests:LastTimeTestFileName"];

                if ((!string.IsNullOrWhiteSpace(dataCalibrationFolderPath))
                    && (!string.IsNullOrWhiteSpace(lastTimeTestFileName)))
                {
                    try
                    {
                        string inputFilePath = Path.Combine(dataCalibrationFolderPath, lastTimeTestFileName);

                        if (File.Exists(inputFilePath))
                        {
                            using FileStream fileStreamReader = File.Open(Path.Combine(dataCalibrationFolderPath, lastTimeTestFileName), FileMode.Open);
                            using StreamReader reader = new(fileStreamReader);

                            if (DateTime.TryParse(await reader.ReadLineAsync().ConfigureAwait(false), out DateTime dateTime))
                            {
                                TimeSpan dateDiff = DateTime.UtcNow.Subtract(dateTime.ToUniversalTime());

                                if (dateDiff.TotalMinutes > _configuration.GetValue<int>("CoreTests:CalibrationTimeMinutes"))
                                {
                                    result = false;
                                }
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            result = false;
                        }
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
            catch (Exception ex)
            {
                throw UserException.WithInnerException("Ocurrió un error al validar el estado de calibración de la mesa de pruebas.", ex);
            }

            return result;
        }

        #endregion
    }
}