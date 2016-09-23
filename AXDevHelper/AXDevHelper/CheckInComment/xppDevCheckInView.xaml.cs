using AXDevHelper.Classes;
using Microsoft.TeamFoundation.Controls;
using Microsoft.TeamFoundation.VersionControl.Controls.Extensibility;
using System;
using System.Windows;
using System.Windows.Controls;


namespace AXDevHelper
{
    /// <summary>
    /// Interaction logic for xppDevPageControl.xaml
    /// </summary>
    public partial class xppDevCheckInView : UserControl
    {
        public xppDevCheckInView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Parent section.
        /// </summary>
        public xppCheckInCommentSection ParentSection
        {
            get { return (xppCheckInCommentSection)GetValue(ParentSectionProperty); }
            set { SetValue(ParentSectionProperty, value); }
        }
        public static readonly DependencyProperty ParentSectionProperty =
            DependencyProperty.Register("ParentSection", typeof(xppCheckInCommentSection), typeof(xppDevCheckInView));

        private void checkInStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateComment();
        }

        private void updateComment()
        {
            string selectedStatus = (string)((ComboBoxItem)checkInStatus.SelectedValue).Content;
            string output = RegistryHelpers.getCheckInComment(selectedStatus);

            ITeamExplorer teamExplorer = ParentSection.GetService<ITeamExplorer>();
            if (teamExplorer != null)
            {
                CheckInCommentHelper helper = new CheckInCommentHelper(teamExplorer, output);
            }
        }
    }
}
