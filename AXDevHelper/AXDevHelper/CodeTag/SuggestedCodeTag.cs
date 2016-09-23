using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Threading;

namespace AXDevHelper
{
    [Export(typeof(ISuggestedActionsSourceProvider))]
    [Name("Test Suggested Actions")]
    [ContentType("text")]
    internal class SuggestedActionsSourceProvider : ISuggestedActionsSourceProvider
    {
        [Import(typeof(ITextStructureNavigatorSelectorService))]
        internal ITextStructureNavigatorSelectorService NavigatorService { get; set; }

        public ISuggestedActionsSource CreateSuggestedActionsSource(ITextView textView, ITextBuffer textBuffer)
        {
            if (textBuffer == null && textView == null)
            {
                return null;
            }
            return new SuggestedActionsSource(this, textView, textBuffer);
        }
    }
    internal class SuggestedActionsSource : ISuggestedActionsSource
    {
        public event EventHandler<EventArgs> SuggestedActionsChanged;
        private readonly SuggestedActionsSourceProvider m_factory;
        private readonly ITextBuffer m_textBuffer;
        private readonly ITextView m_textView;
        public SuggestedActionsSource(SuggestedActionsSourceProvider suggestedActionsSourceProvider, ITextView textView, ITextBuffer textBuffer)
        {
            m_factory = suggestedActionsSourceProvider;
            m_textBuffer = textBuffer;
            m_textView = textView;
        }
        private bool TryGetWordUnderCaret(out TextExtent wordExtent)
        {
            ITextCaret caret = m_textView.Caret;
            SnapshotPoint point;

            if (caret.Position.BufferPosition > 0)
            {
                point = caret.Position.BufferPosition - 1;
            }
            else
            {
                wordExtent = default(TextExtent);
                return false;
            }

            ITextStructureNavigator navigator = m_factory.NavigatorService.GetTextStructureNavigator(m_textBuffer);
            wordExtent = navigator.GetExtentOfWord(point);
            return true;
        }
        public Task<bool> HasSuggestedActionsAsync(ISuggestedActionCategorySet requestedActionCategories, SnapshotSpan range, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                TextExtent extent;
                if (TryGetWordUnderCaret(out extent))
                {
                    // don't display the action if the extent has whitespace
                    return true;
                }
                return false;
            });
        }
        public IEnumerable<SuggestedActionSet> GetSuggestedActions(ISuggestedActionCategorySet requestedActionCategories, SnapshotSpan range, CancellationToken cancellationToken)
        {
            TextExtent extent;
            string selectedText = m_textView.Selection.StreamSelectionSpan.GetText();
            if (!string.IsNullOrEmpty(selectedText))
            {
                if (TryGetWordUnderCaret(out extent))
                {
                    ITrackingSpan trackingSpan = range.Snapshot.CreateTrackingSpan(m_textView.Selection.StreamSelectionSpan.SnapshotSpan, SpanTrackingMode.EdgeInclusive);
                    var codeTagAction = new InsertCodeTag(selectedText, trackingSpan);
                    var lowerAction = new InsertHeaderText(selectedText);
                    return new SuggestedActionSet[] { new SuggestedActionSet(new ISuggestedAction[] { codeTagAction, lowerAction }) };
                }

            }
            return Enumerable.Empty<SuggestedActionSet>();
        }
        public void Dispose()
        {
        }

        public bool TryGetTelemetryId(out Guid telemetryId)
        {
            // This is a sample provider and doesn't participate in LightBulb telemetry
            telemetryId = Guid.Empty;
            return false;
        }
    }
}
