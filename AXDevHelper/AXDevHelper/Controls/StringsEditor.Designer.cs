namespace AXDevHelper.Controls
{
    partial class StringsEditor
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
            this.startTag = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.endTag = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.markupGroup = new System.Windows.Forms.GroupBox();
            this.insertEndButton = new System.Windows.Forms.Button();
            this.insertStartButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.constants = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkinGroup = new System.Windows.Forms.GroupBox();
            this.insertCheckInButton = new System.Windows.Forms.Button();
            this.checkInComment = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.constant = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.editStrings = new System.Windows.Forms.CheckBox();
            this.xppdev = new System.Windows.Forms.LinkLabel();
            this.markupGroup.SuspendLayout();
            this.checkinGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // startTag
            // 
            this.startTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startTag.Location = new System.Drawing.Point(10, 34);
            this.startTag.Name = "startTag";
            this.startTag.Size = new System.Drawing.Size(394, 39);
            this.startTag.TabIndex = 0;
            this.startTag.Text = "";
            this.startTag.TextChanged += new System.EventHandler(this.StartTagRichText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start tag";
            // 
            // endTag
            // 
            this.endTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endTag.Location = new System.Drawing.Point(10, 108);
            this.endTag.Name = "endTag";
            this.endTag.Size = new System.Drawing.Size(394, 51);
            this.endTag.TabIndex = 2;
            this.endTag.Text = "";
            this.endTag.TextChanged += new System.EventHandler(this.EndTagRichText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "End tag";
            // 
            // markupGroup
            // 
            this.markupGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markupGroup.Controls.Add(this.insertEndButton);
            this.markupGroup.Controls.Add(this.insertStartButton);
            this.markupGroup.Controls.Add(this.startTag);
            this.markupGroup.Controls.Add(this.label2);
            this.markupGroup.Controls.Add(this.label1);
            this.markupGroup.Controls.Add(this.endTag);
            this.markupGroup.Enabled = false;
            this.markupGroup.Location = new System.Drawing.Point(3, 152);
            this.markupGroup.Name = "markupGroup";
            this.markupGroup.Size = new System.Drawing.Size(419, 198);
            this.markupGroup.TabIndex = 1;
            this.markupGroup.TabStop = false;
            this.markupGroup.Text = "Code markup";
            // 
            // insertEndButton
            // 
            this.insertEndButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insertEndButton.Enabled = false;
            this.insertEndButton.Location = new System.Drawing.Point(329, 165);
            this.insertEndButton.Name = "insertEndButton";
            this.insertEndButton.Size = new System.Drawing.Size(75, 23);
            this.insertEndButton.TabIndex = 3;
            this.insertEndButton.Text = "Insert constant";
            this.insertEndButton.UseVisualStyleBackColor = true;
            this.insertEndButton.Click += new System.EventHandler(this.insertEndButton_Click);
            // 
            // insertStartButton
            // 
            this.insertStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insertStartButton.Enabled = false;
            this.insertStartButton.Location = new System.Drawing.Point(329, 79);
            this.insertStartButton.Name = "insertStartButton";
            this.insertStartButton.Size = new System.Drawing.Size(75, 23);
            this.insertStartButton.TabIndex = 1;
            this.insertStartButton.Text = "Insert constant";
            this.insertStartButton.UseVisualStyleBackColor = true;
            this.insertStartButton.Click += new System.EventHandler(this.insertStartButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Comment format";
            // 
            // constants
            // 
            this.constants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.constants.Enabled = false;
            this.constants.FormattingEnabled = true;
            this.constants.Location = new System.Drawing.Point(134, 530);
            this.constants.Name = "constants";
            this.constants.Size = new System.Drawing.Size(218, 21);
            this.constants.TabIndex = 3;
            this.constants.SelectionChangeCommitted += new System.EventHandler(this.constants_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoEllipsis = true;
            this.label4.Location = new System.Drawing.Point(14, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(400, 43);
            this.label4.TabIndex = 4;
            this.label4.Text = "Add valid constants to your text, the constants will be parsed into your text. Se" +
    "lect a text to edit, pick your constant and click the insert button.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Text constants";
            // 
            // checkinGroup
            // 
            this.checkinGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkinGroup.Controls.Add(this.insertCheckInButton);
            this.checkinGroup.Controls.Add(this.checkInComment);
            this.checkinGroup.Controls.Add(this.label3);
            this.checkinGroup.Enabled = false;
            this.checkinGroup.Location = new System.Drawing.Point(3, 356);
            this.checkinGroup.Name = "checkinGroup";
            this.checkinGroup.Size = new System.Drawing.Size(420, 101);
            this.checkinGroup.TabIndex = 2;
            this.checkinGroup.TabStop = false;
            this.checkinGroup.Text = "Check in";
            // 
            // insertCheckInButton
            // 
            this.insertCheckInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insertCheckInButton.Enabled = false;
            this.insertCheckInButton.Location = new System.Drawing.Point(327, 69);
            this.insertCheckInButton.Name = "insertCheckInButton";
            this.insertCheckInButton.Size = new System.Drawing.Size(75, 23);
            this.insertCheckInButton.TabIndex = 2;
            this.insertCheckInButton.Text = "Insert constant";
            this.insertCheckInButton.UseVisualStyleBackColor = true;
            this.insertCheckInButton.Click += new System.EventHandler(this.insertCheckInButton_Click);
            // 
            // checkInComment
            // 
            this.checkInComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkInComment.Location = new System.Drawing.Point(10, 41);
            this.checkInComment.Name = "checkInComment";
            this.checkInComment.Size = new System.Drawing.Size(392, 22);
            this.checkInComment.TabIndex = 0;
            this.checkInComment.TextChanged += new System.EventHandler(this.checkInText_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::AXDevHelper.Properties.Resources.XppDevs_Logo_48x48;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoEllipsis = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label6.Location = new System.Drawing.Point(57, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(376, 48);
            this.label6.TabIndex = 8;
            this.label6.Text = "Set the format for the strings to use to markup your code and check in comments";
            // 
            // constant
            // 
            this.constant.AutoSize = true;
            this.constant.Location = new System.Drawing.Point(358, 533);
            this.constant.Name = "constant";
            this.constant.Size = new System.Drawing.Size(11, 13);
            this.constant.TabIndex = 3;
            this.constant.Text = "-";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.name);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(3, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 65);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Developer";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(48, 24);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(354, 22);
            this.name.TabIndex = 0;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Name";
            // 
            // editStrings
            // 
            this.editStrings.AutoSize = true;
            this.editStrings.Location = new System.Drawing.Point(12, 129);
            this.editStrings.Name = "editStrings";
            this.editStrings.Size = new System.Drawing.Size(84, 17);
            this.editStrings.TabIndex = 9;
            this.editStrings.Text = "Edit strings";
            this.editStrings.UseVisualStyleBackColor = true;
            this.editStrings.CheckedChanged += new System.EventHandler(this.editStrings_CheckedChanged);
            // 
            // xppdev
            // 
            this.xppdev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xppdev.AutoSize = true;
            this.xppdev.Location = new System.Drawing.Point(9, 554);
            this.xppdev.Name = "xppdev";
            this.xppdev.Size = new System.Drawing.Size(76, 13);
            this.xppdev.TabIndex = 13;
            this.xppdev.TabStop = true;
            this.xppdev.Text = "Visit XppDevs";
            this.xppdev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.xppdev_LinkClicked);
            // 
            // StringsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xppdev);
            this.Controls.Add(this.editStrings);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.constant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkinGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.constants);
            this.Controls.Add(this.markupGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StringsEditor";
            this.Size = new System.Drawing.Size(450, 576);
            this.markupGroup.ResumeLayout(false);
            this.markupGroup.PerformLayout();
            this.checkinGroup.ResumeLayout(false);
            this.checkinGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox startTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox endTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox markupGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox constants;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox checkinGroup;
        private System.Windows.Forms.TextBox checkInComment;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label constant;
        private System.Windows.Forms.Button insertCheckInButton;
        private System.Windows.Forms.Button insertEndButton;
        private System.Windows.Forms.Button insertStartButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox editStrings;
        private System.Windows.Forms.LinkLabel xppdev;
    }
}
