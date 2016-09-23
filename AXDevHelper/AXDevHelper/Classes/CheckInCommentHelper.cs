using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.TeamFoundation.Controls;
using Microsoft.TeamFoundation.Controls.WPF.TeamExplorer;
using System.Windows;

namespace AXDevHelper.Classes
{
    class CheckInCommentHelper
    {
        public CheckInCommentHelper(ITeamExplorer teamExplorer,string comment)
        {
            try
            {
                var pendingChangesPage = (TeamExplorerPageBase)teamExplorer.CurrentPage;
                //TODO make safer
                if (pendingChangesPage != null)
                {
                    var model = pendingChangesPage.Model;
                    if(model != null)
                    {
                        var p = model.GetType().GetProperty("DataProvider", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                        var pendingChangesDataProvider = p.GetValue(model); // IPendingChangesDataProvider is internal;

                        var dataProviderType = pendingChangesDataProvider.GetType();
                        var propertyInfo = dataProviderType.GetProperty("Comment", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                        propertyInfo.SetValue(pendingChangesDataProvider, Convert.ChangeType(comment, propertyInfo.PropertyType), null);

                    }

                }
            }
            catch (Exception ex)
            {
                string reflectionError = string.Format(Properties.Resources.reflectionPendingChangesFail, ex.Message);
                Helpers.writeEventLog(reflectionError);
            }

        }
    }
}
