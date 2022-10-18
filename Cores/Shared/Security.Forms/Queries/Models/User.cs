namespace ProlecGE.ControlPisoMX.Identity.Models
{
    public class User
    {
        #region Constructor

        public User()
        {
            Applications = new List<string>();
        }

        #endregion

        #region Properties

        public string UserName { get; set; } = null!;

        public string? Name { get; set; }

        public string? Area { get; set; }

        public bool IsCodbar { get; set; }

        public bool IsReasignam { get; set; }

        public string Line { set; get; } = string.Empty;

        public bool CanReprint { get; set; }

        public IEnumerable<string> Applications { get; set; }

        #endregion
    }
}