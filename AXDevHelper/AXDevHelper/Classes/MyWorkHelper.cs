using Microsoft.TeamFoundation.Controls;
using Microsoft.TeamFoundation.Controls.WPF.TeamExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AXDevHelper.Classes
{
    class MyWorkHelper
    {
        public MyWorkHelper()
        {
        }
        public void GetWorkInProgress(ITeamExplorer teamExplorer)
        {
            var myWorkPage = (TeamExplorerPageBase)teamExplorer.CurrentPage;

            if (myWorkPage != null)
            {
                var model = myWorkPage.Model;
                //var p = model.GetType();//.GetProperty("MyWorkWorkItems", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
           
                //var p = model.GetType().GetProperty("ActiveWorkItems", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                //var workItemsListProvider = p.GetValue(model); // IWorkItemInformationProvider is internal;

                /*  var dataProviderType = pendingChangesDataProvider.GetType();
                var propertyInfo = dataProviderType.GetProperty("Comment", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                propertyInfo.SetValue(pendingChangesDataProvider, Convert.ChangeType(comment, propertyInfo.PropertyType), null);*/

            }

        }
    }
}
