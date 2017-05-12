namespace ShortCircuitEditor
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.ControlsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.gridSizer1 = new ShortCircuitEditor.GridSizer();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.ControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.GridPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ControlsPanel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 480);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // GridPanel
            // 
            this.GridPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPanel.Location = new System.Drawing.Point(3, 3);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(474, 474);
            this.GridPanel.TabIndex = 0;
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ControlsPanel.Controls.Add(this.button1);
            this.ControlsPanel.Controls.Add(this.gridSizer1);
            this.ControlsPanel.Controls.Add(this.button2);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsPanel.Location = new System.Drawing.Point(483, 3);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(154, 474);
            this.ControlsPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "View Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // gridSizer1
            // 
            this.gridSizer1.Location = new System.Drawing.Point(3, 32);
            this.gridSizer1.Name = "gridSizer1";
            this.gridSizer1.Size = new System.Drawing.Size(112, 27);
            this.gridSizer1.TabIndex = 1;
            this.gridSizer1.Value = 0;
            this.gridSizer1.GridSizeChanged += new ShortCircuitEditor.GridSizeChange(this.GridSizer1GridSizeChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Short Circuit Editor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ControlsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.FlowLayoutPanel ControlsPanel;
        private System.Windows.Forms.Button button1;
        private GridSizer gridSizer1;
        private System.Windows.Forms.Button button2;

    }
}

