using System.Windows.Media;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text.Classification;
using AXDevHelper.Classes;

namespace AXDevHelper
{
    #region Adornment Factory

    static class CurrentLineClassificationDefinition
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name(JAEECurrentLineHighlight.NAME)]
        internal static ClassificationTypeDefinition CurrentLineClassificationType = null;
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = JAEECurrentLineHighlight.NAME)]
    [Name(JAEECurrentLineHighlight.NAME)]
    [UserVisible(true)]
    [Order(Before = Priority.Default)]
    sealed class CurrentLineFormat : ClassificationFormatDefinition
    {
        public CurrentLineFormat()
        {
            Color backColor;
            RegistryHelpers.getHighlightColorRow(out backColor); 
            this.BackgroundColor = backColor;
            this.ForegroundBrush = Brushes.White;
        }
    }

    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class JAEECurrentLineHighlightFactory : IWpfTextViewCreationListener
    {
        [Import]
        public IClassificationTypeRegistryService ClassificationRegistry = null;
        [Import]
        public IClassificationFormatMapService FormatMapService = null;

        [Export(typeof(AdornmentLayerDefinition))]
        [Name(JAEECurrentLineHighlight.NAME)]
        [Order(Before = "Selection")]
        [TextViewRole(PredefinedTextViewRoles.Document)]
        public AdornmentLayerDefinition editorAdornmentLayer = null;

        public void TextViewCreated(IWpfTextView textView)
        {
            IClassificationType classification = ClassificationRegistry.GetClassificationType(JAEECurrentLineHighlight.NAME);
            IClassificationFormatMap map = FormatMapService.GetClassificationFormatMap(textView);
            new JAEECurrentLineHighlight(textView, map, classification);
        }
    }

    #endregion //Adornment Factory
}
