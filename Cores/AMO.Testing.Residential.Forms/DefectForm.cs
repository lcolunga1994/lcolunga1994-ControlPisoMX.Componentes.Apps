namespace ProlecGE.ControlPisoMX.AMO.Testing.Residential.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    using MediatR;

    using ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Models;
    using ProlecGE.ControlPisoMX.AMO.Testing.Residential.Queries;

    internal partial class DefectForm : Form
    {
        private readonly IProgress<(
            MessageBoxIcon MessageBoxIcon,
            string ErrorMessage,
            string MessageTitle,
            Exception? Exception)> messageBoxProgress;

        public static Color ThemePrimaryColor = Color.FromArgb(0, 0, 40);

        private readonly IMediator mediator;

        #region Constructor

        public DefectForm(ItemModel core, IMediator mediator)
        {
            InitializeComponent();

            messageBoxProgress = new Progress<(
                MessageBoxIcon MessageBoxIcon,
                string ErrorMessage,
                string MessageTitle,
                Exception? Exception)>(ShowMessage);

            this.mediator = mediator;

            Text = $"Registrar defecto (Orden: '{core.ItemId}-{core.Batch}-{core.Serie}' Secuencia: {core.Sequence})";
        }

        #endregion

        #region Properties

        public string Defect
        {
            get => cmbDefects.Text;
            set => cmbDefects.Text = value;
        }

        #endregion

        #region Events

        private void OnFormLoad(object sender, System.EventArgs e) => GetAllDefectConcept();

        private void CmbDefects_TextChanged(object sender, EventArgs e)
        {
            string controlText = ((Control)sender).Text ?? "";
            int maxLength = 30;
            int textLength = controlText.Trim().Length;
            UpdateLabelTextSize(lblCodeFieldSize, maxLength, textLength);
        }

        private void CmbDefects_Validating(object sender, System.ComponentModel.CancelEventArgs e)
            => e.Cancel = !new Regex(@"^[A-Z0-9]$").IsMatch(((Control)sender).Text);

        private void CmbDefects_Validated(object sender, EventArgs e) => epForm.SetError((Control)sender, "");

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(
                "¿Desea registrar el defecto?",
                "Registrar defecto.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.No)
            {
                if (!string.IsNullOrWhiteSpace(cmbDefects.Text))
                {
                    if (cmbDefects.Text.Length <= 30)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        ShowWarningMessage(
                            "El defecto no debe de ser mayor de 30 caracteres.",
                            "Registrar Defecto.");
                    }
                }
                else
                {
                    ShowErrorMessage(
                        "Debe introducir el concepto del defecto.",
                        "Registrar Defecto.");
                }
            }
        }

        #endregion

        #region Commands

        private async void GetAllDefectConcept()
        {
            try
            {
                IEnumerable<CoreTestDefectConceptModel> defectConcepts = await mediator
                    .Send(new DefectConceptQuery(), CancellationToken.None)
                    .ConfigureAwait(false);

                if (defectConcepts != null)
                {
                    if (cmbDefects.InvokeRequired)
                    {
                        cmbDefects.Invoke(new Action(() =>
                              cmbDefects.Items.Clear()
                        ));
                        cmbDefects.Invoke(new Action(() =>
                              cmbDefects.Items.AddRange(defectConcepts.Select(e => e.Concept).ToArray())
                        ));
                    }
                    else
                    {
                        cmbDefects.BeginUpdate();
                        cmbDefects.Items.Clear();
                        cmbDefects.Items.AddRange(defectConcepts.Select(e => e.Concept).ToArray());
                        cmbDefects.EndUpdate();
                        cmbDefects.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(
                    "Ocurrió un error al obtener la lista de conceptos de defectos.",
                    "Registrar Defecto.",
                    ex);
            }
        }

        #endregion

        #region Methods

        private void ShowErrorMessage(
            string errorMessage,
            string messageTitle,
            Exception? ex = null)
        {
            messageBoxProgress.Report(
                (MessageBoxIcon.Error,
                errorMessage,
                messageTitle,
                ex));
        }

        private void ShowWarningMessage(
            string errorMessage,
            string messageTitle)
        {
            messageBoxProgress.Report(
                (MessageBoxIcon.Warning,
                errorMessage,
                messageTitle,
                null));
        }

        private void ShowMessage((
            MessageBoxIcon MessageBoxIcon,
            string ErrorMessage,
            string MessageTitle,
            Exception? Exception) messageParameters)
        {
            if (messageParameters.Exception != null)
            {
                System.Diagnostics.Debug.WriteLine(messageParameters.Exception);
            }

            string userMessage = messageParameters.ErrorMessage;

            if (messageParameters.Exception != null)
            {
                if (messageParameters.Exception is UserException userException)
                {
                    userMessage = userException.Message;
                    //if (userException.ErrorCode != null
                    //    && userException.ErrorCode.StartsWith("UserError"))
                    //{
                    //    lblUserMessage.Text = userMessage;
                    //    lblUserMessage.Visible = true;
                    //}
                }
                else
                {
                    System.Text.StringBuilder stringBuilder = new();
                    stringBuilder.AppendLine(userMessage);
                    stringBuilder.AppendLine("Contactar al administrador del sistema.");
                    userMessage = stringBuilder.ToString();
                }
            }

            if (messageParameters.MessageBoxIcon == MessageBoxIcon.Warning)
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (messageParameters.MessageBoxIcon == MessageBoxIcon.Error)
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    this,
                    userMessage,
                    messageParameters.MessageTitle,
                    MessageBoxButtons.OK);
            }
        }

        private static void UpdateLabelTextSize(Label labelControl, int maxLength, int textLength)
        {
            labelControl.Text = $"{textLength}/{maxLength}";
            labelControl.ForeColor = textLength > maxLength ? Color.Red : ThemePrimaryColor;
        }

        #endregion
    }
}