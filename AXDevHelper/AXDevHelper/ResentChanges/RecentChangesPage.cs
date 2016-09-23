/*
* Copyright (c) Microsoft Corporation. All rights reserved. This code released
* under the terms of the Microsoft Limited Public License (MS-LPL).
*/
using System;
using Microsoft.TeamFoundation.Controls;
using AXDevHelper.BaseClasses;

namespace AXDevHelper
{
    /// <summary>
    /// Recent changes page.
    /// </summary>
    [TeamExplorerPage(GuidList.xppDevRecentChangesPage)]
    public class RecentChangesPage : TeamExplorerBasePage
    {
        #region Members



        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public RecentChangesPage()
            : base()
        {
            this.Title =Properties.Resources.RecentChangesPage;
            this.PageContent = new RecentChangesPageView();
        }

        /// <summary>
        /// Refresh override.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
        }

        /// <summary>
        /// ContextChanged override.
        /// </summary>
        protected override void ContextChanged(object sender, Microsoft.TeamFoundation.Client.ContextChangedEventArgs e)
        {
            base.ContextChanged(sender, e);
        }
    }
}
