namespace ProlecGE.ControlPisoMX.Cores.Models.Residential
{
    using System;

    public class RemoveSupplyCoreModel
    {
        #region Constructor

        public RemoveSupplyCoreModel(
            Guid id)
        {
            Id = id;
        }

        #endregion

        #region Properties

        public Guid Id { set; get; }

        #endregion
    }
}
