namespace ProlecGE.ControlPisoMX.Insulations.Forms.Utils
{
    using System;

    #region Notification models

    public class ManufacturingOrderModel
    {
        #region Constructor

        //public ManufacturingOrderModel(string itemId, string batch, int quantity, string machine, DateTime startDateUtc)
        //{
        //    ItemId = itemId;
        //    Batch = batch;
        //    Quantity = quantity;
        //    Machine = machine;
        //    StartUtcDate = startDateUtc;
        //}

        #endregion

        #region Properties

        public string ItemId { get; set; } = null!;

        public string Batch { get; set; } = null!;

        public string Machine { get; set; } = null!;

        public int Quantity { get; set; }

        public DateTime StartUtcDate { get; set; }

        #endregion
    }

    public class ManufacturingOrderAddedModel
    {
        #region Constructor

        public ManufacturingOrderAddedModel(
            Guid id,
            string itemId,
            string batch,
            int serie,
            string machine,
            int quantity,
            int priority,
            DateTime requestUtcDate,
            int status)
        {
            Id = id;
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Machine = machine;
            Quantity = quantity;
            Priority = priority;
            RequestUtcDate = requestUtcDate;
            Status = status;
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public string Machine { get; set; }

        public int Quantity { get; set; }

        public int Priority { get; set; }

        public DateTime RequestUtcDate { get; set; }

        public int Status { get; set; }

        #endregion
    }

    public class ManufacturingOrderPriorityChangedModel
    {
        #region Constructor

        public ManufacturingOrderPriorityChangedModel(
            Guid id,
            int oldPriority,
            int priority)
        {
            Id = id;
            OldPriority = oldPriority;
            Priority = priority;
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        public int OldPriority { get; set; }

        public int Priority { get; set; }

        #endregion
    }

    #endregion
}