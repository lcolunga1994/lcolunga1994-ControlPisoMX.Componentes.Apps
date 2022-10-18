namespace ProlecGE.ControlPisoMX.Insulations.Models
{
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
}