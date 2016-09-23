using System;
using Microsoft.TeamFoundation.Controls;
using AXDevHelper.BaseClasses;

namespace AXDevHelper.SelectWorkItem
{
    [TeamExplorerSection(GuidList.xppDevWorkItemSection, TeamExplorerPageIds.MyWork, 10)]
    public class xppSelectWorkItemSection : TeamExplorerBaseSection
    {
        public xppSelectWorkItemSection()
            :base()
        {
            this.Title = Properties.Resources.selectWIT;
            this.IsExpanded = true;
            this.IsBusy = false;
            this.SectionContent = new xppSelectWorkItemView();
            this.View.ParentSection = this;
        }
        /// <summary>
        /// Get the view.
        /// </summary>
        protected xppSelectWorkItemView View
        {
            get { return this.SectionContent as xppSelectWorkItemView; }
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
