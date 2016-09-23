//------------------------------------------------------------------------------
// <copyright file="HelperPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using AXDevHelper.Controls;
using AXDevHelper.Classes;

namespace AXDevHelper
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(HelperPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideOptionPage(typeof(xppDevOptionPageGrid), "Dynamics Helper", "Editor Options", 0, 0, true)]
    [ProvideOptionPage(typeof(xppDevOptionPageStrings), "Dynamics Helper", "Code markup", 0, 0, true)]
    public sealed class HelperPackage : Package
    {
        private EnvDTE80.DTE2 dte;
        private DteInitializer dteInitializer;
        /// <summary>
        /// HelperPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "b7e5412d-26a0-4f9b-b2b0-fa1cc0a2d606";

        /// <summary>
        /// Initializes a new instance of the <see cref="HelperPackage"/> class.
        /// </summary>
        public HelperPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            InitializeDTE();
            InitializeEventLog();
        }

        private void InitializeEventLog()
        {
            if (Helpers.RunningAsAdmin())
            {
                string source = Properties.Resources.xppDevEventLog;
                string logName = Properties.Resources.xppDevEventLogName;
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, logName);
                }
            }
            else
            {
                string message = Properties.Resources.registerEventSource;
                MessageBox.Show(message, Properties.Resources.xppDevEventLog, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDTE()
        {
            IVsShell shellService;

            this.dte = this.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE)) as EnvDTE80.DTE2;

            if (this.dte == null) // The IDE is not yet fully initialized
            {
                shellService = this.GetService(typeof(SVsShell)) as IVsShell;
                this.dteInitializer = new DteInitializer(shellService, this.InitializeDTE);
            }
            else
            {
                this.dteInitializer = null;
            }
        }
        #endregion
    }
    internal class DteInitializer : IVsShellPropertyEvents
    {
        private IVsShell shellService;
        private uint cookie;
        private Action callback;

        internal DteInitializer(IVsShell shellService, Action callback)
        {
            int hr;

            this.shellService = shellService;
            this.callback = callback;

            // Set an event handler to detect when the IDE is fully initialized
            hr = this.shellService.AdviseShellPropertyChanges(this, out this.cookie);

            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr);
        }

        int IVsShellPropertyEvents.OnShellPropertyChange(int propid, object var)
        {
            int hr;
            bool isZombie;

            if (propid == (int)__VSSPROPID.VSSPROPID_Zombie)
            {
                isZombie = (bool)var;

                if (!isZombie)
                {
                    // Release the event handler to detect when the IDE is fully initialized
                    hr = this.shellService.UnadviseShellPropertyChanges(this.cookie);

                    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr);

                    this.cookie = 0;

                    this.callback();
                }
            }
            return VSConstants.S_OK;
        }
    }
    [Guid("87D39309-1311-4EBA-B933-6A44D16F70BF")]
    public class xppDevOptionPageGrid : DialogPage
    {
        private Color backColorWord;
        private Color frameColorWord;
        private Color backColorRow;
        private bool highlightWord = true;
        private bool highlightRow = true;

        public Color BackColorWord
        {
            get
            {
                return backColorWord;
            }
            set
            {
                backColorWord = value;
            }
        }
       
        public Color FrameColorWord
        {
            get
            {
                return frameColorWord;
            }
            set { frameColorWord = value; }
        }
     
        public bool HighLightSelectedWord
        {
            get
            {
                return highlightWord;
            }
            set { highlightWord = value; }
        }
 
        public bool HighLightSelectedRow
        {
            get
            {
                return highlightRow;
            }
            set { highlightRow = value; }
        }
  
        public Color BackColorRow
        {
            get
            {
                return backColorRow;
            }
            set { backColorRow = value; }
        }
        protected override IWin32Window Window
        {
            get
            {
                EditorSettings editor = new EditorSettings();
                editor.xppOptionPageGrid = this;
                editor.Initialize();
                return editor;
            }
        }
    }

    [Guid("AD7A3F19-1E96-4589-B5B4-E5A993675EBD")]
    public class xppDevOptionPageStrings : DialogPage
    {
        private string defaultStartTag = Properties.Resources.StartTag;
        private string defaultEndTag = Properties.Resources.EndTag;
        private string defaultCheckInComment = Properties.Resources.defaultCheckInComment;
        private string startTag;
        private string endTag;
        private string checkInComment;
        private string developername = string.Empty;

        public string DeveloperName
        {
            get { return developername; }
            set { developername = value; }
        }
        public string CheckInComment
        {
            get
            {
                if(string.IsNullOrEmpty(checkInComment))
                {
                    checkInComment = defaultCheckInComment;
                }
                return checkInComment;
            }
            set { checkInComment = value; }
        }
        public string StartTag
        {
            get
            {
                if (string.IsNullOrEmpty(startTag))
                {
                    startTag = defaultStartTag;
                }
                return startTag;
            }
            set { startTag = value; }
        }
        public string EndTag
        {
            get
            {
                if (string.IsNullOrEmpty(endTag))
                {
                    endTag = defaultEndTag;
                }
                return endTag;
            }
            set { endTag = value; }
        }
        protected override IWin32Window Window
        {
            get
            {
                StringsEditor editor = new StringsEditor();
                editor.xppOptionsStrings = this;
                editor.Initialize();
                return editor;
            }
        }
    }

}
