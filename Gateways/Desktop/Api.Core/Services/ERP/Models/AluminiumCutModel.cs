namespace ProlecGE.ControlPisoMX.ERP.Models
{
    using System;

    public class AluminiumCutModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public AluminiumCutModel(
            string designId,
            string? item,
            string description,
            int sequence)
        {
            if (string.IsNullOrWhiteSpace(designId))
            {
                throw new ArgumentException($"El identificador del diseño no debe ser vacío o solo espacios.", nameof(designId));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException($"La descripción no debe ser vacía o solo espacios.", nameof(description));
            }

            DesignId = designId;
            Item = item;
            Description = description;
            Sequence = sequence;
        }

        public AluminiumCutModel(
            string designId,
            string? item,
            string description,
            int sequence,
            string? dimensions) : this(designId, item, description, sequence)
        {
            Sequence = sequence;
            Dimensions = dimensions;
        }

        #endregion

        #region Properties

        public string DesignId { get; set; }

        public string? Item { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public double? L { get; set; }

        public double? A { get; set; }

        public double? B { get; set; }

        public double? T { get; set; }

        public string? Dimensions { get; set; }

        public string? String1 { get; set; }

        public int Sequence { get; set; }

        #endregion

        #region Methods

        public static AluminiumCutModel LABT(string designId, string item, string description, int quantity ,int sequence, double? l, double? a, double? b, double? t, string? string1)
        {
            AluminiumCutModel aluminiumCuts = new(designId, item, description, sequence)
            {
                Quantity = quantity,
                String1 = string1
            };
            aluminiumCuts.SetLABTDimensions(l,a, b, t);
            return aluminiumCuts;
        }

        internal void SetLABTDimensions(double? l,double? a, double? b, double? t)
        {
            System.Text.StringBuilder stringBuilder = new();

            if (l > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{l}");

                if (a > 0d)
                {
                    stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{a}");
                }
                if (t > 0d)
                {
                    stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{t}");
                }
            }
            else
            {
                if (a > 0d)
                {
                    stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{a}");
                }
                if (b > 0d)
                {
                    stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{b}");
                }
                if (t > 0d)
                {
                    stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{t}");
                }

            }

            L = l;
            A = a;
            B = b;
            T = t;

            Dimensions = stringBuilder.ToString();
        }
        
        #endregion
    }
}