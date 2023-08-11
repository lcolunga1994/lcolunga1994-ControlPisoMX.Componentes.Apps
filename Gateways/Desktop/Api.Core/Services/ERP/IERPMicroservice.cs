namespace ProlecGE.ControlPisoMX.ERP
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Models;

    public interface IMicroservice
    {
        #region Item

        Task<ItemModel?> GetItemAsync(
            string itemId,
            CancellationToken cancellationToken);
        Task<ItemModel?> GetItemAsync_discpiso(
            string itemId,
            CancellationToken cancellationToken);

        Task<ItemModel?> GetItemGeneralDataAsync(
            string itemId,
            CancellationToken cancellationToken);

        #endregion

        #region Orders

        Task<ManufacturingOrderModel?> GetManufacturingOrderAsync(string itemId, string batch, CancellationToken cancellationToken);
        Task<ManufacturingOrderModel?> GetManufacturingOrderAsync_sqlctp(string itemId, string batch, CancellationToken cancellationToken);

        Task<bool> GetManufacturingProgramValidationAsync(string itemId, string batch, CancellationToken cancellationToken);


        #endregion

        #region Cores

        Task<ItemVoltageDesignModel?> GetItemVoltageDesignAsync(
            string itemId,
            string designId,
            int coreSize,
            CancellationToken cancellationToken);
        Task<ItemVoltageDesignModel?> GetItemVoltageDesignAsync_LN(
           string itemId,
           string designId,
           int coreSize,
           int cia,
           CancellationToken cancellationToken);


        #region Cores supply

        Task<Models.CoresSupply.CoreSupplyTagModel?> GetItemCoresSupplyTagDataAsync(string itemId, string batch, int serie);
        Task<Models.CoresSupply.CoreSupplyTagModel?> GetItemCoresSupplyTagDataAsync_LN(string itemId, string batch, int serie, int cia);

        #endregion

        #endregion

        #region Insulations

        Task<string> GetMachineManufacturingAsync
            (string itemId,
            string batch,
            int serie,
            int sequence,
            CancellationToken cancellationToken);

        Task<string?> GetItemDimensionsAsync(
            string itemId,
            CancellationToken cancellationToken);

        Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync(
            string itemId,
            CancellationToken cancellationToken);
        Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync_LN(
            string itemId,int cia,
            CancellationToken cancellationToken);
        Task<IEnumerable<CartonShearModel>> GetItemCartonShearsAsync_sqlctp(
            string itemId,
            CancellationToken cancellationToken);

        Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync(
           string itemId,
           CancellationToken cancellationToken);
        Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync_LN(
            string itemId, int cia, 
            CancellationToken cancellationToken);
        Task<IEnumerable<GuillotineShearModel>> GetItemGuillotineShearsAsync_sqlctp(
           string itemId,
           CancellationToken cancellationToken);

        Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync(
            string itemId,
            CancellationToken cancellationToken);
        Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync_LN(
            string itemId,int cia,
            CancellationToken cancellationToken);
        Task<IEnumerable<SierraShearModel>> GetItemSierraShearsAsync_sqlctp(
            string itemId,
            CancellationToken cancellationToken);

        Task<AluminumTipPuntasModel?> GetItemAluminumTipsAsync(
            string itemId,
            CancellationToken cancellationToken);
        Task<AluminumTipPuntasModel?> GetItemAluminumTipsAsync_LN(
            string itemId,int cia,
            CancellationToken cancellationToken);

        Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync(
            string itemId,
            CancellationToken cancellationToken);
        Task<IEnumerable<AluminiumCutModel>> GetItemAluminiumCutsAsync_LN(
            string itemId,int cia,
            CancellationToken cancellationToken);
        #endregion

        #region Assembly

        Task<IEnumerable<MaterialModel>> GetMaterialsAsync(
            string itemId,
            CancellationToken cancellationToken);

        Task<IEnumerable<string>> GetNotesAsync(
            string designId,
            CancellationToken cancellationToken);

        Task<IEnumerable<PositionModel>> GetPositionsAsync(
            string designId,
            CancellationToken cancellationToken);

        Task<IEnumerable<AccessoryModel>> GetAccessoriesAsync(
            string itemId,
            CancellationToken cancellationToken);

        #endregion

        #region Clamps

        Task<IEnumerable<ItemClampModel>> GetItemClampsAsync(string itemId, CancellationToken cancellationToken);
        Task<IEnumerable<ItemClampModel>> GetItemClampsAsync_LN(string itemId, int cia, CancellationToken cancellationToken);

        Task<string> GetItemMarketAsync(string itemId, CancellationToken cancellationToken);

        #endregion

        #region InspectionCMS

        Task<WindingModel?> GetWindingAsync(string itemId);

        Task<ArmingAndConnectingModel?> GetArmingAndConnectingAsync(string itemId);

        Task<ItemLaboratoryModel?> GetLaboratoryAsync(string itemId);

        Task<IEnumerable<ItemLVConnectorModel>> GetLVConnectorAsync(string itemId);

        #endregion

        #region Combo

        Task<IEnumerable<ComboOrderDesignModel>> GetComboOrderDesignAsync(string itemId, CancellationToken cancellationToken);

        #endregion

        #region Guillotine

        Task<TankGuillotineModel?> GetItemTankInfoAsync(string itemId, CancellationToken cancellationToken);

        #endregion
    }
}