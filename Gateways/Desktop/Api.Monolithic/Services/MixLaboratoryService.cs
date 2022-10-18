#nullable enable

namespace Cores.Services
{
    using Assembly.Models;

    using Cores.Models;

    using Entities;

    using Microsoft.EntityFrameworkCore;

    using Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MixLaboratoryService : BaseService
    {
        #region Constructor

        public MixLaboratoryService(DbContext context) : base(context) { }

        #endregion

        #region Methods

        public async Task<AssemblyVoltageInfo> GetVoltageDesignAsync(string designID)
        {
            var assemblyLabs = GetAssemblyLaboratoryDesign(designID);

            return new AssemblyVoltageInfo()
            {
                DesignID = designID,
                KVA = await assemblyLabs
                    .Where(e => e.Atribute2 == "KVA")
                    .LastRevision()
                    .Select(e => (decimal?)e.Decimal1)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false),
                PrimaryVoltage = await assemblyLabs
                    .Where(e => e.Atribute1 == "TENSION DE LINEA" && (e.Atribute2 == "PRIMARIO" || e.Atribute2 == "PRIMARIO POS 2"))
                    .LastRevision()
                    .Select(e => (decimal?)e.Decimal1)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false) ?? 0m,
                SecondaryVoltage = await assemblyLabs
                    .Where(e => e.Atribute1 == "TENSION DE LINEA" && e.Atribute2 == "SECUNDARIO")
                    .LastRevision()
                    .Select(e => (decimal?)e.Decimal1)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false)
            };
        }

        public async Task<AssemblyVoltageInfo?> GetOldVoltageDesignAsync(string? itemID)
        {
            itemID = itemID?.Trim();

            return await Context.Set<TblProducto>().AsNoTracking()
                .Where(e => e.Componente == "TANQUE" && e.Producto == itemID)
                .Select(e => new AssemblyVoltageInfo
                {
                    DesignID = itemID,
                    KVA = e.Kva,
                    PrimaryVoltage = null,
                    SecondaryVoltage = e.Tensec
                })
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }


        

        

        

        #endregion

        #region Functionality

        private IQueryable<DesignModel> GetAssemblyLaboratoryDesign(string designID)
        {
            return Context.GetAssemblyDesign(designID)
                .Where(e => e.TProc == "LABORATORIO")
                .ToModels();
        }

        #endregion

        #region Tests?

        

        #endregion
    }
}