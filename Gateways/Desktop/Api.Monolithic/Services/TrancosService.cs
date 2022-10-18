using Cores.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Cores.Services
{
    public interface ITrancosService
    {

    }

    public class TrancosService : ITrancosService
    {
        public DbContext TrancosContext { get; }

        public TrancosService(DbContext trancosContext)
        {
            TrancosContext = trancosContext;
        }


        public async Task<string[]> GetCoreCodesAsync()
        {
            var codes = await TrancosContext.Database.GetDbConnection().QueryAsync<string>("SELECT [Etiqueta] FROM Registro_Trancos WHERE EnMP = 0 AND Fecha <= DATEADD(hh,-10,GETDATE()) order by Etiqueta Asc;").ConfigureAwait(false);
            return codes.ToArray();
            //return await Task.FromResult(new string[]
            //{
            //    "C0799013",
            //    "C0799014",
            //    "C0799015",
            //    "C0799016",
            //    "C0799017",
            //    "C0799018",
            //    "C0799019",
            //    "C0799020",
            //    "C0799021",
            //    "C0799102",
            //    "C0799103",
            //    "C0799104",
            //    "C0799105",
            //    "C0799106"
            //}).ConfigureAwait(false);
        }

        public async Task<ScheduledCoreModel?> GetScheduledCoreAsync(string coreCode)
        {
            ScheduledCoreModel? scheduledCore = null;

            scheduledCore = (await TrancosContext.Database.GetDbConnection()
                .QueryAsync<RegistroTranco>($"SELECT [RT].[Orden], [RT].[Lote], [RT].[Secuencia], [RT].[Dona_Grande], [RT].[Dona_Chica], [RT].[Reproceso], [RT].[Fecha] FROM [dbo].[Registro_Trancos] AS [RT] WHERE [RT].[Etiqueta] = '{coreCode}'")
                .ConfigureAwait(false))
                .Select(e => new ScheduledCoreModel()
                {
                    Code = e.Orden,
                    Batch = e.Lote,
                    Sequence = e.Secuencia,
                    LineType = CoreLineTypes.Poste,
                    Size = CoreSizes.Small,
                    ScheduledDate = e.Fecha
                })
                .FirstOrDefault();

            return scheduledCore;
        }
    }

    public class RegistroTranco
    {
        #region Properties

        public string Orden { get; set; }

        public string Lote { get; set; }

        public int Secuencia { get; set; }

        public bool Dona_Grande { get; set; }

        public bool Dona_Chica { get; set; }

        public DateTime Fecha { get; set; }

        #endregion
    }
}