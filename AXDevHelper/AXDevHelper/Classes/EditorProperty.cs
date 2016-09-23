using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXDevHelper.Classes
{
    internal class EditorProperty : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Color backColorWord;
        private Color frameColorWord;
        private Color backColorRow;
        private bool highlightWord = true;
        private bool highlightRow = true;



        [Category("Dynamics Helper")]
        [DisplayName("Highlight Word Back Color")]
        [Description("The background color of highlighted words")]
        public Color BackColorWord
        {
            get
            {
                return backColorWord;
            }
            set
            {
                backColorWord = value;
                NotifyPropertyChanged("BackColorWord");
            }
        }

        [Category("Dynamics Helper")]
        [DisplayName("Highlight Word Frame Color")]
        [Description("The frame color of highlighted words")]
        public Color FrameColorWord
        {
            get
            {
                return frameColorWord;
            }
            set
            {
                frameColorWord = value;
                NotifyPropertyChanged("FrameColorWord");

            }
        }
        [Category("Dynamics Helper")]
        [DisplayName("Highlight word")]
        [Description("Highlight words on select only")]
        public bool HighLightSelectedWord
        {
            get
            {
                return highlightWord;
            }
            set
            {
                highlightWord = value;
                NotifyPropertyChanged("HighLightSelectedWord");
            }
        }
        [Category("Dynamics Helper")]
        [DisplayName("Highlight Current Row")]
        [Description("Highlight Row on or off")]
        public bool HighLightSelectedRow
        {
            get
            {
                return highlightRow;
            }
            set
            {
                highlightRow = value;
                NotifyPropertyChanged("HighLightSelectedRow");

            }
        }
        [Category("Dynamics Helper")]
        [DisplayName("Highlight Row Back Color")]
        [Description("The background color of highlighted row")]
        public Color BackColorRow
        {
            get
            {
                return backColorRow;
            }
            set
            {
                backColorRow = value;
                NotifyPropertyChanged("BackColorRow");

            }
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
