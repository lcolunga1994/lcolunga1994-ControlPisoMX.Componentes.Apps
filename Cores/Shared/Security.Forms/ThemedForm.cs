﻿namespace ProlecGE.ControlPisoMX.Security.Forms
{
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ThemedForm : Form
    {
        #region Fields

        private bool isDark = false;

        #endregion

        #region Properties

        public Color SecondaryBackColor { get; set; }

        public Color EnergyGreenColor { get; set; }

        public Color GreenColor { get; set; }

        public Color YellowColor { get; set; }

        public Color RedColor { get; set; }

        public Color PurpleColor { get; set; }

        public Color AccentColor { get; set; }

        #endregion

        #region Constructor

        public ThemedForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Functionality

        public void UseLightTheme()
        {
            isDark = false;
            BackColor = Color.White;
            SecondaryBackColor = Color.FromArgb(243, 243, 243);
            ForeColor = Color.FromArgb(0, 0, 40);
            EnergyGreenColor = Color.FromArgb(25, 255, 132);
            GreenColor = Color.FromArgb(53, 194, 42);
            YellowColor = Color.FromArgb(255, 203, 33);
            RedColor = Color.FromArgb(247, 21, 21);
            AccentColor = Color.FromArgb(136, 84, 255);
            PurpleColor = Color.FromArgb(136, 84, 255);
            ApplyTheme(Controls);
        }

        public void UseDarkTheme()
        {
            isDark = true;
            BackColor = Color.Black;
            SecondaryBackColor = Color.Black;
            ForeColor = Color.White;
            EnergyGreenColor = Color.FromArgb(25, 255, 132);
            GreenColor = Color.FromArgb(53, 194, 42);
            YellowColor = Color.FromArgb(255, 203, 33);
            RedColor = Color.FromArgb(247, 21, 21);
            AccentColor = Color.FromArgb(136, 84, 255);
            PurpleColor = Color.FromArgb(136, 84, 255);
            ApplyTheme(Controls);
        }

        private void ApplyTheme(Control.ControlCollection controls)
        {
            foreach (Label label in controls.OfType<Label>())
            {
                ApplyLabelTheme(label);
            }
            foreach (TextBox textBox in controls.OfType<TextBox>())
            {
                ApplyTextBoxTheme(textBox);
            }
            foreach (Button label in controls.OfType<Button>())
            {
                ApplyButtonTheme(label);
            }
            foreach (DataGridView dataGridView in controls.OfType<DataGridView>())
            {
                ApplyGridViewTheme(dataGridView);
            }
            foreach (ContainerControl containerControl in controls.OfType<ContainerControl>())
            {
                ApplyTheme(containerControl.Controls);
            }
            foreach (Panel containerControl in controls.OfType<Panel>())
            {
                ApplyTheme(containerControl.Controls);
            }
            foreach (GroupBox containerControl in controls.OfType<GroupBox>())
            {
                containerControl.ForeColor = ForeColor;
                ApplyTheme(containerControl.Controls);
            }
        }

        public void ApplyLabelTheme(Label label) => label.ForeColor = ForeColor;

        public void ApplyLabelThemeBackground(Label label) => label.BackColor = SecondaryBackColor;

        public void ApplyLabelThemeAccentColor(Label label) => label.ForeColor = AccentColor;

        public void ApplyLabelThemeGreenColor(Label label) => label.ForeColor = GreenColor;

        public void ApplyTextBoxTheme(TextBox textBox)
        {
            textBox.ForeColor = ForeColor;
            textBox.BackColor = BackColor;
        }

        public void ApplyButtonTheme(Button button)
        {
            button.ForeColor = Color.White;
            button.BackColor = AccentColor;
            button.Font = new Font(button.Font, FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = AccentColor;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(101, 50, 218);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(136, 84, 255);
        }

        public void ApplyGridViewTheme(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = BackColor;
            dataGridView.GridColor = isDark ? Color.FromArgb(73, 73, 74) : Color.FromArgb(217, 217, 217);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.BorderStyle = isDark ? BorderStyle.None : BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(dataGridView.ColumnHeadersDefaultCellStyle)
            {
                Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = EnergyGreenColor,
                BackColor = BackColor,
                Padding = new Padding(0, 5, 0, 5),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                WrapMode = DataGridViewTriState.True
            };
            dataGridView.DefaultCellStyle = new DataGridViewCellStyle(dataGridView.DefaultCellStyle)
            {
                Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point),
                BackColor = BackColor,
                Padding = new Padding(0, 5, 0, 5),
                SelectionBackColor = BackColor,
                SelectionForeColor = ForeColor,
            };
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            if (!dataGridView.Columns.OfType<DataGridViewColumn>().Any(c => c.Frozen))
            {
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public void ApplySecondaryButtonTheme(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font(button.Font, FontStyle.Bold);
            button.ForeColor = AccentColor;
            button.BackColor = BackColor;
            button.FlatAppearance.BorderColor = AccentColor;
            button.FlatAppearance.MouseOverBackColor = isDark ? Color.FromArgb(1, 1, 74) : Color.FromArgb(235, 226, 255);
            button.FlatAppearance.MouseDownBackColor = AccentColor;
        }

        public void ApplyStandarImages(PictureBox logo, PictureBox line)
        {
            if (isDark)
            {
                logo.Image = new Bitmap(Properties.Resources.prolecge_dark);
                line.Image = new Bitmap(Properties.Resources.title_line_white);
            }
            else
            {
                logo.Image = new Bitmap(Properties.Resources.prolecge_white);
                line.Image = new Bitmap(Properties.Resources.title_line_white);
            }
            line.SizeMode = PictureBoxSizeMode.StretchImage;
            line.Size = new Size(line.Size.Width, 4);
        }

        public void ApplyStandarLogo(PictureBox logo)
        {
            if (isDark)
            {
                logo.Image = new Bitmap(Properties.Resources.prolec_logo_light);
            }
            else
            {
                logo.Image = new Bitmap(Properties.Resources.prolec_logo_light);
            }
        }

        public void ApplyIcons(PictureBox user, PictureBox password)
        {
            user.Image = new Bitmap(Properties.Resources.icon_user_activo);
            password.Image = new Bitmap(Properties.Resources.icon_pass);
        }

        public void ApplyUserImage(PictureBox user)
        {
            if (isDark)
            {
                user.Image = new Bitmap(Properties.Resources.user_dark);
            }
            else
            {
                user.Image = new Bitmap(Properties.Resources.user);
            }
            user.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public static void ApplyDataGridViewDefaultProperties(DataGridView dataGridView)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.MultiSelect = false;
        }

        public static void SetColumnContentAlign(DataGridView dataGridView, DataGridViewContentAlignment contentAlignment, params string[] dataPropertyNames)
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

        public static void SetAllColumnsContentAlign(DataGridView dataGridView, DataGridViewContentAlignment contentAlignment)
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

        #endregion

    }
}