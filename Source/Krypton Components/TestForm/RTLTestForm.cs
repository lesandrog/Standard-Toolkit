#region BSD License
/*
 * 
 *  New BSD 3-Clause License (https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/LICENSE)
 *  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV), et al. 2024 - 2025. All rights reserved. 
 *  
 */
#endregion

namespace TestForm;

public partial class RTLTestForm : KryptonForm
{
    public RTLTestForm()
    {
        InitializeComponent();
        SetupTestControls();
        UpdateStateDisplay();
    }

    private void SetupTestControls()
    {
        // Instructions label
        lblInstructions = new KryptonLabel
        {
            Text = "Test RTL Matrix Compliance:\n" +
                   "1. Normal LTR (RTL=No, RTLLayout=No)\n" +
                   "2. LTR with RTLLayout (RTL=No, RTLLayout=Yes) - should be same as #1\n" +
                   "3. RTL Aligned (RTL=Yes, RTLLayout=No) - text RTL, buttons stay right\n" +
                   "4. Full RTL Layout (RTL=Yes, RTLLayout=Yes) - text RTL, buttons mirrored left",
            Location = new Point(20, 20),
            Size = new Size(750, 100),
            StateCommon = { ShortText = { MultiLine = InheritBool.True } }
        };

        // Current state display
        lblCurrentState = new KryptonLabel
        {
            Text = "Current State: ",
            Location = new Point(20, 140),
            Size = new Size(750, 30),
            StateCommon = { ShortText = { Font = new Font("Segoe UI", 12, FontStyle.Bold) } }
        };

        // Test scenario buttons
        btnScenario1 = new KryptonButton
        {
            Text = "1. Normal LTR\n(RTL=No, RTLLayout=No)",
            Location = new Point(20, 180),
            Size = new Size(180, 60),
            StateCommon = { Content = { ShortText = { MultiLine = InheritBool.True } } }
        };
        btnScenario1.Click += (s, e) => SetRTLMode(RightToLeft.No, false);

        btnScenario2 = new KryptonButton
        {
            Text = "2. LTR + RTLLayout\n(RTL=No, RTLLayout=Yes)",
            Location = new Point(210, 180),
            Size = new Size(180, 60),
            StateCommon = { Content = { ShortText = { MultiLine = InheritBool.True } } }
        };
        btnScenario2.Click += (s, e) => SetRTLMode(RightToLeft.No, true);

        btnScenario3 = new KryptonButton
        {
            Text = "3. RTL Aligned\n(RTL=Yes, RTLLayout=No)",
            Location = new Point(400, 180),
            Size = new Size(180, 60),
            StateCommon = { Content = { ShortText = { MultiLine = InheritBool.True } } }
        };
        btnScenario3.Click += (s, e) => SetRTLMode(RightToLeft.Yes, false);

        btnScenario4 = new KryptonButton
        {
            Text = "4. Full RTL Layout\n(RTL=Yes, RTLLayout=Yes)",
            Location = new Point(590, 180),
            Size = new Size(180, 60),
            StateCommon = { Content = { ShortText = { MultiLine = InheritBool.True } } }
        };
        btnScenario4.Click += (s, e) => SetRTLMode(RightToLeft.Yes, true);

        // Debug output
        var lblDebug = new KryptonLabel
        {
            Text = "Debug Output (check for RTL transformations):",
            Location = new Point(20, 260),
            Size = new Size(300, 25)
        };

        txtDebugOutput = new KryptonTextBox
        {
            Location = new Point(20, 290),
            Size = new Size(750, 280),
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            ReadOnly = true,
            Text = "Debug output will appear here when RTL transformations occur...\n"
        };

        // Add all controls
        Controls.AddRange(new Control[] 
        { 
            lblInstructions, 
            lblCurrentState, 
            btnScenario1, 
            btnScenario2, 
            btnScenario3, 
            btnScenario4,
            lblDebug,
            txtDebugOutput
        });
    }

    private void SetRTLMode(RightToLeft rtl, bool rtlLayout)
    {
        // Clear debug output
        txtDebugOutput.Text = $"Setting RTL={rtl}, RTLLayout={rtlLayout}\n";
        
        // Capture debug output
        var listener = new DebugListener(txtDebugOutput);
        System.Diagnostics.Trace.Listeners.Add(listener);
        
        try
        {
            // Apply RTL settings
            RightToLeft = rtl;
            RightToLeftLayout = rtlLayout;
            
            // Update state display
            UpdateStateDisplay();
            
            // Force a layout update
            PerformLayout();
            Invalidate();
        }
        finally
        {
            System.Diagnostics.Trace.Listeners.Remove(listener);
        }
    }

    private void UpdateStateDisplay()
    {
        string expected = GetExpectedBehavior();
        lblCurrentState.Text = $"Current: RTL={RightToLeft}, RTLLayout={RightToLeftLayout}\n" +
                               $"Expected: {expected}";
    }

    private string GetExpectedBehavior()
    {
        return (RightToLeft, RightToLeftLayout) switch
        {
            (RightToLeft.No, false) => "Normal LTR layout",
            (RightToLeft.No, true) => "Normal LTR layout (RTLLayout ignored)",
            (RightToLeft.Yes, false) => "Controls aligned RTL, layout unchanged (text RTL, buttons stay right)",
            (RightToLeft.Yes, true) => "Full RTL layout (text RTL, buttons mirrored left)",
            _ => "Unknown state"
        };
    }

    // Custom debug listener to capture debug output
    private class DebugListener : System.Diagnostics.TraceListener
    {
        private readonly KryptonTextBox _textBox;

        public DebugListener(KryptonTextBox textBox)
        {
            _textBox = textBox;
        }

        public override void Write(string? message)
        {
            if (message != null)
            {
                if (_textBox.InvokeRequired)
                {
                    _textBox.Invoke(new Action(() => _textBox.AppendText(message)));
                }
                else
                {
                    _textBox.AppendText(message);
                }
            }
        }

        public override void WriteLine(string? message)
        {
            Write(message + Environment.NewLine);
        }
    }
}