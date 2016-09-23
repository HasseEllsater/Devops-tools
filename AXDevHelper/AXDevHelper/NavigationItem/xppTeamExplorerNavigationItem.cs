using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Drawing;
using Microsoft.TeamFoundation.Controls;
using Microsoft.VisualStudio.Shell;
using AXDevHelper.Properties;

namespace AXDevHelper
{

    [TeamExplorerNavigationItem(GuidList.xppDevTeamExplorerNavigationItem, 100)]
    public class SampleTeamExplorerNavigationItem : ITeamExplorerNavigationItem
    {
        private Image image = Resources.SampleImage;

        private bool isVisible = true;

        private string text = Properties.Resources.xppDev;

        [ImportingConstructor]
        public SampleTeamExplorerNavigationItem([Import(typeof(SVsServiceProvider))] IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        private IServiceProvider serviceProvider { get; set; }

        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
                this.FirePropertyChanged("Image");
            }
        }

        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
                this.FirePropertyChanged("IsVisible");
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                this.FirePropertyChanged("Text");
            }
        }

        public void Execute()
        {
            var service = this.GetService<ITeamExplorer>();
            if(service == null)
            {
                return;
            }
            service.NavigateToPage(new Guid(GuidList.xppDevRecentChangesPage), null);
        }

        public void Invalidate()
        {
        }

        public void Dispose()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public T GetService<T>()
        {
            if (this.serviceProvider != null)
            {
                return (T)this.serviceProvider.GetService(typeof(T));
            }
            return default(T);
        }
    }
}
