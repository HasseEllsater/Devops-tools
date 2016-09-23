/*
* Copyright (c) Microsoft Corporation. All rights reserved. This code released
* under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Controls;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace AXDevHelper
{
    /// <summary>
    /// Changes section.
    /// </summary>
    [TeamExplorerSection(GuidList.xppDevMyChangesSection, GuidList.xppDevRecentChangesPage, 10)]
    public class MyChangesSection : ChangesSectionBase
    {
        #region Members



        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public MyChangesSection()
            : base()
        {
            this.Title = Properties.Resources.MyChangesSection;
        }

        /// <summary>
        /// Get the parameters for the history query.
        /// </summary>
        protected override void GetHistoryParameters(VersionControlServer vcs, out string user, out int maxCount)
        {
            user = vcs.AuthorizedUser;
            maxCount = 10;
        }
    }
}
