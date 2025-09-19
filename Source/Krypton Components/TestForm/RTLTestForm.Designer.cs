#region BSD License
/*
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2024 - 2025. All rights reserved. 
 *  
 */
#endregion

namespace TestForm;

partial class RTLTestForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private KryptonButton btnScenario1;
    private KryptonButton btnScenario2;
    private KryptonButton btnScenario3;
    private KryptonButton btnScenario4;
    private KryptonLabel lblCurrentState;
    private KryptonLabel lblInstructions;
    private KryptonTextBox txtDebugOutput;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        SuspendLayout();
        
        // 
        // RTLTestForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 600);
        Icon = SystemIcons.Application;
        Name = "RTLTestForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "RTL Test Form - Verify Matrix Compliance";
        
        ResumeLayout(false);
    }

    #endregion
}