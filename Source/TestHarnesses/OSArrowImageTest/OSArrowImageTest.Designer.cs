namespace OSArrowImageTest;

partial class OSArrowImageTest
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
        this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
        this.btnUp = new Krypton.Toolkit.KryptonButton();
        this.btnDown = new Krypton.Toolkit.KryptonButton();
        this.btnLeft = new Krypton.Toolkit.KryptonButton();
        this.btnRight = new Krypton.Toolkit.KryptonButton();
        this.cmdLinkTest = new Krypton.Toolkit.KryptonCommandLinkButton();
        this.lblOSInfo = new Krypton.Toolkit.KryptonLabel();
        this.lblAvailability = new Krypton.Toolkit.KryptonLabel();
        ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
        this.kryptonPanel1.SuspendLayout();
        this.SuspendLayout();
        
        // kryptonPanel1
        this.kryptonPanel1.Controls.Add(this.lblAvailability);
        this.kryptonPanel1.Controls.Add(this.lblOSInfo);
        this.kryptonPanel1.Controls.Add(this.cmdLinkTest);
        this.kryptonPanel1.Controls.Add(this.btnUp);
        this.kryptonPanel1.Controls.Add(this.btnDown);
        this.kryptonPanel1.Controls.Add(this.btnLeft);
        this.kryptonPanel1.Controls.Add(this.btnRight);
        this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
        this.kryptonPanel1.Name = "kryptonPanel1";
        this.kryptonPanel1.Size = new System.Drawing.Size(400, 300);
        this.kryptonPanel1.TabIndex = 0;
        
        // btnUp
        this.btnUp.Location = new System.Drawing.Point(150, 50);
        this.btnUp.Name = "btnUp";
        this.btnUp.Size = new System.Drawing.Size(100, 30);
        this.btnUp.TabIndex = 0;
        this.btnUp.Values.Text = "Up Arrow";
        
        // btnDown
        this.btnDown.Location = new System.Drawing.Point(150, 90);
        this.btnDown.Name = "btnDown";
        this.btnDown.Size = new System.Drawing.Size(100, 30);
        this.btnDown.TabIndex = 1;
        this.btnDown.Values.Text = "Down Arrow";
        
        // btnLeft
        this.btnLeft.Location = new System.Drawing.Point(50, 130);
        this.btnLeft.Name = "btnLeft";
        this.btnLeft.Size = new System.Drawing.Size(100, 30);
        this.btnLeft.TabIndex = 2;
        this.btnLeft.Values.Text = "Left Arrow";
        
        // btnRight
        this.btnRight.Location = new System.Drawing.Point(250, 130);
        this.btnRight.Name = "btnRight";
        this.btnRight.Size = new System.Drawing.Size(100, 30);
        this.btnRight.TabIndex = 3;
        this.btnRight.Values.Text = "Right Arrow";
        
        // cmdLinkTest
        this.cmdLinkTest.Location = new System.Drawing.Point(50, 170);
        this.cmdLinkTest.Name = "cmdLinkTest";
        this.cmdLinkTest.Size = new System.Drawing.Size(300, 50);
        this.cmdLinkTest.TabIndex = 4;
        this.cmdLinkTest.CommandLinkTextValues.Heading = "OS-Dependent Arrow Test";
        this.cmdLinkTest.CommandLinkTextValues.Description = "This command link uses OS-dependent arrow images";
        
        // lblOSInfo
        this.lblOSInfo.Location = new System.Drawing.Point(20, 230);
        this.lblOSInfo.Name = "lblOSInfo";
        this.lblOSInfo.Size = new System.Drawing.Size(360, 20);
        this.lblOSInfo.TabIndex = 5;
        this.lblOSInfo.Values.Text = "OS Info: ";
        
        // lblAvailability
        this.lblAvailability.Location = new System.Drawing.Point(20, 260);
        this.lblAvailability.Name = "lblAvailability";
        this.lblAvailability.Size = new System.Drawing.Size(360, 20);
        this.lblAvailability.TabIndex = 6;
        this.lblAvailability.Values.Text = "OS Arrow Images Available: ";
        
        // OSArrowImageTest
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 300);
        this.Controls.Add(this.kryptonPanel1);
        this.Name = "OSArrowImageTest";
        this.Text = "OS-Dependent Arrow Images Test";
        ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
        this.kryptonPanel1.ResumeLayout(false);
        this.kryptonPanel1.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    private Krypton.Toolkit.KryptonButton btnUp;
    private Krypton.Toolkit.KryptonButton btnDown;
    private Krypton.Toolkit.KryptonButton btnLeft;
    private Krypton.Toolkit.KryptonButton btnRight;
    private Krypton.Toolkit.KryptonCommandLinkButton cmdLinkTest;
    private Krypton.Toolkit.KryptonLabel lblOSInfo;
    private Krypton.Toolkit.KryptonLabel lblAvailability;
}
