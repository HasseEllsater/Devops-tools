/*
* Copyright (c) Microsoft Corporation. All rights reserved. This code released
* under the terms of the Microsoft Limited Public License (MS-LPL).
*/

using Microsoft.TeamFoundation.Controls;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace AXDevHelper
{
    /// <summary>
    /// All Changes section.
    /// </summary>
    [TeamExplorerSection(GuidList.xppDevAllChangesSection, GuidList.xppDevRecentChangesPage, 20)]
    public class AllChangesSection : ChangesSectionBase
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public AllChangesSection()
            : base()
        {
            this.Title = Properties.Resources.AllChangesSection;
        }

        /// <summary>
        /// Get the parameters for the history query.
        /// </summary>
        protected override void GetHistoryParameters(VersionControlServer vcs, out string user, out int maxCount)
        {
            user = null;
            maxCount = 100;
        }
    }
}
