namespace ProlecGE.ControlPisoMX.ERP.Models
{
    public class MaterialModel
    {
        #region Properties

        public string Name { get; set; }

        public string A { get; set; }

        public string B { get; set; }

        public double C { get; set; }

        #endregion

        #region Constructor

        //public MaterialModel() { }

        public MaterialModel(string name, string a, string b, double c)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(a))
            {
                throw new System.ArgumentException($"'{nameof(a)}' cannot be null or empty.", nameof(a));
            }

            if (string.IsNullOrEmpty(b))
            {
                throw new System.ArgumentException($"'{nameof(b)}' cannot be null or empty.", nameof(b));
            }

            Name = name.Trim();
            A = a.Trim();
            B = b.Trim();
            C = c;
        }

        #endregion
    }
}