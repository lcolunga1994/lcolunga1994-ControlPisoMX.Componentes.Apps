namespace Cores.Services
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Entities;
    using Cores.Domain.Entities;

    public class CoresTestingService : BaseService
    {
        #region Constructor

        public CoresTestingService(DbContext context) : base(context) { }

        #endregion

        #region Methods

        public async Task<CoreTestResponseModel> TestAsync(CoreTestValuesModel testValues)
        {
            if (await IsCorePatternTestPendingAsync().ConfigureAwait(false))
            {
                throw new Exception("Esta pendiente la prueba del núcleo patrón.");
            }

            if (await IsCoreTestCompletedAsync(testValues.ItemID).ConfigureAwait(false))
            {
                throw new Exception("Este codigo ya está probado y completo.");
            }

            Domain.CoreTester coreTester = new();

            Domain.CoreTestResponse response =
                coreTester.Test(new Domain.CoreTestValueModel()
                {
                    AverageVoltage = (double)testValues.AverageVoltage,
                    RMSVoltage = (double)testValues.EffectiveStress,
                    Current = (double)testValues.IExc,
                    Temperature = (double)testValues.Tem,
                    Watts = (double)testValues.WMed,
                    CoreTemperature = (double)testValues.CoreTemp,
                    KVA = (double)testValues.Voltages.KVA,
                    SecondaryVoltage = (double)testValues.Voltages.SecondaryVoltage,
                    VoltageLimits = testValues.Voltages.Colors
                        .Select(e => new CoreColorModel(e.Color, e.Min, e.Max))
                        .ToArray()
                });

            int? lastTestID = Context.Set<TblPruebasNucleo>()
                .Where(e => e.Codigo == testValues.ItemID)
                .Select(e => (int?)e.Noprueba)
                .Max();

            int pieceNumber = 0;
            int testNumber = 0;

            if (lastTestID.HasValue)
            {
                pieceNumber = (Context.Set<TblPruebasNucleo>()
                    .Where(e => e.Codigo == testValues.ItemID)
                    .Select(e => (int?)e.Nopza)
                    .Max() ?? 0) + 1;
                testNumber = lastTestID.Value + 1;
            }
            else
            {
                pieceNumber = (Context.Set<TblPruebasNucleo>()
                    .Where(e => e.Producto == testValues.ItemID && e.Lote == testValues.Batch)
                    .Select(e => (int?)e.Nopza)
                    .Max() ?? 0) + 1;
                testNumber = 1;
            }

            string testCode = "";
            var testHistoryItem = new TestHistoryItem(CoreType.Residential, testCode, testValues.ItemID, testValues.Batch, testValues.Serie)
            {
                LineType = CoreLineTypes.Poste,
                Size = CoreSizes.Small,
                ScheduledDate = DateTime.UtcNow,
                PieceNumber = pieceNumber,
                TestNumber = testNumber,
                Status = response.Status,
                CoreTemperature = -10d,
                TestVoltage = 10d,
                AverageVoltage = (double)testValues.AverageVoltage,
                RMSVoltage = (double)testValues.EffectiveStress,
                Current = (double)testValues.IExc,
                Temperature = (double)testValues.Tem,
                Watts = (double)testValues.WMed,
                KVA = (double)testValues.Voltages.KVA,
                PrimaryVoltage = 1d,
                SecondaryVoltage = (double)testValues.Voltages.SecondaryVoltage,
                CorrectedWatts = 1d,
                NewWatts = 1d,
                CurrentPercentage = 1d,
                Color = response.Color,
                //UserCode = testValues.User,
                //Ubicacion = response.Ubi,
                //FechaSec = null,
                //Letra = vlletraSec,
                //Completo = 0,
                StationID = ""
            };
            testHistoryItem.AddVoltageLimits(testValues.Voltages.Colors
                        .Select(e => new TestHistoryCoreVoltageLimit(e.Color, e.Min, e.Max))
                        .ToArray());

            //new TblPruebasNucleo()
            //{
            //    Producto = testValues.ItemID,
            //    Lote = testValues.Batch,
            //    Nopza = response.PieceNumber,
            //    Serie = serie,
            //    Codigo = testValues.Code,
            //    Tenmedia = testValues.AverageVoltage,
            //    Teneficaz = testValues.EffectiveStress,
            //    Corriente = testValues.IExc, //electricCurrent,
            //    Temp = txtTemp.Text,
            //    Wattsmed = txtWattsM.Text,
            //    Wattscorr = (decimal)Math.Round(vlWCorr, 2),
            //    Porcorr = por_Iex,
            //    Color = response.Color.PadLeft(3),
            //    Resultado = response.Result,
            //    Fecha = DateTime.Now,
            //    Usuario = testValues.User,
            //    Ubicacion = response.Ubi,
            //    Dona = testValues.Dona,
            //    FechaSec = null,
            //    Secuencia = txtSec.Text Upper,
            //    Letra = vlletraSec,
            //    Completo = 0,
            //    Tipo= "RT",
            //    Taghorno = txtTagHorno.Text,
            //    Wattscorr2 = vlWCorr_new,
            //    Temp2 = testValues.CoreTemp,
            //    IdEstacion = testValues.StationID
            //};

            return new CoreTestResponseModel(testHistoryItem);
        }

        #endregion

        #region CT Core

        public async Task<decimal[]> GetDonoutWidthsAsync(string itemID, string donout)
        {
            decimal[] widths = Array.Empty<decimal>();

            widths = await Context.Set<TblProductoTi3pp>()
                .Where(e => e.Producto == itemID)
                .Select(e => e.Ancholam)
                .ToArrayAsync()
                .ConfigureAwait(false);

            return widths;
        }

        #endregion

        #region Functionality

        private Task<bool> IsCorePatternTestPendingAsync()
        {
            throw new NotImplementedException();
        }

        private Task<bool> IsCoreTestCompletedAsync(string itemID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}