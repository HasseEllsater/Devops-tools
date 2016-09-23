using AXDevHelper.Classes;
using Microsoft.TeamFoundation.Controls;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace AXDevHelper.SelectWorkItem
{
    /// <summary>
    /// Interaction logic for xppSelectWorkItem.xaml
    /// </summary>
    public partial class xppSelectWorkItemView : UserControl
    {
        private bool supressTextChange = true;
        public xppSelectWorkItemView()
        {
            InitializeComponent();
            workitem.Text = UserPrivateSettings.Instance.WITNumber;
            if (workitem.Text == Properties.Resources.NoWIT)
            {
                workitem.FontStyle = FontStyles.Italic;
            }
            else
            {
                supressTextChange = false;
            }
        }
        public xppSelectWorkItemSection ParentSection
        {
            get { return (xppSelectWorkItemSection)GetValue(ParentSectionProperty); }
            set { SetValue(ParentSectionProperty, value); }
        }
        public static readonly DependencyProperty ParentSectionProperty =
            DependencyProperty.Register("ParentSection", typeof(xppSelectWorkItemSection), typeof(xppSelectWorkItemView));

        private void okClicked(object sender, RoutedEventArgs e)
        {
            UserPrivateSettings.Instance.WITNumber = workitem.Text;
            information.Text = string.Format(Properties.Resources.updatedInformationString, workitem.Text);
        }




        private void workitem_GotFocus(object sender, RoutedEventArgs e)
        {

            if (workitem.Text == Properties.Resources.NoWIT && supressTextChange == true)
            {
                workitem.FontStyle = FontStyles.Normal;
                workitem.Text = string.Empty;
                supressTextChange = false;
            }
        }

    }
}
