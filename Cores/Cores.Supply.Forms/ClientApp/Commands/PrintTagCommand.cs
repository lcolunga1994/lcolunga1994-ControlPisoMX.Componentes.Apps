namespace ProlecGE.ControlPisoMX.CoreSupply.Forms.ClientApp.Commands
{
    using System.Drawing.Printing;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Models;
    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Supply.Models;

    public class PrintTagCommand : IRequest
    {
        #region Constructor

        public PrintTagCommand(CoreManufacturingTagModel order)
        {
            Order = order;
        }

        public PrintTagCommand(MOSupplyItemTagModel supplyItemTagModel)
        {
            Order = new CoreManufacturingTagModel(
                    supplyItemTagModel.ItemId,
                    supplyItemTagModel.Batch,
                    supplyItemTagModel.Serie,
                    supplyItemTagModel.Sequence,
                    supplyItemTagModel.ScheduledDate,
                    supplyItemTagModel.Machine,
                    (ProductLine)supplyItemTagModel.ProductLine,
                    supplyItemTagModel.Line,
                    supplyItemTagModel.Attributes
                        .Where(e => e.Attribute == MOSupplyItemTagModel.Strip)
                        .Select(e => e.Value)
                        .FirstOrDefault(),
                    supplyItemTagModel.Attributes
                        .Where(e => e.Attribute == MOSupplyItemTagModel.Diameter)
                        .Select(e => e.Value)
                        .FirstOrDefault(),
                    supplyItemTagModel.Attributes
                        .Where(e => e.Attribute == MOSupplyItemTagModel.Market)
                        .Select(e => e.Value)
                        .FirstOrDefault(),
                    supplyItemTagModel.Attributes
                        .Where(e => e.Attribute == MOSupplyItemTagModel.Laps)
                        .Select(e => e.Value)
                        .FirstOrDefault(),
                    supplyItemTagModel.Attributes
                        .Where(e => e.Attribute == MOSupplyItemTagModel.ScheduledEndDate)
                        .Select(e => e.Value)
                        .FirstOrDefault()
                    );
        }

        #endregion

        #region Properties

        public CoreManufacturingTagModel Order { get; set; }

        #endregion
    }

    public class PrintTagCommandHandler : RequestHandler<PrintTagCommand>
    {
        #region Properties

        public CoreManufacturingTagModel? Order { get; set; }

        #endregion

        #region Handler
        protected override void Handle(PrintTagCommand request)
        {
            Order = request.Order;
            SendPrintTag();
        }

        #endregion

        #region Functionality

        private void SendPrintTag()
        {
            PrintDocument document = new();
            document.DefaultPageSettings.Landscape = false;
            document.PrintPage += new PrintPageEventHandler(PrintTagManufacturingHanlder);
            PrinterSettings ps = new();
            document.PrinterSettings = ps;
            document.Print();
        }

        private void PrintTagManufacturingHanlder(object sender, PrintPageEventArgs ev)
        {
            if (ev.Graphics is not null && Order is not null)
            {
                ev.Graphics.DrawString($"Linea: {Order.Line} {Order.DayColor.Trim()} {Order.ScheduledEndDate:MM/dd/yyyy} {Order.PrintDate:MM/dd/yyyy HH:mm:ss}", new Font("Arial", 8f), Brushes.Black, 10f, 5f);
                ev.Graphics.DrawString($"*{Order.ItemId}-{Order.Batch}-{Order.Serie}*", new Font("C39HrP48DhTt", 47.0f), Brushes.Black, 10f, 22f, new StringFormat());

                if (Order.ProductLine == ProductLine.Poste)
                {
                    ev.Graphics.DrawString($"{Order.Strip} Diam {Order.Dimensions} Sec: {Order.Sequence} {Order.Market} {Order.Pilot} {Order.Machine}", new Font("Arial", 8f), Brushes.Black, 10f, 107f);
                }
                else
                {
                    ev.Graphics.DrawString($"{Order.Strip} Sec: {Order.Sequence} {Order.Pilot} {Order.Machine}", new Font("Arial", 8f), Brushes.Black, 10f, 107f);
                }
            }
        }

        #endregion
    }
}