namespace ProlecGE.ControlPisoMX.Insulations.Forms.Utils
{
    internal static class DataGridViewExtensions
    {
        public static void ApplyMaterialStyle(this DataGridView dataGridView)
        {
            Font defaultColumnHeaderCellFont = dataGridView.ColumnHeadersDefaultCellStyle.Font;
            dataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(dataGridView.ColumnHeadersDefaultCellStyle)
            {
                Font = new Font(
                    defaultColumnHeaderCellFont.Name,
                    20F,
                    defaultColumnHeaderCellFont.Style,
                    defaultColumnHeaderCellFont.Unit,
                    defaultColumnHeaderCellFont.GdiCharSet,
                    defaultColumnHeaderCellFont.GdiVerticalFont)
            };

            Font defaultCellFont = dataGridView.DefaultCellStyle.Font;
            dataGridView.DefaultCellStyle = new DataGridViewCellStyle(dataGridView.DefaultCellStyle)
            {
                Font = new Font(
                    defaultCellFont.Name,
                    20F,
                    defaultCellFont.Style,
                    defaultCellFont.Unit,
                    defaultCellFont.GdiCharSet,
                    defaultCellFont.GdiVerticalFont)
            };

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.MultiSelect = false;
        }

        public static void SetColumnContentAlign(this DataGridView dataGridView, DataGridViewContentAlignment contentAlignment, params string[] dataPropertyNames)
        {
            IEnumerable<DataGridViewColumn> columns = dataGridView.Columns
                .OfType<DataGridViewColumn>()
                .Where(c => dataPropertyNames.Contains(c.DataPropertyName));

            foreach (DataGridViewColumn grColumn in columns)
            {
                grColumn.HeaderCell.Style.Alignment = contentAlignment;
                grColumn.DefaultCellStyle.Alignment = contentAlignment;
            }
        }

        public static void SetAllColumnsContentAlign(this DataGridView dataGridView, DataGridViewContentAlignment contentAlignment)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderCell.Style.Alignment = contentAlignment;
                column.DefaultCellStyle = new DataGridViewCellStyle(dataGridView.DefaultCellStyle)
                {
                    Alignment = contentAlignment
                };
            }
        }
    }
}