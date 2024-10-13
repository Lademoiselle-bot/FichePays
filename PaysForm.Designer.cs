namespace FichesPays
{
    partial class PaysForm
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
            this.nomPaysLabel = new System.Windows.Forms.Label();
            this.capitalePaysLabel = new System.Windows.Forms.Label();
            this.superficieLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.capitaleTextBox = new System.Windows.Forms.TextBox();
            this.superficieTextBox = new System.Windows.Forms.TextBox();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // nomPaysLabel
            // 
            this.nomPaysLabel.AutoSize = true;
            this.nomPaysLabel.Location = new System.Drawing.Point(25, 55);
            this.nomPaysLabel.Name = "nomPaysLabel";
            this.nomPaysLabel.Size = new System.Drawing.Size(36, 16);
            this.nomPaysLabel.TabIndex = 0;
            this.nomPaysLabel.Text = "Nom";
            // 
            // capitalePaysLabel
            // 
            this.capitalePaysLabel.AutoSize = true;
            this.capitalePaysLabel.Location = new System.Drawing.Point(25, 115);
            this.capitalePaysLabel.Name = "capitalePaysLabel";
            this.capitalePaysLabel.Size = new System.Drawing.Size(57, 16);
            this.capitalePaysLabel.TabIndex = 1;
            this.capitalePaysLabel.Text = "Capitale";
            // 
            // superficieLabel
            // 
            this.superficieLabel.AutoSize = true;
            this.superficieLabel.Location = new System.Drawing.Point(25, 174);
            this.superficieLabel.Name = "superficieLabel";
            this.superficieLabel.Size = new System.Drawing.Size(67, 16);
            this.superficieLabel.TabIndex = 2;
            this.superficieLabel.Text = "Superficie";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(25, 223);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(75, 16);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description";
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(120, 55);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(255, 22);
            this.nomTextBox.TabIndex = 4;
            this.nomTextBox.TextChanged += new System.EventHandler(this.capitaleTextBox_TextChanged);
            // 
            // capitaleTextBox
            // 
            this.capitaleTextBox.Location = new System.Drawing.Point(120, 109);
            this.capitaleTextBox.Name = "capitaleTextBox";
            this.capitaleTextBox.Size = new System.Drawing.Size(255, 22);
            this.capitaleTextBox.TabIndex = 5;
            this.capitaleTextBox.TextChanged += new System.EventHandler(this.capitaleTextBox_TextChanged);
            // 
            // superficieTextBox
            // 
            this.superficieTextBox.Location = new System.Drawing.Point(121, 168);
            this.superficieTextBox.Name = "superficieTextBox";
            this.superficieTextBox.Size = new System.Drawing.Size(254, 22);
            this.superficieTextBox.TabIndex = 6;
            this.superficieTextBox.TextChanged += new System.EventHandler(this.capitaleTextBox_TextChanged);
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(127, 213);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(248, 129);
            this.descriptionRichTextBox.TabIndex = 7;
            this.descriptionRichTextBox.Text = "";
            this.descriptionRichTextBox.SelectionChanged += new System.EventHandler(this.descriptionRichTextBox_SelectionChanged);
            this.descriptionRichTextBox.TextChanged += new System.EventHandler(this.capitaleTextBox_TextChanged);
            // 
            // PaysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 358);
            this.Controls.Add(this.descriptionRichTextBox);
            this.Controls.Add(this.superficieTextBox);
            this.Controls.Add(this.capitaleTextBox);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.superficieLabel);
            this.Controls.Add(this.capitalePaysLabel);
            this.Controls.Add(this.nomPaysLabel);
            this.Name = "PaysForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PaysForm";
            this.Activated += new System.EventHandler(this.PaysForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaysForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nomPaysLabel;
        private System.Windows.Forms.Label capitalePaysLabel;
        private System.Windows.Forms.Label superficieLabel;
        private System.Windows.Forms.Label descriptionLabel;
        public System.Windows.Forms.RichTextBox descriptionRichTextBox;
        internal System.Windows.Forms.TextBox capitaleTextBox;
        internal System.Windows.Forms.TextBox superficieTextBox;
        internal System.Windows.Forms.TextBox nomTextBox;
    }
}