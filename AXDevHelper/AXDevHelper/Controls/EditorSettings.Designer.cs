namespace AXDevHelper.Controls
{
    partial class EditorSettings
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
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.editorPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.xppdev = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoEllipsis = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label6.Location = new System.Drawing.Point(59, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(343, 62);
            this.label6.TabIndex = 10;
            this.label6.Text = "Set the color options for the editor extensions";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::AXDevHelper.Properties.Resources.XppDevs_Logo_48x48;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // editorPropertyGrid
            // 
            this.editorPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorPropertyGrid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.editorPropertyGrid.Location = new System.Drawing.Point(3, 69);
            this.editorPropertyGrid.Name = "editorPropertyGrid";
            this.editorPropertyGrid.Size = new System.Drawing.Size(420, 344);
            this.editorPropertyGrid.TabIndex = 11;
            // 
            // xppdev
            // 
            this.xppdev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xppdev.AutoSize = true;
            this.xppdev.Location = new System.Drawing.Point(3, 421);
            this.xppdev.Name = "xppdev";
            this.xppdev.Size = new System.Drawing.Size(73, 13);
            this.xppdev.TabIndex = 12;
            this.xppdev.TabStop = true;
            this.xppdev.Text = "Visit XppDevs";
            this.xppdev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.xppdev_LinkClicked);
            // 
            // EditorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xppdev);
            this.Controls.Add(this.editorPropertyGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EditorSettings";
            this.Size = new System.Drawing.Size(435, 444);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PropertyGrid editorPropertyGrid;
        private System.Windows.Forms.LinkLabel xppdev;
    }
}
