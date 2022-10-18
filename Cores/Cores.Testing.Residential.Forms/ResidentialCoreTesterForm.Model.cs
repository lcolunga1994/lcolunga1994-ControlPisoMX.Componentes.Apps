namespace ProlecGE.ControlPisoMX.Cores.Testing.Residential.Forms
{
    using System;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;

    internal class ItemModel
    {
        #region Constructor

        public ItemModel(string itemId, int phases)
        {
            ItemId = itemId;
            Batch = "";
            Tag = null;
            Phases = phases;
            CoreSize = CoreSizes.Small;
            ProductLine = ProductLine.Desconocida;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public int Phases { get; set; }

        public ProductLine ProductLine { get; set; }

        public CoreSizes CoreSize { get; set; }

        public DateTime? ScheduledDate { get; set; }

        public string? Tag { get; set; }

        public int TotalCores { get; set; }

        public int TestedCores { get; set; }

        #endregion
    }

    public class CoreSizeModel : IComparable
    {
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static CoreSizeModel Small = new((int)CoreSizes.Small, "CHICA");
        public static CoreSizeModel Big = new((int)CoreSizes.Big, "GRANDE");
        public static CoreSizeModel None = new(-1, "Seleccione un tamaño");
#pragma warning restore CA2211 // Non-constant fields should not be visible

        #region Constructor

        protected CoreSizeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        #endregion

        #region Methods

        public int CompareTo(object? other)
        {
            if (other is CoreSizeModel otherValue)
            {
                return Id.CompareTo(otherValue.Id);
            }
            else if (other is CoreSizes enumValue)
            {
                return Id.CompareTo((int)enumValue);
            }

            return -1;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not CoreSizeModel otherValue)
            {
                return false;
            }

            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
    public class FormInput : System.ComponentModel.INotifyPropertyChanged
    {
        #region Fields

        private string itemId;
        private CoreSizeModel coreSize;
        private string? tag;
        private string testCode;

        #endregion

        #region Events

        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Constructor

        public FormInput()
        {
            itemId = "";
            Batch = "";
            testCode = "";
            coreSize = CoreSizeModel.None;
        }

        #endregion

        #region Properties

        public string ItemId
        {
            get => itemId;
            set
            {
                if (value?.Trim() != itemId)
                {
                    itemId = value?.Trim() ?? "";
                    NotifyPropertyChanged();
                }
            }
        }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public CoreSizeModel CoreSize
        {
            get => coreSize;
            set
            {
                if (value != coreSize)
                {
                    coreSize = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string? Tag
        {
            get => tag;
            set
            {
                if (value != tag)
                {
                    tag = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string TestCode
        {
            get => testCode;
            set
            {
                if (value != testCode)
                {
                    testCode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Methods

        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));

        #endregion
    }
}