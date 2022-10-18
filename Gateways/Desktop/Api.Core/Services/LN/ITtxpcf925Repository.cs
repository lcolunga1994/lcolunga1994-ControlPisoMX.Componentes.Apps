using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models;

namespace ProlecGE.ControlPisoMX.LN
{
    public interface ITtxpcf925Repository
    {
        Task<double?> KVA(int Cia, string Orden, CancellationToken cancellationToken);

        //Task<double?> Ten_Primaria(int Cia, string Orden);

        //Task<double?> Ten_Secundaria(int Cia, string Orden);
        //Task<double?> Ten_Prueba(int Cia, string Orden);
        Task<int?> V_Rev(int cia, string orden, CancellationToken cancellationToken);

        Task<ItemVoltageDesignModel?> GetItemVoltageDesignAsync(int cia, string orden, string designId, CancellationToken cancellationToken);
        Task<IEnumerable<ColorLimite>> GetColorLimte(int cia, string orden, int? v_rev, CancellationToken cancellationToken);

        Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync(int cia, string itemId, CancellationToken cancellationToken);
        Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync(int cia, string itemId, CancellationToken cancellationToken);

        Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync(int cia, string itemId, CancellationToken cancellationToken);
        Task<AluminumTipPuntasModel> GetItemAluminumTipsAsync(int cia, string itemId, CancellationToken cancellationToken);
        Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync(int cia, string itemId, CancellationToken cancellationToken);
    }
}
