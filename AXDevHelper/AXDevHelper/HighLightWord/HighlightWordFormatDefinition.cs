using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.Drawing;
using AXDevHelper.Classes;

namespace AXDevHelper
{
    [Export(typeof(EditorFormatDefinition))]
    [Name("MarkerFormatDefinition/iHighlightWordFormatDefinition")]
    [UserVisible(true)]
    internal class iHighlightWordFormatDefinition : MarkerFormatDefinition
    {
        public iHighlightWordFormatDefinition()
        {
            this.loadEditorSettings();
            this.DisplayName = Properties.Resources.selectedWordDisplayName;
            this.ZOrder = 5;
        }
   
        private void loadEditorSettings()
        {
            Color back, frame;
            RegistryHelpers.getHighlightColorWord(out back, out frame);
            BackgroundColor = System.Windows.Media.Color.FromArgb(back.A, back.R, back.G, back.B);
            ForegroundColor = System.Windows.Media.Color.FromArgb(frame.A, frame.R, frame.G, frame.B);
        }

    }
}
