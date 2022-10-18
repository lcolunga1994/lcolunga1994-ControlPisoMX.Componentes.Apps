namespace ProlecGE.ControlPisoMX.Insulations.Forms.Utils
{
    using System.Linq;

    public sealed class CustomTheme
    {
        private bool isDark = false;
        private static CustomTheme? instance = null;
        private static readonly object padlock = new();

        public static CustomTheme Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CustomTheme();
                    }
                    return instance;
                }
            }
        }

        public Color BackColor { get; set; }

        public Color SecondaryBackColor { get; set; }

        public Color ForeColor { get; set; }

        public Color GreenColor { get; set; }

        public Color AccentColor { get; set; }

        public void LightBlueTheme(Form form)
        {
            isDark = false;
            form.BackColor = Color.White;
            LightBlueControls(form);
            Label[]? labels = form.Controls.OfType<Label>().ToArray();

            foreach (Label label in labels)
            {
                LightBlueLabelFormat(label);
            }
        }

        public void LightTheme(Form form)
        {
            isDark = false;
            BackColor = Color.White;
            SecondaryBackColor = Color.FromArgb(243, 243, 243);
            ForeColor = Color.FromArgb(0, 0, 40);
            GreenColor = Color.FromArgb(8, 25, 255, 132);
            AccentColor = Color.FromArgb(136, 84, 255);

            form.BackColor = BackColor;
            form.ForeColor = ForeColor;

            ApplyTheme(form.Controls);
        }

        public void DarkTheme(Form form)
        {
            isDark = true;
            BackColor = Color.Black;
            SecondaryBackColor = Color.Black;
            ForeColor = Color.White;
            GreenColor = Color.FromArgb(8, 25, 255, 132);
            AccentColor = Color.FromArgb(136, 84, 255);

            form.BackColor = BackColor;
            form.ForeColor = ForeColor;

            ApplyTheme(form.Controls);
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

        public void ApplyLabelTheme(Label label)
        {
            label.ForeColor = ForeColor;
        }

        public void ApplyLabelThemeBackground(Label label)
        {
            label.BackColor = SecondaryBackColor;
        }

        public void ApplyLabelThemeAccentColor(Label label)
        {
            label.ForeColor = AccentColor;
        }

        public void ApplyLabelThemeGreenColor(Label label)
        {
            label.ForeColor = GreenColor;
        }

        public void ApplyTextBoxTheme(TextBox textBox)
        {
            textBox.ForeColor = AccentColor;
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

        public void ApplyGridViewTheme(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = BackColor;
            dataGridView.GridColor = isDark ? Color.FromArgb(217, 217, 217) : Color.FromArgb(217, 217, 217);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.BorderStyle = isDark ? BorderStyle.None : BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle(dataGridView.ColumnHeadersDefaultCellStyle)
            {
                Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = GreenColor,
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
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        public void ApplyStandarImages(PictureBox logo, PictureBox line)
        {
            if (isDark)
            {
                logo.Image = new Bitmap(Insulations.Forms.Properties.Resources.prolecge_dark);
                line.Image = new Bitmap(Insulations.Forms.Properties.Resources.title_line_white);
            }
            else
            {
                logo.Image = new Bitmap(Insulations.Forms.Properties.Resources.prolecge_white);
                line.Image = new Bitmap(Insulations.Forms.Properties.Resources.title_line_white);
            }

            line.SizeMode = PictureBoxSizeMode.StretchImage;
            line.Size = new Size(line.Size.Width, 4);
        }

        public void ApplyUserImage(PictureBox user)
        {
            if (isDark)
            {
                user.Image = new Bitmap(Insulations.Forms.Properties.Resources.user_dark);
            }
            else
            {
                user.Image = new Bitmap(Insulations.Forms.Properties.Resources.user);
            }
            user.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private static void LightBlueGridlFormat(DataGridView grid)
        {
            grid.BackgroundColor = Color.FromArgb(255, 255, 255);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(25, 225, 132);
            grid.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            grid.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 40);
            grid.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 255);
            grid.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 0, 40);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 243, 243);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;

        }

        private static void LightBlueLabelFormat(Label label)
        {
            if (label.Name.StartsWith("lblQuantityValue") || label.Name.StartsWith("lblItemValue"))
            {
                label.BackColor = Color.FromArgb(243, 243, 243);
                label.ForeColor = Color.FromArgb(0, 0, 40);
            }
            else
            {
                label.BackColor = Color.FromArgb(255, 255, 255);
                label.ForeColor = Color.FromArgb(0, 0, 40);
            }
        }

        private static void LightBlueSubControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control != null)
                {
                    if (control is Label label)
                    {
                        LightBlueLabelFormat(label);
                    }
                    else if (control is DataGridView dataGrid)
                    {
                        LightBlueGridlFormat(dataGrid);
                    }
                    else if ((control is Panel) || (control is TableLayoutPanel))
                    {
                        LightBlueSubControls(control.Controls);
                    }
                }
            }
        }

        private static void LightBlueControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is Label label)
                {
                    LightBlueLabelFormat(label);
                }
                else if (control is DataGridView dataGrid)
                {
                    LightBlueGridlFormat(dataGrid);
                }
                else if ((control is Panel) || (control is TableLayoutPanel))
                {
                    LightBlueSubControls(control.Controls);
                }
            }
        }
    }
}