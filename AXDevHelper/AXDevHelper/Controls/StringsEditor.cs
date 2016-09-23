using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AXDevHelper.Classes;
using static AXDevHelper.Classes.GetSettings;

namespace AXDevHelper.Controls
{
    public partial class StringsEditor : UserControl
    {
        private string selectedKeyword = string.Empty;
        public StringsEditor()
        {
            InitializeComponent();
        }
        internal xppDevOptionPageStrings xppOptionsStrings;
        public void Initialize()
        {
            startTag.Text = xppOptionsStrings.StartTag;
            endTag.Text = xppOptionsStrings.EndTag;
            checkInComment.Text = xppOptionsStrings.CheckInComment;
            name.Text = xppOptionsStrings.DeveloperName;
            constants.Items.Clear();
            FillComboBox();
        }

        private void FillComboBox()
        {
            FormatKeyWord keyword = new FormatKeyWord("{project}", "Active project");
            constants.Items.Add(keyword);

            keyword = new FormatKeyWord("{date}", "Current date and time");
            constants.Items.Add(keyword);

            keyword = new FormatKeyWord("{status}", "Check in status");
            constants.Items.Add(keyword);

            keyword = new FormatKeyWord("{developer}", "Developer name");
            constants.Items.Add(keyword);

            keyword = new FormatKeyWord("{lb}", "Line break");
            constants.Items.Add(keyword);

            keyword = new FormatKeyWord("{solution}", "Solution name");
            constants.Items.Add(keyword);

            keyword = new FormatKeyWord("{workitem}", "Work Item Id");
            constants.Items.Add(keyword);

        }
 
        private void StartTagRichText_TextChanged(object sender, EventArgs e)
        {
            xppOptionsStrings.StartTag = startTag.Text;
        }

        private void EndTagRichText_TextChanged(object sender, EventArgs e)
        {
            xppOptionsStrings.EndTag = endTag.Text;
        }
        private void checkInText_TextChanged(object sender, EventArgs e)
        {
            xppOptionsStrings.CheckInComment = checkInComment.Text;
        }
        private void name_TextChanged(object sender, EventArgs e)
        {
            xppOptionsStrings.DeveloperName = name.Text;
        }
        private void constants_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FormatKeyWord keyword = (FormatKeyWord)constants.SelectedItem;
            constant.Text = keyword.key;
            selectedKeyword = keyword.key;
            insertCheckInButton.Enabled = true;
            insertStartButton.Enabled = true;
            insertEndButton.Enabled = true;
        }

        private void insertStartButton_Click(object sender, EventArgs e)
        {
            startTag.SelectedText = selectedKeyword;
        }

        private void insertEndButton_Click(object sender, EventArgs e)
        {
            endTag.SelectedText = selectedKeyword;

        }

        private void insertCheckInButton_Click(object sender, EventArgs e)
        {
            checkInComment.SelectedText = selectedKeyword;
        }

        private void editStrings_CheckedChanged(object sender, EventArgs e)
        {
            markupGroup.Enabled = editStrings.Checked;
            checkinGroup.Enabled = editStrings.Checked;
            constants.Enabled = editStrings.Checked;
        }

        private void xppdev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xppdev.LinkVisited = true;
            System.Diagnostics.Process.Start(Properties.Resources.xppDevHomePage);

        }
    }
}
