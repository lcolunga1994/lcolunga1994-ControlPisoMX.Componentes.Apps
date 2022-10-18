namespace ProlecGE.ControlPisoMX.ERP.Models
{
    using System;

    public class CartonShearModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public CartonShearModel(
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

        public CartonShearModel(
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

        public double? D { get; set; }

        public double? T { get; set; }

        public string? Dimensions { get; set; }

        public string? Cradle { get; set; }

        public int Sequence { get; set; }

        #endregion

        #region Methods

        public static CartonShearModel ABT(string designId, string item, string description, int quantity, int sequence, double? a, double? b, double? t)
        {
            CartonShearModel cartonShear = new(designId, item, description, sequence)
            {
                Quantity = quantity
            };
            cartonShear.SetABTDimensions(a, b, t);
            return cartonShear;
        }

        public static CartonShearModel ABT(string designId, string item, string description, int quantity, string? cradle, int sequence, double? a, double? b, double? t)
        {
            CartonShearModel cartonShear = new(designId, item, description, sequence)
            {
                Quantity = quantity,
                Cradle = cradle
            };
            cartonShear.SetABTDimensions(a, b, t);
            return cartonShear;
        }

        public static CartonShearModel LDT(string designId, string item, string description, int quantity, int sequence, double? l, double? d, double? t)
        {
            CartonShearModel cartonShear = new(designId, item, description, sequence)
            {
                Quantity = quantity
            };
            cartonShear.SetLDTDimensions(l, d, t);
            return cartonShear;
        }

        internal void SetABTDimensions(double? a, double? b, double? t)
        {
            System.Text.StringBuilder stringBuilder = new();

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

            A = a;
            B = b;
            T = t;
            Dimensions = stringBuilder.ToString();
        }

        internal void SetLDTDimensions(double? l, double? d, double? t)
        {
            System.Text.StringBuilder stringBuilder = new();

            if (l > 0d)
            {
                stringBuilder.Append($"{l}");
            }
            if (d > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{d}");
            }
            if (t > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{t}");
            }

            L = l;
            D = d;
            T = t;
            Dimensions = stringBuilder.ToString();
        }

        #endregion
    }
}