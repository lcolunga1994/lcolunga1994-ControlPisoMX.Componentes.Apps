namespace ProlecGE.ControlPisoMX.Insulations.Forms.Shared.Commands
{
    using System.Drawing.Printing;

    public class PrintOrderService
    {
        #region Constructor

        public PrintOrderService(
            string itemId,
            string batch,
            int serie,
            int sequence,
            string machine,
            string? dimensions)
        {
            ItemId = itemId;
            Batch = batch;
            Serie = serie;
            Sequence = sequence;
            Machine = machine;
            Dimensions = dimensions;
        }

        #endregion

        #region Properties

        public string ItemId { get; set; }

        public string Batch { get; set; }

        public int Serie { get; set; }

        public int Sequence { get; set; }

        public string Machine { get; set; }

        public string? Dimensions { get; set; }

        #endregion

        #region Methods

        public void Print()
        {
            PrintDocument document = new();
            document.DefaultPageSettings.Landscape = false;
            document.PrintPage += new PrintPageEventHandler(PrintTagManufacturingHanlder);
            PrinterSettings ps = new();
            document.PrinterSettings = ps;
            document.Print();
        }

        #endregion

        #region Functionality

        private void PrintTagManufacturingHanlder(object sender, PrintPageEventArgs ev)
        {
            if (ev.Graphics is not null)
            {
                Font printFont = new("IDAutomationC39S", 10f);
                Font printFontUnder = new("Arial", 8f, FontStyle.Underline);
                Font printFontBold = new("Arial", 12f, FontStyle.Bold);
                Font printFontArial = new("Arial", 8f);
                Brush brush = Brushes.Black;
                ev.Graphics.DrawString("", printFont, brush, 0f, 0f, new StringFormat());
                ev.Graphics.DrawString($"*{ItemId}-{Batch}-{Serie}*", printFont, brush, 32, 9, new StringFormat());
                ev.Graphics.DrawString($"{ItemId}-{Batch}-{Serie}", printFontBold, brush, 52f, 39f, new StringFormat());
                ev.Graphics.DrawString("MAQ :", printFontArial, brush, 9f, 59f, new StringFormat());
                ev.Graphics.DrawString($" {Machine.Trim()}", printFontUnder, brush, 36f, 59f, new StringFormat());
                ev.Graphics.DrawString("SEQ :", printFontArial, brush, 69f, 59f, new StringFormat());
                ev.Graphics.DrawString(Sequence.ToString(), printFontUnder, brush, 99f, 59f, new StringFormat());
                ev.Graphics.DrawString("DIM :", printFontArial, brush, 150f, 59f, new StringFormat());
                ev.Graphics.DrawString(Dimensions, printFontUnder, brush, 180f, 59f, new StringFormat());
                ev.Graphics.DrawString("DEV: _________ CB: _________ ARM: _________", printFontArial, Brushes.Black, 9f, 81f, new StringFormat());
                ev.Graphics.DrawString("CAT: _________  CBT: _________", printFontArial, Brushes.Black, 9f, 103f, new StringFormat());
            }
        }

        #endregion
    }
}