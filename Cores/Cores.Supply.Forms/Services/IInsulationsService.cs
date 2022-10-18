namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.Services
{
    using System;

    public class InsulationManufactureModel
    {
        #region Constructor


        [System.Text.Json.Serialization.JsonConstructor]
        public InsulationManufactureModel(
            Guid id,
            string itemId,
            string batch,
            int quantity,
            int serie,
            int sequence,
            string machine,
            DateTime requestUtcDate,
            int priority,
            int status,
            string? dimensions)
        {
            Id = id;
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            Quantity = quantity;
            Machine = machine;
            RequestUtcDate = requestUtcDate;
            Priority = priority;
            Status = status;
            Dimensions = dimensions;
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public int Quantity { get; set; }

        public DateTime RequestUtcDate { get; set; }

        public string Machine { get; set; }

        public int Priority { get; set; }

        public int Status { get; set; }

        public string? Dimensions { get; set; }

        #endregion
    }

    /// <summary>
    /// Esta interfaz permite consultar una orden de fabricación de aislamientos.
    /// No debería existir, pero en la aplicación original, mezclan la funcionalidad de imprimir la etiqueta de aislamentos
    /// en esta pantalla que es de núcleos.
    /// </summary>
    public interface IInsulationsService
    {
        Task<InsulationManufactureModel?> GetManufacturingOrderAsync(string itemId, string batch, int serie, CancellationToken cancelationToken);
    }
}