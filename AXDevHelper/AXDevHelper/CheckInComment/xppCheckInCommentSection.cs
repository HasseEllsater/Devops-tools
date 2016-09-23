using System;
using System.ComponentModel;
using Microsoft.TeamFoundation.Controls;
using AXDevHelper.BaseClasses;
using Microsoft.TeamFoundation.VersionControl.Controls.Extensibility;

namespace AXDevHelper
{
    [TeamExplorerSection(GuidList.xppDevTeamExplorerSection, TeamExplorerPageIds.PendingChanges, 10)]
    public class xppCheckInCommentSection : TeamExplorerBaseSection
    {
        public xppCheckInCommentSection()
            : base()
        {
            this.Title = Properties.Resources.checkInCommentTitle;
            this.IsExpanded = true;
            this.IsBusy = false;
            this.SectionContent = new xppDevCheckInView();
            this.View.ParentSection = this;
        }
        /// <summary>
        /// Get the view.
        /// </summary>
        protected xppDevCheckInView View
        {
            get { return this.SectionContent as xppDevCheckInView; }
        }

        /// <summary>
        /// Initialize override.
        /// </summary>
        public override void Initialize(object sender, SectionInitializeEventArgs e)
        {
            base.Initialize(sender, e);
     
        }

        /// <summary>
        /// Dispose override.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
