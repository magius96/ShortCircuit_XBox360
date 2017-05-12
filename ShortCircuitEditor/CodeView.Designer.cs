namespace ShortCircuitEditor
{
    partial class CodeView
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
            this.CodeDisplayText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CodeDisplayText
            // 
            this.CodeDisplayText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeDisplayText.Location = new System.Drawing.Point(0, 0);
            this.CodeDisplayText.Multiline = true;
            this.CodeDisplayText.Name = "CodeDisplayText";
            this.CodeDisplayText.Size = new System.Drawing.Size(737, 523);
            this.CodeDisplayText.TabIndex = 0;
            this.CodeDisplayText.Click += new System.EventHandler(this.CodeDisplayTextClick);
            // 
            // CodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 523);
            this.Controls.Add(this.CodeDisplayText);
            this.Name = "CodeView";
            this.ShowIcon = false;
            this.Text = "CodeView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CodeDisplayText;
    }
}