using AXDevHelper.Classes;
using Microsoft.VisualStudio.Imaging.Interop;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace AXDevHelper
{
    internal class InsertCodeTag : ISuggestedAction
    {
        private ITrackingSpan m_span;
        private string m_codeBlock;
        private string m_display;
        private ITextSnapshot m_snapshot;


        public bool HasActionSets
        {
            get { return false; }
        }
        public string DisplayText
        {
            get { return m_display; }
        }
        public ImageMoniker IconMoniker
        {
            get { return default(ImageMoniker); }
        }
        public string IconAutomationText
        {
            get
            {
                return null;
            }
        }
        public string InputGestureText
        {
            get
            {
                return null;
            }
        }
        public bool HasPreview
        {
            get { return true; }
        }
        public InsertCodeTag(string _selectedText, ITrackingSpan span)
        {
            string startTag, endTag;
            RegistryHelpers.getStartAndEndTag(out startTag, out endTag);
    
            m_span = span;
            m_snapshot = span.TextBuffer.CurrentSnapshot;
            string newLine = string.Format("{0}{1}{2}{3}{4}{5}", startTag, Environment.NewLine, _selectedText.Trim(), Environment.NewLine, endTag, Environment.NewLine);
            m_codeBlock = newLine;
            m_display = Properties.Resources.InsertCodeTag;
        }
        public Task<object> GetPreviewAsync(CancellationToken cancellationToken)
        {
            var textBlock = new TextBlock();
            textBlock.Padding = new Thickness(5);
            textBlock.Inlines.Add(new Run() { Text = m_codeBlock });
            return Task.FromResult<object>(textBlock);
        }
        public Task<IEnumerable<SuggestedActionSet>> GetActionSetsAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<IEnumerable<SuggestedActionSet>>(null);
        }
        public void Invoke(CancellationToken cancellationToken)
        {
            SnapshotSpan span = m_span.GetSpan(m_snapshot);
            m_span.TextBuffer.Replace(span, m_codeBlock);

        }
        public void Dispose()
        {
        }
        public bool TryGetTelemetryId(out Guid telemetryId)
        {
            // This is a sample action and doesn't participate in LightBulb telemetry
            telemetryId = Guid.Empty;
            return false;
        }
    }
    internal class InsertHeaderText : ISuggestedAction
    {
        private ITrackingSpan m_span;
        private string m_upper;
        private string m_display;
        private ITextSnapshot m_snapshot;
        public bool HasActionSets
        {
            get { return false; }
        }
        public string DisplayText
        {
            get { return m_display; }
        }
        public ImageMoniker IconMoniker
        {
            get { return default(ImageMoniker); }
        }
        public string IconAutomationText
        {
            get
            {
                return null;
            }
        }
        public string InputGestureText
        {
            get
            {
                return null;
            }
        }
        public bool HasPreview
        {
            get { return true; }
        }
        public InsertHeaderText(string _selectedText)
        {
            m_display = string.Format("<empty>", _selectedText);
        }
        public Task<object> GetPreviewAsync(CancellationToken cancellationToken)
        {
            var textBlock = new TextBlock();
            textBlock.Padding = new Thickness(5);
            textBlock.Inlines.Add(new Run() { Text = m_upper });
            return Task.FromResult<object>(textBlock);
        }
        public Task<IEnumerable<SuggestedActionSet>> GetActionSetsAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<IEnumerable<SuggestedActionSet>>(null);
        }
        public void Invoke(CancellationToken cancellationToken)
        {
            m_span.TextBuffer.Replace(m_span.GetSpan(m_snapshot), m_upper);
        }
        public void Dispose()
        {
        }
        public bool TryGetTelemetryId(out Guid telemetryId)
        {
            // This is a sample action and doesn't participate in LightBulb telemetry
            telemetryId = Guid.Empty;
            return false;
        }
    }
}
