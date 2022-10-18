using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProlecGE.ControlPisoMX.BFWeb.Components.Services.LN.Models
{
    public class GuillotineShearModel
    {
        #region Constructor

        [System.Text.Json.Serialization.JsonConstructor]
        public GuillotineShearModel(
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

        public GuillotineShearModel(
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

        public double? A { get; set; }

        public double? B { get; set; }

        public double? Y { get; set; }

        public double? T { get; set; }

        public string? Dimensions { get; set; }

        public string? Fold { get; set; }

        public int Sequence { get; set; }

        #endregion

        #region Methods

        public static GuillotineShearModel ABTY(string designId, string item, string description, int quantity, string? fold, int sequence, double? a, double? b, double? t, double? y)
        {
            GuillotineShearModel guillotineShear = new(designId, item, description, sequence, fold)
            {
                Quantity = quantity,
                Fold = fold
            };
            guillotineShear.SetABTYDimensions(a, b, t, y);
            return guillotineShear;
        }

        internal void SetABTYDimensions(double? a, double? b, double? t, double? y)
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
            if (y > 0d)
            {
                stringBuilder.Append($"{(stringBuilder.Length > 0 ? " x " : "")}{y}");
            }
            A = a;
            B = b;
            T = t;
            Y = y;

            Dimensions = stringBuilder.ToString();
        }

        #endregion
    }
}
