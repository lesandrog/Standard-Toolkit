#region BSD License
/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), tobitege et al. 2025 - 2025. All rights reserved.
 *
 */
#endregion

namespace Krypton.Toolkit;

/// <summary>
/// Test form to demonstrate the new Acrylic Light and Dark themes.
/// Shows various Krypton controls with semi-transparent acrylic effects.
/// </summary>
public partial class AcrylicThemeDemo : KryptonForm
{
    #region Instance Fields
    private KryptonButton _btnAcrylicLight;
    private KryptonButton _btnAcrylicDark;
    private KryptonButton _btnMicrosoft365;
    private KryptonPanel _mainPanel;
    private KryptonGroupBox _groupBox;
    private KryptonTextBox _textBox;
    private KryptonComboBox _comboBox;
    private KryptonCheckBox _checkBox;
    private KryptonRadioButton _radioButton;
    private KryptonLabel _label;
    private KryptonLabel _descriptionLabel;
    #endregion

    #region Identity

    /// <summary>
    /// Initialize a new instance of the AcrylicThemeDemo class.
    /// </summary>
    public AcrylicThemeDemo()
    {
        InitializeComponent();
        
        // Enable transparency support for Acrylic themes
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.DoubleBuffer, true);
        SetStyle(ControlStyles.ResizeRedraw, true);
        
        SetupControls();
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Sets up the demo controls.
    /// </summary>
    private void SetupControls()
    {
        // Set initial theme
        kryptonManager.GlobalPaletteMode = PaletteMode.AcrylicLight;
        
        // Configure form
        Text = "Krypton Acrylic Theme Demo";
        Size = new Size(800, 600);
        StartPosition = FormStartPosition.CenterScreen;
        
        // Add description
        _descriptionLabel.Values.Text = "This demo showcases the new Acrylic Light and Dark themes inspired by Windows 10 Fluent Design System. " +
                                       "Notice the semi-transparent surfaces and subtle transparency effects.";
        _descriptionLabel.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;
        
        // Configure buttons
        _btnAcrylicLight.Text = "Acrylic Light";
        _btnAcrylicDark.Text = "Acrylic Dark";
        _btnMicrosoft365.Text = "Microsoft 365 (Comparison)";
        
        // Configure other controls
        _groupBox.Text = "Acrylic Controls Demo";
        _textBox.Text = "Semi-transparent text input";
        _comboBox.Items.AddRange(new[] { "Acrylic Option 1", "Acrylic Option 2", "Acrylic Option 3" });
        _comboBox.SelectedIndex = 0;
        _checkBox.Text = "Acrylic checkbox";
        _checkBox.Checked = true;
        _radioButton.Text = "Acrylic radio button";
        _radioButton.Checked = true;
        _label.Text = "Acrylic Label with semi-transparent background";
    }

    /// <summary>
    /// Handles the Acrylic Light button click.
    /// </summary>
    private void BtnAcrylicLight_Click(object sender, EventArgs e)
    {
        kryptonManager.GlobalPaletteMode = PaletteMode.AcrylicLight;
        UpdateButtonStates();
    }

    /// <summary>
    /// Handles the Acrylic Dark button click.
    /// </summary>
    private void BtnAcrylicDark_Click(object sender, EventArgs e)
    {
        kryptonManager.GlobalPaletteMode = PaletteMode.AcrylicDark;
        UpdateButtonStates();
    }

    /// <summary>
    /// Handles the Microsoft 365 button click.
    /// </summary>
    private void BtnMicrosoft365_Click(object sender, EventArgs e)
    {
        kryptonManager.GlobalPaletteMode = PaletteMode.Microsoft365Blue;
        UpdateButtonStates();
    }

    /// <summary>
    /// Updates the button states to show which theme is currently active.
    /// </summary>
    private void UpdateButtonStates()
    {
        //_btnAcrylicLight.Checked = kryptonManager.GlobalPaletteMode == PaletteMode.AcrylicLight;
        //_btnAcrylicDark.Checked = kryptonManager.GlobalPaletteMode == PaletteMode.AcrylicDark;
        //_btnMicrosoft365.Checked = kryptonManager.GlobalPaletteMode == PaletteMode.Microsoft365Blue;
    }

    #endregion

    #region Designer Generated Code

    private void InitializeComponent()
    {
        this.kryptonManager = new KryptonManager();
        this._mainPanel = new KryptonPanel();
        this._btnAcrylicLight = new KryptonButton();
        this._btnAcrylicDark = new KryptonButton();
        this._btnMicrosoft365 = new KryptonButton();
        this._groupBox = new KryptonGroupBox();
        this._textBox = new KryptonTextBox();
        this._comboBox = new KryptonComboBox();
        this._checkBox = new KryptonCheckBox();
        this._radioButton = new KryptonRadioButton();
        this._label = new KryptonLabel();
        this._descriptionLabel = new KryptonLabel();
        //((System.ComponentModel.ISupportInitialize)(this.kryptonManager)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mainPanel)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._groupBox)).BeginInit();
        this._groupBox.SuspendLayout();
        this.SuspendLayout();
        // 
        // kryptonManager
        // 
        this.kryptonManager.GlobalPaletteMode = PaletteMode.AcrylicLight;
        // 
        // _mainPanel
        // 
        this._mainPanel.Dock = DockStyle.Fill;
        this._mainPanel.Location = new Point(0, 0);
        this._mainPanel.Name = "_mainPanel";
        this._mainPanel.Size = new Size(800, 600);
        this._mainPanel.TabIndex = 0;
        // 
        // _btnAcrylicLight
        // 
        this._btnAcrylicLight.Location = new Point(20, 20);
        this._btnAcrylicLight.Name = "_btnAcrylicLight";
        this._btnAcrylicLight.Size = new Size(150, 40);
        this._btnAcrylicLight.TabIndex = 0;
        this._btnAcrylicLight.Values.Text = "Acrylic Light";
        this._btnAcrylicLight.Click += new EventHandler(this.BtnAcrylicLight_Click);
        // 
        // _btnAcrylicDark
        // 
        this._btnAcrylicDark.Location = new Point(190, 20);
        this._btnAcrylicDark.Name = "_btnAcrylicDark";
        this._btnAcrylicDark.Size = new Size(150, 40);
        this._btnAcrylicDark.TabIndex = 1;
        this._btnAcrylicDark.Values.Text = "Acrylic Dark";
        this._btnAcrylicDark.Click += new EventHandler(this.BtnAcrylicDark_Click);
        // 
        // _btnMicrosoft365
        // 
        this._btnMicrosoft365.Location = new Point(360, 20);
        this._btnMicrosoft365.Name = "_btnMicrosoft365";
        this._btnMicrosoft365.Size = new Size(200, 40);
        this._btnMicrosoft365.TabIndex = 2;
        this._btnMicrosoft365.Values.Text = "Microsoft 365 (Comparison)";
        this._btnMicrosoft365.Click += new EventHandler(this.BtnMicrosoft365_Click);
        // 
        // _groupBox
        // 
        this._groupBox.Controls.Add(this._label);
        this._groupBox.Controls.Add(this._radioButton);
        this._groupBox.Controls.Add(this._checkBox);
        this._groupBox.Controls.Add(this._comboBox);
        this._groupBox.Controls.Add(this._textBox);
        this._groupBox.Location = new Point(20, 120);
        this._groupBox.Name = "_groupBox";
        this._groupBox.Size = new Size(750, 200);
        this._groupBox.TabIndex = 3;
        this._groupBox.Values.Heading = "Acrylic Controls Demo";
        // 
        // _textBox
        // 
        this._textBox.Location = new Point(20, 30);
        this._textBox.Name = "_textBox";
        this._textBox.Size = new Size(200, 25);
        this._textBox.TabIndex = 0;
        // 
        // _comboBox
        // 
        this._comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this._comboBox.Location = new Point(240, 30);
        this._comboBox.Name = "_comboBox";
        this._comboBox.Size = new Size(200, 25);
        this._comboBox.TabIndex = 1;
        // 
        // _checkBox
        // 
        this._checkBox.Location = new Point(20, 70);
        this._checkBox.Name = "_checkBox";
        this._checkBox.Size = new Size(150, 25);
        this._checkBox.TabIndex = 2;
        this._checkBox.Values.Text = "Acrylic checkbox";
        // 
        // _radioButton
        // 
        this._radioButton.Location = new Point(200, 70);
        this._radioButton.Name = "_radioButton";
        this._radioButton.Size = new Size(150, 25);
        this._radioButton.TabIndex = 3;
        this._radioButton.Values.Text = "Acrylic radio button";
        // 
        // _label
        // 
        this._label.Location = new Point(20, 110);
        this._label.Name = "_label";
        this._label.Size = new Size(400, 25);
        this._label.TabIndex = 4;
        this._label.Values.Text = "Acrylic Label with semi-transparent background";
        // 
        // _descriptionLabel
        // 
        this._descriptionLabel.Location = new Point(20, 350);
        this._descriptionLabel.Name = "_descriptionLabel";
        this._descriptionLabel.Size = new Size(750, 60);
        this._descriptionLabel.TabIndex = 4;
        this._descriptionLabel.Values.Text = "Description will be set in code";
        // 
        // AcrylicThemeDemo
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 600);
        this.Controls.Add(this._descriptionLabel);
        this.Controls.Add(this._groupBox);
        this.Controls.Add(this._btnMicrosoft365);
        this.Controls.Add(this._btnAcrylicDark);
        this.Controls.Add(this._btnAcrylicLight);
        this.Controls.Add(this._mainPanel);
        this.Name = "AcrylicThemeDemo";
        this.Text = "Krypton Acrylic Theme Demo";
        //((System.ComponentModel.ISupportInitialize)(this.kryptonManager)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mainPanel)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._groupBox)).EndInit();
        this._groupBox.ResumeLayout(false);
        this._groupBox.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    #region Designer Fields
    private KryptonManager kryptonManager;
    #endregion
}
