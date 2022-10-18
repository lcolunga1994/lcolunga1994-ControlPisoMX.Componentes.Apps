namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Services
{
    using System.Threading;
    using System.Threading.Tasks;
    internal class InsulationGatewayDummy : IInsulationsService
    {
        public async Task<InsulationManufactureModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancelationToken)
            => await Task.FromResult(new InsulationManufactureModel(Guid.NewGuid(), itemId, batch, 1, serie, 1, "", DateTime.UtcNow, 1, 1, ""));
    }
}
