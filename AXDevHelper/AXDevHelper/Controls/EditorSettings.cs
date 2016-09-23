using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AXDevHelper.Classes;

namespace AXDevHelper.Controls
{
    public partial class EditorSettings : UserControl
    {
        internal xppDevOptionPageGrid xppOptionPageGrid;
        private EditorProperty properties = new EditorProperty();
        public EditorSettings()
        {
            InitializeComponent();
        }
        public void Initialize()
        {
            initPropertyPageFromRegistry();

            properties.BackColorRow = xppOptionPageGrid.BackColorRow;
            properties.BackColorWord = xppOptionPageGrid.BackColorWord;
            properties.FrameColorWord = xppOptionPageGrid.FrameColorWord;
            properties.HighLightSelectedRow = xppOptionPageGrid.HighLightSelectedRow;
            properties.HighLightSelectedWord = xppOptionPageGrid.HighLightSelectedWord;

            this.setPropertyClass((object)properties);
            properties.PropertyChanged += new PropertyChangedEventHandler(editorPropertyGridPropertyChanged);

        }

        private void initPropertyPageFromRegistry()
        {
            Color backColorRow;
            RegistryHelpers.getHighlightColorRow(out backColorRow);
            xppOptionPageGrid.BackColorRow = backColorRow;
            
            Color backColorWord, frameColorWord;
            RegistryHelpers.getHighlightColorWord(out backColorWord, out frameColorWord);

            xppOptionPageGrid.BackColorWord = backColorWord;
            xppOptionPageGrid.FrameColorWord = frameColorWord;
        }

        public void editorPropertyGridPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            EditorProperty properties = (EditorProperty)this.getPropertyClass();
            if (properties != null)
            {
                switch (e.PropertyName.ToString())
                {
                    case "BackColorRow":
                        xppOptionPageGrid.BackColorRow = properties.BackColorRow;
                        break;
                    case "BackColorWord":
                        xppOptionPageGrid.BackColorWord = properties.BackColorWord;
                        break;
                    case "FrameColorWord":
                        xppOptionPageGrid.FrameColorWord = properties.FrameColorWord;
                        break;
                    case "HighLightSelectedRow":
                        xppOptionPageGrid.HighLightSelectedRow = properties.HighLightSelectedRow;
                        break;
                    case "HighLightSelectedWord":
                        xppOptionPageGrid.HighLightSelectedWord = properties.HighLightSelectedWord;
                        break;

                    default:
                        break;
                }
                editorPropertyGrid.Refresh();
            }
        }
        public void setPropertyClass(Object _class)
        {
            editorPropertyGrid.SelectedObject = _class;
        }
        public Object getPropertyClass()
        {
            return editorPropertyGrid.SelectedObject;
        }

        private void xppdev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xppdev.LinkVisited = true;
            System.Diagnostics.Process.Start(Properties.Resources.xppDevHomePage);
        }
    }
}
