using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models;

namespace ProlecGE.ControlPisoMX.LN.Api
{
    public class Ttxpcf925Repository : Http.WebApiClient, ITtxpcf925Repository
    {
        private readonly ILogger<Ttxpcf925Repository> logger;
        public Ttxpcf925Repository(HttpClient httpClient, ILogger<Ttxpcf925Repository> logger) : base(httpClient)
        {
            this.logger = logger;
            ApiRouteName = "api/LnApi";
        }
        public async Task<double?> KVA(int cia, string orden, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el KVA de '{orden}' en cia: '{cia}'.");

                return await GetAsync<double?>(
                    $"ttxpcf925/KVA/{cia}/{orden}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el KVA de '{orden}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "KVA");
            }
        }

        public async Task<int?> V_Rev(int cia, string orden, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el KVA de '{orden}' en cia: '{cia}'.");

                return await GetAsync<int?>(
                    $"ttxpcf925/V_Rev/{cia}/{orden}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el KVA de '{orden}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "KVA");
            }
        }

        public async Task<IEnumerable<ColorLimite>> GetColorLimte(int cia, string orden, int? v_rev, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el ColorLimite de '{orden}' en cia: '{cia}' con v_rev:'{v_rev}'.");

                return (await GetAsync<IEnumerable<ColorLimite>>(
                    $"ttxpcf925/GetColorLimte/{cia}/{orden}/{v_rev}"
                    , cancellationToken)
                .ConfigureAwait(false)) ?? Enumerable.Empty<ColorLimite>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el ColorLimite de '{orden}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "ColorLimite");
            }
        }

        public async Task<ItemVoltageDesignModel?> GetItemVoltageDesignAsync(int cia, string orden, string _designId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el GetItemVoltageDesignAsync de '{orden}' en cia: '{cia}'.");

                return await GetAsync<ItemVoltageDesignModel?>(
                    $"ttxpcf925/GetItemVoltageDesignAsync/{cia}/{orden}/{_designId}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el GetItemVoltageDesignAsync de '{orden}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "GetItemVoltageDesignAsync");
            }
        }

        //public async Task<double?> Ten_Primaria(int Cia, string Orden)
        //{
        //    double? ten_primaria;
        //    switch (Cia)
        //    {
        //        case 115:
        //            ten_primaria = await _db.Ttxpcf925115s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        case 116:
        //            ten_primaria = await _db.Ttxpcf925116s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        case 117:
        //            ten_primaria = await _db.Ttxpcf925117s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        case 118:
        //            ten_primaria = await _db.Ttxpcf925118s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        case 715:
        //            ten_primaria = await _db.Ttxpcf925715s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        case 716:
        //            ten_primaria = await _db.Ttxpcf925716s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        case 717:
        //            ten_primaria = await _db.Ttxpcf925717s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        case 718:
        //            ten_primaria = await _db.Ttxpcf925718s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && (x.TAtr2 == "PRIMARIO" || x.TAtr2 == "PRIMARIO POS 2")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_primaria;
        //        default:
        //            return null;
        //    }
        //}

        //public async Task<double?> Ten_Secundaria(int Cia, string Orden)
        //{
        //    double? ten_secundaria;
        //    switch (Cia)
        //    {
        //        case 115:
        //            ten_secundaria = await _db.Ttxpcf925115s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        case 116:
        //            ten_secundaria = await _db.Ttxpcf925116s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        case 117:
        //            ten_secundaria = await _db.Ttxpcf925117s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        case 118:
        //            ten_secundaria = await _db.Ttxpcf925118s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        case 715:
        //            ten_secundaria = await _db.Ttxpcf925715s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        case 716:
        //            ten_secundaria = await _db.Ttxpcf925716s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        case 717:
        //            ten_secundaria = await _db.Ttxpcf925717s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        case 718:
        //            ten_secundaria = await _db.Ttxpcf925718s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "ENS" && x.TProc == "LABORATORIO" && x.TAtr1 == "TENSION DE LINEA"
        //            && x.TAtr2 == "SECUNDARIO").Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_secundaria;
        //        default:
        //            return null;
        //    }
        //}

        //public async Task<double?> Ten_Prueba(int Cia, string Orden)
        //{
        //    double? ten_prueba;
        //    switch (Cia)
        //    {
        //        case 115:
        //            ten_prueba = await _db.Ttxpcf925115s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        case 116:
        //            ten_prueba = await _db.Ttxpcf925116s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        case 117:
        //            ten_prueba = await _db.Ttxpcf925117s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        case 118:
        //            ten_prueba = await _db.Ttxpcf925118s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        case 715:
        //            ten_prueba = await _db.Ttxpcf925715s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        case 716:
        //            ten_prueba = await _db.Ttxpcf925716s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        case 717:
        //            ten_prueba = await _db.Ttxpcf925717s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        case 718:
        //            ten_prueba = await _db.Ttxpcf925718s.Where(x => x.TItem == Orden
        //            && x.TNcmp == Cia && x.TCwoc == "NUC" && x.TAtr1 == "TENSION DE PRUEBA"
        //            && EF.Functions.Like(x.TProc, "INSPECCION PRUEBAS%")).Select(x => x.TNva1).FirstOrDefaultAsync();
        //            return ten_prueba;
        //        default:
        //            return null;
        //    }
        //}

        private static UserException CreateServiceException(string message, string errorCode)
        {
            System.Text.StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(message);
            stringBuilder.AppendLine("Ocurrió un error en el servidor.");
            stringBuilder.AppendLine($"Contacte al area de sistemas ({errorCode}).");
            throw new UserException(stringBuilder.ToString(), errorCode, true);
        }

        public async Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync(int cia, string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el GetItemGuillotineShearsAsync de '{itemId}' en cia: '{cia}'.");

                return await GetAsync<IEnumerable<GuillotineShearModel>>(
                    $"insulations/guillotineShears/{cia}/{itemId}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el GetItemGuillotineShearsAsync de '{itemId}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "GetItemGuillotineShearsAsync");
            }
        }

        public async Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync(int cia, string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el GetItemSierraShearsAsync de '{itemId}' en cia: '{cia}'.");

                return await GetAsync<IEnumerable<SierraShearModel>>(
                    $"insulations/getItemSierraShearsAsync/{cia}/{itemId}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el GetItemSierraShearsAsync de '{itemId}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "GetItemSierraShearsAsync");
            }
        }

        public async Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync(int cia, string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el GetItemCartonShearsAsync de '{itemId}' en cia: '{cia}'.");

                return await GetAsync<IEnumerable<CartonShearModel>>(
                    $"insulations/cartonShears/{cia}/{itemId}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el GetItemCartonShearsAsync de '{itemId}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "GetItemCartonShearsAsync");
            }
        }

        public async Task<AluminumTipPuntasModel> GetItemAluminumTipsAsync(int cia, string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el GetItemAluminumTipsAsync de '{itemId}' en cia: '{cia}'.");

                return await GetAsync<AluminumTipPuntasModel>(
                    $"insulations/aluminumShears/{cia}/{itemId}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el GetItemAluminumTipsAsync de '{itemId}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "GetItemAluminumTipsAsync");
            }
        }

        public async Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync(int cia, string itemId, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation($"Consultando el GetItemAluminiumCutsAsync de '{itemId}' en cia: '{cia}'.");

                return await GetAsync<IEnumerable<AluminiumCutModel>>(
                    $"insulations/aluminiumCuts/{cia}/{itemId}"
                    , cancellationToken)
                .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Ocurrió un error al consultar el GetItemAluminiumCutsAsync de '{itemId}' en cia: '{cia}'.");

                if (ex is UserException)
                {
                    throw;
                }

                throw CreateServiceException(
                    "No se puede consultar la información del artículo en este momento.",
                    "GetItemAluminiumCutsAsync");
            }
        }

    }
}
