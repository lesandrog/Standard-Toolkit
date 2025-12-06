namespace Krypton.Toolkit
{
    partial class InternalSearchableExceptionWinFormsTreeView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Krypton.Toolkit.SearchSuggestionColumnDefinition searchSuggestionColumnDefinition1 = new Krypton.Toolkit.SearchSuggestionColumnDefinition();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.etvExceptionOutline = new Krypton.Toolkit.InternalExceptionWinFormsTreeView();
            this.kwlblResults = new Krypton.Toolkit.KryptonWrapLabel();
            this.iksbSearch = new Krypton.Toolkit.InternalKryptonSearchBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.etvExceptionOutline, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.kwlblResults, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.iksbSearch, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(362, 582);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // etvExceptionOutline
            // 
            this.etvExceptionOutline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etvExceptionOutline.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.etvExceptionOutline.Location = new System.Drawing.Point(3, 36);
            this.etvExceptionOutline.Name = "etvExceptionOutline";
            this.etvExceptionOutline.Size = new System.Drawing.Size(356, 508);
            this.etvExceptionOutline.TabIndex = 4;
            // 
            // kwlblResults
            // 
            this.kwlblResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlblResults.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.kwlblResults.Location = new System.Drawing.Point(5, 552);
            this.kwlblResults.Margin = new System.Windows.Forms.Padding(5);
            this.kwlblResults.Name = "kwlblResults";
            this.kwlblResults.Size = new System.Drawing.Size(352, 25);
            this.kwlblResults.Text = "No matches found";
            this.kwlblResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iksbSearch
            // 
            this.iksbSearch.AllowButtonSpecToolTips = true;
            searchSuggestionColumnDefinition1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            searchSuggestionColumnDefinition1.DataPropertyName = "Suggestion";
            searchSuggestionColumnDefinition1.HeaderText = "Suggestion";
            searchSuggestionColumnDefinition1.Name = "Suggestion";
            searchSuggestionColumnDefinition1.Width = 0;
            this.iksbSearch.DataGridViewColumns.Add(searchSuggestionColumnDefinition1);
            this.iksbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iksbSearch.Location = new System.Drawing.Point(5, 5);
            this.iksbSearch.Margin = new System.Windows.Forms.Padding(5);
            this.iksbSearch.Name = "iksbSearch";
            this.iksbSearch.Size = new System.Drawing.Size(352, 23);
            this.iksbSearch.TabIndex = 6;
            this.iksbSearch.Search += new System.EventHandler<Krypton.Toolkit.SearchEventArgs>(this.iksbSearch_Search);
            // 
            // InternalSearchableExceptionWinFormsTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "InternalSearchableExceptionWinFormsTreeView";
            this.Size = new System.Drawing.Size(362, 582);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private InternalExceptionWinFormsTreeView etvExceptionOutline;
        private KryptonWrapLabel kwlblResults;
        private InternalKryptonSearchBox iksbSearch;
    }
}
