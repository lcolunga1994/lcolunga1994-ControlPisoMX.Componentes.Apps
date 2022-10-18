namespace ProlecGE.ControlPisoMX.ERP.Models
{
    using System;

    public class ManufacturingPlanItemModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public ManufacturingPlanItemModel(
            string item,
            string batch,
            int serie,
            int sequence)
        {
            Item = item;
            Batch = batch ;
            Serie = serie;
            Sequence = sequence;
        }

        #endregion

        #region Properties

        public string Item { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        #endregion
        
    }
}