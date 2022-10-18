namespace ProlecGE.ControlPisoMX.ERP.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class TechnicalAttribute<T>
    {
        #region Properties

        public int Sequence { get; set; }

        public T Value { get; set; }

        #endregion

        #region Constructor

        public TechnicalAttribute(int sequence, T value)
        {
            Sequence = sequence;
            Value = value;
        }

        #endregion
    }

    public abstract class AttributeModel 
    {
        #region Properties

        public string Attribute { get; private set; }

        #endregion

        #region Constructor

        public AttributeModel(string attrubute)
        {
            Attribute = attrubute;
        }

        #endregion
    }

    public class WindingAttribute : AttributeModel
    {
        #region Properties

        public IEnumerable<TechnicalAttribute<string>> BTI { get; set; }

        public IEnumerable<TechnicalAttribute<string>> CoilSequence1 { get; set; }

        public IEnumerable<TechnicalAttribute<string>> CoilSequence2 { get; set; }

        public IEnumerable<TechnicalAttribute<string>> BTE { get; set; }

        #endregion

        #region Constructor

        public WindingAttribute(string attribute) : base(attribute)
        {
            BTI = Enumerable.Empty<TechnicalAttribute<string>>();
            CoilSequence1 = Enumerable.Empty<TechnicalAttribute<string>>();
            CoilSequence2 = Enumerable.Empty<TechnicalAttribute<string>>();
            BTE = Enumerable.Empty<TechnicalAttribute<string>>();
        }

        #endregion
    }

    public class CableAttribute : AttributeModel
    {
        #region Properties

        public IEnumerable<TechnicalAttribute<double>> L { get; set; }

        public IEnumerable<TechnicalAttribute<double>> CAL { get; set; }

        #endregion

        #region Constructor

        public CableAttribute(string attribute) : base(attribute)
        {
            L = Enumerable.Empty<TechnicalAttribute<double>>();
            CAL = Enumerable.Empty<TechnicalAttribute<double>>();
        }

        #endregion
    }

    public class ChangerAttribute : AttributeModel
    {
        #region Properties

        public IEnumerable<TechnicalAttribute<string>> String1 { get; set; }

        #endregion

        #region Constructor

        public ChangerAttribute(string attribute) : base(attribute)
        {
            String1 = Enumerable.Empty<TechnicalAttribute<string>>();
        }

        #endregion
    }

    public class StringAndDoubleAttribute : AttributeModel
    {
        #region Properties

        public IEnumerable<TechnicalAttribute<string>> String1 { get; set; }

        public IEnumerable<TechnicalAttribute<double>> Double1 { get; set; }

        #endregion

        #region Constructor

        public StringAndDoubleAttribute(string attribute) : base(attribute)
        {
            String1 = Enumerable.Empty<TechnicalAttribute<string>>();
            Double1 = Enumerable.Empty<TechnicalAttribute<double>>();
        }

        #endregion
    }

    public class WindingModel 
    {
        #region Properties

        public WindingAttribute? Connector { get; set; }

        public WindingAttribute? InitPoint { get; set; }

        public WindingAttribute? FinalPoint { get; set; }

        public WindingAttribute? Combo { get; set; }

        #endregion
    }

    public class ArmingAndConnectingModel
    {
        #region Properties

        public IList<CableAttribute> Cables { get; set; }

        public IList<ChangerAttribute> Changers { get; set; }

        public IList<StringAndDoubleAttribute> Fuses { get; set; }

        public IList<StringAndDoubleAttribute> Pads { get; set; }

        #endregion

        #region Constructor

        public ArmingAndConnectingModel()
        {
            Cables = new List<CableAttribute>();
            Changers = new List<ChangerAttribute>();
            Fuses = new List<StringAndDoubleAttribute>();
            Pads = new List<StringAndDoubleAttribute>();
        }

        #endregion
    }

    public class ItemLaboratoryModel
    {
        #region Properties

        public double? KVA { get; set; }

        public double PrimaryVoltage { get; set; }

        #endregion
    }
}
