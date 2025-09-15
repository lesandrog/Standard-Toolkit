#region BSD License
/*
 *
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner (aka Wagnerp), Simon Coghlan (aka Smurf-IV), tobitege et al. 2025 - 2025. All rights reserved.
 *
 */
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Examples;

/// <summary>
/// Example demonstrating how to use the new Acrylic Light and Dark themes.
/// </summary>
public static class AcrylicThemeExample
{
    /// <summary>
    /// Creates a simple form with acrylic theme applied.
    /// </summary>
    /// <returns>A form with acrylic theme.</returns>
    public static Form CreateAcrylicDemoForm()
    {
        var form = new KryptonForm
        {
            Text = "Acrylic Theme Demo",
            Size = new Size(600, 400),
            StartPosition = FormStartPosition.CenterScreen
        };

        // Apply Acrylic Light theme
        //KryptonManager.GlobalPaletteMode = PaletteMode.AcrylicLight;

        // Create a panel with some controls
        var panel = new KryptonPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };

        // Add theme selection buttons
        var btnLight = new KryptonButton
        {
            Text = "Acrylic Light",
            Location = new Point(20, 20),
            Size = new Size(120, 35)
        };
        //btnLight.Click += (s, e) => KryptonManager.GlobalPaletteMode = PaletteMode.AcrylicLight;

        var btnDark = new KryptonButton
        {
            Text = "Acrylic Dark",
            Location = new Point(160, 20),
            Size = new Size(120, 35)
        };
        //btnDark.Click += (s, e) => KryptonManager.GlobalPaletteMode = PaletteMode.AcrylicDark;

        var btnCompare = new KryptonButton
        {
            Text = "Microsoft 365",
            Location = new Point(300, 20),
            Size = new Size(120, 35)
        };
        //btnCompare.Click += (s, e) => KryptonManager.GlobalPaletteMode = PaletteMode.Microsoft365Blue;

        // Add some demo controls
        var groupBox = new KryptonGroupBox
        {
            Text = "Acrylic Controls",
            Location = new Point(20, 70),
            Size = new Size(400, 200)
        };

        var textBox = new KryptonTextBox
        {
            Location = new Point(20, 30),
            Size = new Size(200, 25),
            Text = "Semi-transparent input"
        };

        var comboBox = new KryptonComboBox
        {
            Location = new Point(20, 70),
            Size = new Size(200, 25),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        comboBox.Items.AddRange(new[] { "Option 1", "Option 2", "Option 3" });
        comboBox.SelectedIndex = 0;

        var checkBox = new KryptonCheckBox
        {
            Text = "Acrylic checkbox",
            Location = new Point(20, 110),
            Size = new Size(150, 25),
            Checked = true
        };

        var radioButton = new KryptonRadioButton
        {
            Text = "Acrylic radio button",
            Location = new Point(20, 140),
            Size = new Size(150, 25),
            Checked = true
        };

        // Add description label
        var descriptionLabel = new KryptonLabel
        {
            Text = "The Acrylic themes provide semi-transparent surfaces inspired by Windows 10 Fluent Design System. " +
                   "Notice how the controls have subtle transparency effects that create depth and visual interest.",
            Location = new Point(20, 280),
            Size = new Size(560, 60),
            //t = ContentAlignment.MiddleCenter
        };

        // Add controls to group box
        groupBox.Controls.Add(textBox);
        groupBox.Controls.Add(comboBox);
        groupBox.Controls.Add(checkBox);
        groupBox.Controls.Add(radioButton);

        // Add controls to panel
        panel.Controls.Add(btnLight);
        panel.Controls.Add(btnDark);
        panel.Controls.Add(btnCompare);
        panel.Controls.Add(groupBox);
        panel.Controls.Add(descriptionLabel);

        // Add panel to form
        form.Controls.Add(panel);

        return form;
    }

    /// <summary>
    /// Shows how to programmatically switch between acrylic themes.
    /// </summary>
    public static void DemonstrateThemeSwitching()
    {
        // Method 1: Using PaletteMode enum
        //KryptonManager.GlobalPaletteMode = PaletteMode.AcrylicLight;
        
        // Method 2: Using ThemeManager
        //ThemeManager.ApplyTheme(PaletteMode.AcrylicDark, KryptonManager.Instance);
        
        // Method 3: Using custom palette directly
        var customAcrylicPalette = new PaletteAcrylicLight();
        //ThemeManager.ApplyTheme(customAcrylicPalette, KryptonManager.Instance);
    }

    /// <summary>
    /// Shows how to create a custom acrylic palette with modified colors.
    /// </summary>
    /// <returns>A custom acrylic palette.</returns>
    public static KryptonCustomPaletteBase CreateCustomAcrylicPalette()
    {
        var customPalette = new KryptonCustomPaletteBase();
        
        // Set base palette to acrylic light
        customPalette.BasePalette = KryptonManager.PaletteAcrylicLight;
        
        // Override specific colors for custom acrylic effect
        customPalette.Common.StateCommon.Back.Color1 = Color.FromArgb(200, 255, 255, 255); // More opaque
        customPalette.Common.StateCommon.Back.Color2 = Color.FromArgb(180, 240, 240, 240); // Slightly less opaque
        
        // Override border colors
        customPalette.Common.StateCommon.Border.Color1 = Color.FromArgb(150, 100, 100, 100); // Custom border
        
        return customPalette;
    }
}
