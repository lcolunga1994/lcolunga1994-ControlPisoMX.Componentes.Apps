namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ProlecGE.ControlPisoMX.Cores.Models.ManufacturingOrders;

    internal static class QueryExtensions
    {
        internal static async Task<List<MOPrintableAttributeModel>> GetMOPrintableAttributesAsync(this ControlPisoMX.Insulations.IMicroservice insulations, string itemId, string batch, int serie, int sequence)
        {
            List<MOPrintableAttributeModel> printableAttributes = new();

            ControlPisoMX.Insulations.Models.ManufacturingPlanItemModel? scheduledOrder = await insulations
                .GetManufacturingPlanBySerieAsync(itemId, batch, serie, sequence, CancellationToken.None)
                .ConfigureAwait(false);

            if (scheduledOrder != null)
            {
                printableAttributes.Add(new MOPrintableAttributeModel() { Attribute = "Market", Value = scheduledOrder.Market });
            }

            return printableAttributes;
        }

        internal static async Task<List<MOPrintableAttributeModel>> GetMOPrintableAttributesAsync(this ControlPisoMX.ERP.IMicroservice erp, string itemId, string batch, int serie)
        {
            List<MOPrintableAttributeModel> printableAttributes = new();

            ERP.Models.CoresSupply.CoreSupplyTagModel? tagData = await erp
                .GetItemCoresSupplyTagDataAsync(itemId, batch, serie)
                .ConfigureAwait(false);

            if (tagData != null)
            {
                printableAttributes.Add(new MOPrintableAttributeModel() { Attribute = "ScheduledEndDate", Value = tagData.ScheduledEndDate?.ToString("dd/MM/yyyy") });
                printableAttributes.Add(new MOPrintableAttributeModel() { Attribute = "Strip", Value = tagData.Strip });
                printableAttributes.Add(new MOPrintableAttributeModel() { Attribute = "Laps", Value = tagData.Laps });
            }

            return printableAttributes;
        }
    }
}