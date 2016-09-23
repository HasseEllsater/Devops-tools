using System;
using System.ComponentModel;
using Microsoft.TeamFoundation.Controls;


namespace AXDevHelper
{
    [TeamExplorerPage(GuidList.xppDevTeamExplorerPage)]
    class xppTeamExplorerPage:ITeamExplorerPage
    {
        private IServiceProvider serviceProvider;
        private bool isBusy;

        public void Cancel()
        {
        }

        public object GetExtensibilityService(Type serviceType)
        {
            return null;
        }

        public void Initialize(object sender, PageInitializeEventArgs e)
        {
            this.serviceProvider = e.ServiceProvider;
        }
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            private set
            {
                this.isBusy = value;
                this.FirePropertyChanged("IsBusy");
            }
        }

        public void Loaded(object sender, PageLoadedEventArgs e)
        {
        }

        public object PageContent
        {
            get
            {
                return new xppDevPageControl();
            }
        }

        public void Refresh()
        {
        }

        public void SaveContext(object sender, PageSaveContextEventArgs e)
        {
        }

        public string Title
        {
            get
            {
                return "xppDev";
            }
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
    }
}
