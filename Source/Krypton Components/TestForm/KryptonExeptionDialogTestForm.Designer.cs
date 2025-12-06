namespace TestForm
{
    partial class KryptonExeptionDialogTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonExeptionDialogTestForm));
            this.kcbtnHighlightColor = new Krypton.Toolkit.KryptonColorButton();
            this.kcbShowCopyButton = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbShowSearchBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnTriggerException = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kcbtnHighlightColor
            // 
            this.kcbtnHighlightColor.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcbtnHighlightColor.Location = new System.Drawing.Point(12, 12);
            this.kcbtnHighlightColor.Name = "kcbtnHighlightColor";
            this.kcbtnHighlightColor.SelectedColor = System.Drawing.Color.LightYellow;
            this.kcbtnHighlightColor.Size = new System.Drawing.Size(202, 25);
            this.kcbtnHighlightColor.TabIndex = 0;
            this.kcbtnHighlightColor.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonColorButton1.Values.Image")));
            this.kcbtnHighlightColor.Values.RoundedCorners = 8;
            this.kcbtnHighlightColor.Values.Text = "Highlight Color";
            // 
            // kcbShowCopyButton
            // 
            this.kcbShowCopyButton.Location = new System.Drawing.Point(12, 44);
            this.kcbShowCopyButton.Name = "kcbShowCopyButton";
            this.kcbShowCopyButton.Size = new System.Drawing.Size(125, 20);
            this.kcbShowCopyButton.TabIndex = 2;
            this.kcbShowCopyButton.Values.Text = "Show &Copy Button";
            // 
            // kcbShowSearchBox
            // 
            this.kcbShowSearchBox.Location = new System.Drawing.Point(12, 70);
            this.kcbShowSearchBox.Name = "kcbShowSearchBox";
            this.kcbShowSearchBox.Size = new System.Drawing.Size(116, 20);
            this.kcbShowSearchBox.TabIndex = 3;
            this.kcbShowSearchBox.Values.Text = "Show &Search Box";
            // 
            // kbtnTriggerException
            // 
            this.kbtnTriggerException.Location = new System.Drawing.Point(12, 96);
            this.kbtnTriggerException.Name = "kbtnTriggerException";
            this.kbtnTriggerException.Size = new System.Drawing.Size(202, 25);
            this.kbtnTriggerException.TabIndex = 4;
            this.kbtnTriggerException.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kbtnTriggerException.Values.Text = "Trigger Exception";
            this.kbtnTriggerException.Click += new System.EventHandler(this.kbtnTriggerException_Click);
            // 
            // KryptonExeptionDialogTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kbtnTriggerException);
            this.Controls.Add(this.kcbShowSearchBox);
            this.Controls.Add(this.kcbShowCopyButton);
            this.Controls.Add(this.kcbtnHighlightColor);
            this.Name = "KryptonExeptionDialogTestForm";
            this.Text = "KryptonExeptionDialogTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonColorButton kcbtnHighlightColor;
        private KryptonCheckBox kcbShowCopyButton;
        private KryptonCheckBox kcbShowSearchBox;
        private KryptonButton kbtnTriggerException;
    }
}