namespace ProlecGE.ControlPisoMX.Insulations.Forms
{
    using System;

    using Microsoft.Extensions.Options;

    public class ThemedForm : Form
    {
        #region Fields

        private readonly IDisposable? themeMonitor;
        private readonly IProgress<bool>? themeProgress;
        private readonly ThemeConfiguration? initialTheme;
        #endregion

        #region Constructor

        public ThemedForm() { }

        public ThemedForm(ThemeConfiguration themeConfiguration) 
        { 
            initialTheme = themeConfiguration;
        }

        public ThemedForm(IOptionsMonitor<ThemeConfiguration> monitor)
        {
            themeProgress = new Progress<bool>(OnThemeChanged);
            initialTheme = monitor.CurrentValue;
            themeMonitor = monitor.OnChange(OnThemeChanged);
        }

        #endregion

        #region Destructor

        ~ThemedForm()
        {
            themeMonitor?.Dispose();
        }

        #endregion

        #region Theme

        private void OnThemeChanged(ThemeConfiguration arg1, string arg2)
            => themeProgress?.Report(arg1.UseDarkTheme);

        protected virtual void OnThemeChanged(bool useDarkTheme)
        {
            if (useDarkTheme)
            {
                Utils.CustomTheme.Instance.DarkTheme(this);
            }
            else
            {
                Utils.CustomTheme.Instance.LightTheme(this);
            }
        }

        #endregion

        #region Functionality

        protected override void OnLoad(EventArgs e)
        {
            if (initialTheme != null)
            {
                OnThemeChanged(initialTheme.UseDarkTheme);
            }

            base.OnLoad(e);
        }

        #endregion
    }

    public class ThemeConfiguration
    {
        public bool UseDarkTheme { get; set; }
    }
}