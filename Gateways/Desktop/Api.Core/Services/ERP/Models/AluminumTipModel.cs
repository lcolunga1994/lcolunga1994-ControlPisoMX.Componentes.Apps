namespace ProlecGE.ControlPisoMX.ERP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AluminumShearModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public AluminumShearModel(
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

        public AluminumShearModel(
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

        public double? T { get; set; }

        public string? Dimensions { get; set; }

        public int Sequence { get; set; }

        #endregion

        #region Methods

        public static AluminumShearModel ABT(string designId, string item, string description, int quantity, int sequence, double? a, double? b, double? t)
        {
            AluminumShearModel cartonShear = new(designId, item, description, sequence)
            {
                Quantity = quantity
            };
            cartonShear.SetABTDimensions(a, b, t);
            return cartonShear;
        }

        public static AluminumShearModel ABT(string designId, string item, string description, int quantity, string? cradle, int sequence, double? a, double? b, double? t)
        {
            AluminumShearModel cartonShear = new(designId, item, description, sequence)
            {
                Quantity = quantity
            };
            cartonShear.SetABTDimensions(a, b, t);
            return cartonShear;
        }

        public static AluminumShearModel LAT(string designId, string item, string description, int quantity, int sequence, double? l, double? a, double? t)
        {
            AluminumShearModel cartonShear = new(designId, item, description, sequence)
            {
                Quantity = quantity
            };
            cartonShear.SetLATDimensions(l,a ,t);
            return cartonShear;
        }

        internal void SetABTDimensions(double? l, double? a, double? t)
        {
            //falta dimension L 
            System.Text.StringBuilder stringBuilder = new();

            if (l > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{l}");
            }
            if (a > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{a}");
            }
            if (t > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{t}");
            }
            L = l;
            A = a;
            T = t;
            Dimensions = stringBuilder.ToString();
        }

        internal void SetLATDimensions(double? l, double? a, double? t)
        {
            //falta dimension L 
            System.Text.StringBuilder stringBuilder = new();

            if (l > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{l}");
            }
            if (a > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{a}");
            }
            if (t > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{t}");
            }

            A = a;
            L = l;
            T = t;
            Dimensions = stringBuilder.ToString();
        }

        #endregion
    }

    public class AluminumTipModel
    {
        #region Constructor

        public AluminumTipModel()
        {
            BTI = new List<string>();
            BTE = new List<string>();
        }

        #endregion

        #region Properties

        public IEnumerable<string> BTI { get; set; }

        public IEnumerable<string> BTE { get; set; }

        #endregion
    }

    public class AluminumTipPuntasModel
    {
        #region Constructor

        public AluminumTipPuntasModel()
        {
            PuntasIni = new AluminumTipModel();
            PuntasFin = new AluminumTipModel();
            Materials = new List<AluminumShearModel>();
        }

        #endregion

        #region Properties

        public AluminumTipModel PuntasIni { get; set; }

        public AluminumTipModel PuntasFin { get; set; }

        public IEnumerable<AluminumShearModel> Materials { set; get; }

        #endregion
    }


}
