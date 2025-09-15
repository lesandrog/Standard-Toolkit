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
/// Demo form showcasing the new Mica themes inspired by Windows 11 Fluent Design.
/// Features subtle translucency effects with better performance than Acrylic.
/// </summary>
public partial class MicaThemeDemo : KryptonForm
{
    private KryptonPanel _mainPanel;
    private KryptonHeaderGroup _themeGroup;
    private KryptonButton _micaLightButton;
    private KryptonButton _micaDarkButton;
    private KryptonButton _acrylicLightButton;
    private KryptonButton _acrylicDarkButton;
    private KryptonButton _materialLightButton;
    private KryptonButton _materialDarkButton;
    private KryptonButton _resetButton;
    private KryptonLabel _descriptionLabel;
    private KryptonLabel _currentThemeLabel;
    private KryptonTextBox _sampleTextBox;
    private KryptonComboBox _sampleComboBox;
    private KryptonCheckBox _sampleCheckBox;
    private KryptonRadioButton _sampleRadioButton1;
    private KryptonRadioButton _sampleRadioButton2;
    private KryptonGroupBox _sampleGroupBox;
    private KryptonDataGridView _sampleDataGrid;

    public MicaThemeDemo()
    {
        InitializeComponent();
        SetupSampleData();
        UpdateCurrentThemeLabel();
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        // Main panel
        _mainPanel = new KryptonPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };

        // Theme selection group
        _themeGroup = new KryptonHeaderGroup
        {
            Dock = DockStyle.Top,
            HeaderStylePrimary = HeaderStyle.Form,
            HeaderVisibleSecondary = false,
            Location = new Point(0, 0),
            Name = "themeGroup",
            Size = new Size(800, 200),
            TabIndex = 0,
            //ValuesPrimary.Heading = "Mica Theme Demo - Windows 11 Fluent Design",
            //ValuesPrimary.Description = "Experience subtle translucency effects with enhanced performance"
        };

        // Theme buttons
        _micaLightButton = new KryptonButton
        {
            Location = new Point(20, 50),
            Name = "micaLightButton",
            Size = new Size(120, 35),
            TabIndex = 1,
            Text = "Mica Light",
            //ToolTipValues.Description = "Windows 11 Mica Light theme with subtle transparency"
        };
        _micaLightButton.Click += MicaLightButton_Click;

        _micaDarkButton = new KryptonButton
        {
            Location = new Point(160, 50),
            Name = "micaDarkButton",
            Size = new Size(120, 35),
            TabIndex = 2,
            Text = "Mica Dark",
            //ToolTipValues.Description = "Windows 11 Mica Dark theme with subtle transparency"
        };
        _micaDarkButton.Click += MicaDarkButton_Click;

        _acrylicLightButton = new KryptonButton
        {
            Location = new Point(300, 50),
            Name = "acrylicLightButton",
            Size = new Size(120, 35),
            TabIndex = 3,
            Text = "Acrylic Light",
            //ToolTipValues.Description = "Windows 10 Acrylic Light theme for comparison"
        };
        _acrylicLightButton.Click += AcrylicLightButton_Click;

        _acrylicDarkButton = new KryptonButton
        {
            Location = new Point(440, 50),
            Name = "acrylicDarkButton",
            Size = new Size(120, 35),
            TabIndex = 4,
            Text = "Acrylic Dark",
            //ToolTipValues.Description = "Windows 10 Acrylic Dark theme for comparison"
        };
        _acrylicDarkButton.Click += AcrylicDarkButton_Click;

        _materialLightButton = new KryptonButton
        {
            Location = new Point(580, 50),
            Name = "materialLightButton",
            Size = new Size(120, 35),
            TabIndex = 5,
            Text = "Material Light",
            //ToolTipValues.Description = "Material Design Light theme for comparison"
        };
        _materialLightButton.Click += MaterialLightButton_Click;

        _materialDarkButton = new KryptonButton
        {
            Location = new Point(20, 100),
            Name = "materialDarkButton",
            Size = new Size(120, 35),
            TabIndex = 6,
            Text = "Material Dark",
            //ToolTipValues.Description = "Material Design Dark theme for comparison"
        };
        _materialDarkButton.Click += MaterialDarkButton_Click;

        _resetButton = new KryptonButton
        {
            Location = new Point(160, 100),
            Name = "resetButton",
            Size = new Size(120, 35),
            TabIndex = 7,
            Text = "Reset",
            //ToolTipValues.Description = "Reset to default theme"
        };
        _resetButton.Click += ResetButton_Click;

        // Description label
        _descriptionLabel = new KryptonLabel
        {
            Location = new Point(300, 100),
            Name = "descriptionLabel",
            Size = new Size(400, 60),
            TabIndex = 8,
            Text = "Mica provides subtle translucency effects with better performance than Acrylic. " +
                   "It adapts to the user's wallpaper and theme for a harmonious appearance.",
            //LabelStyle = LabelStyle.BodyText
        };

        // Current theme label
        _currentThemeLabel = new KryptonLabel
        {
            Location = new Point(20, 150),
            Name = "currentThemeLabel",
            Size = new Size(400, 20),
            TabIndex = 9,
            Text = "Current Theme: ",
            //LabelStyle = LabelStyle.Caption
        };

        // Sample controls
        _sampleTextBox = new KryptonTextBox
        {
            Location = new Point(20, 220),
            Name = "sampleTextBox",
            Size = new Size(200, 25),
            TabIndex = 10,
            Text = "Sample text input"
        };

        _sampleComboBox = new KryptonComboBox
        {
            Location = new Point(240, 220),
            Name = "sampleComboBox",
            Size = new Size(150, 25),
            TabIndex = 11,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        _sampleComboBox.Items.AddRange(new object[] { "Option 1", "Option 2", "Option 3" });
        _sampleComboBox.SelectedIndex = 0;

        _sampleCheckBox = new KryptonCheckBox
        {
            Location = new Point(410, 220),
            Name = "sampleCheckBox",
            Size = new Size(120, 25),
            TabIndex = 12,
            Text = "Sample Checkbox",
            Checked = true
        };

        _sampleRadioButton1 = new KryptonRadioButton
        {
            Location = new Point(20, 260),
            Name = "sampleRadioButton1",
            Size = new Size(120, 25),
            TabIndex = 13,
            Text = "Radio Option 1",
            Checked = true
        };

        _sampleRadioButton2 = new KryptonRadioButton
        {
            Location = new Point(160, 260),
            Name = "sampleRadioButton2",
            Size = new Size(120, 25),
            TabIndex = 14,
            Text = "Radio Option 2"
        };

        // Sample group box
        _sampleGroupBox = new KryptonGroupBox
        {
            Location = new Point(20, 300),
            Name = "sampleGroupBox",
            Size = new Size(300, 150),
            TabIndex = 15,
            Text = "Sample Group Box"
        };

        // Sample data grid
        _sampleDataGrid = new KryptonDataGridView
        {
            Location = new Point(340, 300),
            Name = "sampleDataGrid",
            Size = new Size(400, 150),
            TabIndex = 16,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };

        // Add controls to theme group
        _themeGroup.Panel.Controls.AddRange(new Control[] {
            _micaLightButton, _micaDarkButton, _acrylicLightButton, _acrylicDarkButton,
            _materialLightButton, _materialDarkButton, _resetButton, _descriptionLabel, _currentThemeLabel
        });

        // Add controls to main panel
        _mainPanel.Controls.AddRange(new Control[] {
            _themeGroup, _sampleTextBox, _sampleComboBox, _sampleCheckBox,
            _sampleRadioButton1, _sampleRadioButton2, _sampleGroupBox, _sampleDataGrid
        });

        // Form properties
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 500);
        Controls.Add(_mainPanel);
        Name = "MicaThemeDemo";
        Text = "Mica Theme Demo - Windows 11 Fluent Design";
        WindowState = FormWindowState.Normal;
        StartPosition = FormStartPosition.CenterScreen;

        ResumeLayout(false);
        PerformLayout();
    }

    private void SetupSampleData()
    {
        // Add sample data to the data grid
        _sampleDataGrid.Columns.Add("Name", "Name");
        _sampleDataGrid.Columns.Add("Value", "Value");
        _sampleDataGrid.Columns.Add("Status", "Status");

        _sampleDataGrid.Rows.Add("Mica Light", "Subtle", "Active");
        _sampleDataGrid.Rows.Add("Mica Dark", "Subtle", "Active");
        _sampleDataGrid.Rows.Add("Acrylic Light", "Medium", "Legacy");
        _sampleDataGrid.Rows.Add("Acrylic Dark", "Medium", "Legacy");
        _sampleDataGrid.Rows.Add("Material Light", "Solid", "Classic");
        _sampleDataGrid.Rows.Add("Material Dark", "Solid", "Classic");
    }

    private void UpdateCurrentThemeLabel()
    {
        //var currentMode = KryptonManager.GlobalPaletteMode;
        //_currentThemeLabel.Text = $"Current Theme: {currentMode}";
    }

    private void MicaLightButton_Click(object sender, EventArgs e)
    {
        //KryptonManager.GlobalPaletteMode = PaletteMode.MicaLight;
        UpdateCurrentThemeLabel();
    }

    private void MicaDarkButton_Click(object sender, EventArgs e)
    {
        //KryptonManager.GlobalPaletteMode = PaletteMode.MicaDark;
        UpdateCurrentThemeLabel();
    }

    private void AcrylicLightButton_Click(object sender, EventArgs e)
    {
        //KryptonManager.GlobalPaletteMode = PaletteMode.AcrylicLight;
        UpdateCurrentThemeLabel();
    }

    private void AcrylicDarkButton_Click(object sender, EventArgs e)
    {
        //KryptonManager.GlobalPaletteMode = PaletteMode.AcrylicDark;
        UpdateCurrentThemeLabel();
    }

    private void MaterialLightButton_Click(object sender, EventArgs e)
    {
        //KryptonManager.GlobalPaletteMode = PaletteMode.MaterialLight;
        UpdateCurrentThemeLabel();
    }

    private void MaterialDarkButton_Click(object sender, EventArgs e)
    {
        //KryptonManager.GlobalPaletteMode = PaletteMode.MaterialDark;
        UpdateCurrentThemeLabel();
    }

    private void ResetButton_Click(object sender, EventArgs e)
    {
        //KryptonManager.GlobalPaletteMode = PaletteMode.ProfessionalOffice2003;
        UpdateCurrentThemeLabel();
    }
}
