namespace ProlecGE.ControlPisoMX
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class UtilsExtensions
    {
        public static void ValidItemIdString(this string? itemId)
        {
            if (string.IsNullOrWhiteSpace(itemId))
            {
                throw new UserException("El artículo no puede ser vacío o espacios en blanco.", 0);
            }

            if (!new Regex(@"([A-Z0-9Ñ-]{1,47})").IsMatch(itemId))
            {
                throw new UserException("El artículo debe contener solo números y letras y tener máximo 47 caracteres.", 0);
            };
        }

        public static void ValidBatchString(this string? batch)
        {
            if (string.IsNullOrWhiteSpace(batch))
            {
                throw new UserException("El lote no puede ser vacío o espacios en blanco.");
            }

            if (!new Regex(@"([A-Z0-9Ñ-]{1,3})").IsMatch(batch))
            {
                throw new UserException("El lote debe contener solo números y letras y tener máximo 3 caracteres.");
            };
        }

        public static void InitializeItemTextboxBehavior(this TextBox textBox)
        {
            if (textBox != null)
            {
                textBox.CharacterCasing = CharacterCasing.Upper;
                textBox.MaxLength = 47;
                textBox.Enter -= SelectTextboxText;
                textBox.Enter += SelectTextboxText;
                textBox.Click -= SelectTextboxText;
                textBox.Click += SelectTextboxText;
            }
        }

        public static void InitializeBatchTextboxBehavior(this TextBox textBox)
        {
            if (textBox != null)
            {
                textBox.CharacterCasing = CharacterCasing.Normal;
                textBox.MaxLength = 3;
                textBox.Enter -= SelectTextboxText;
                textBox.Enter += SelectTextboxText;
                textBox.Click -= SelectTextboxText;
                textBox.Click += SelectTextboxText;
                textBox.Leave -= OnTextBoxLeave;
                textBox.Leave += OnTextBoxLeave;
            }

            static void OnTextBoxLeave(object? sender, EventArgs e)
            {
                if (sender is TextBox textBox)
                {
                    if (!string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Text = textBox.Text.PadLeft(2, '0');
                    }
                }
            }
        }

        public static void InitializeSerieTextboxBehavior(this TextBox textBox)
        {
            if (textBox != null)
            {
                textBox.Enter -= SelectTextboxText;
                textBox.Enter += SelectTextboxText;
                textBox.Click -= SelectTextboxText;
                textBox.Click += SelectTextboxText;
                textBox.KeyPress -= OnTextKeyPress;
                textBox.KeyPress += OnTextKeyPress;
            }

            static void OnTextKeyPress(object? sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        public static void ShowErrorMessage(this Form form, string errorMessage, string messageTitle, Exception? exception)
        {
            string userMessage = errorMessage;
            bool showWarningIcon = false;

            if (exception != null)
            {
                if (exception is UserException userException)
                {
                    showWarningIcon = userException.SystemErrorCode == 0;

                    string? customMessage = userException.SystemErrorCode switch
                    {
                        401 => null,
                        _ => null,
                    };

                    StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userException.Message);

                    if (!string.IsNullOrEmpty(customMessage))
                    {
                        stringBuilder.Append(customMessage);

                        if (userException.SystemErrorCode is 500)
                        {
                            stringBuilder.Append($" ({userException.ErrorCode})");
                        }
                    }

                    userMessage = stringBuilder.ToString();
                }
                else
                {
                    StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userMessage);
                    stringBuilder.AppendLine("Contactar al administrador del sistema.");
                    userMessage = stringBuilder.ToString();
                }
            }

            if (!form.IsDisposed)
            {
                MessageBox.Show(form, userMessage, messageTitle, MessageBoxButtons.OK, showWarningIcon ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
        }

        private static void SelectTextboxText(object? sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }
    }
}