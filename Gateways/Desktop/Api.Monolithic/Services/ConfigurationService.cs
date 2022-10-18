namespace Cores.Services
{
    using Cores.Testing.Services;

    using Entities;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ConfigurationService : IConfigurationService
    {
        #region Properties

        private DbContext Context { get; set; }

        #endregion

        #region Constructor

        public ConfigurationService(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Methods

        public async Task<Tuple<int, int>> GetDefaultDayRangesAsync(string manufacturingLineCode)
        {
            var groupParams = Context.Set<Parametro>()
                .Where(e => e.Aplicacion == "MESA DE PRUEBAS")
                .Where(e => e.Grupoparam == "PROBADOR (POS) INICIAL");

            var initRange = await groupParams.Where(e => e.Param == "DIAS_ATRAS").Select(e => e.Val2Tnumber).FirstOrDefaultAsync() ?? 0;
            var finalRange = await groupParams.Where(e => e.Param == "DIAS_ADELANTE").Select(e => e.Val2Tnumber).FirstOrDefaultAsync() ?? 0;

            return new Tuple<int, int>(Convert.ToInt32(initRange), Convert.ToInt32(finalRange));
        }

        public async Task<Tuple<int, int>> GetDayRangesAsync(string manufacturingLineCode)
        {
            var groupParams = Context.Set<Parametro>()
                .Where(e => e.Aplicacion == "MESA DE PRUEBAS")
                .Where(e => e.Grupoparam == "PROBADOR (POS)");

            var initRange = await groupParams.Where(e => e.Param == "DIAS_ATRAS").Select(e => e.Val2Tnumber).FirstOrDefaultAsync() ?? 0;
            var finalRange = await groupParams.Where(e => e.Param == "DIAS_ADELANTE").Select(e => e.Val2Tnumber).FirstOrDefaultAsync() ?? 0;

            return new Tuple<int, int>(Convert.ToInt32(initRange), Convert.ToInt32(finalRange));
        }

        #endregion
    }
}