using EnvDTE;
using EnvDTE80;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.VisualStudio.TeamFoundation.VersionControl;
using Microsoft.VisualStudio.Shell.Interop;
using System.Windows;
using System.Diagnostics;
using System.Security.Principal;

namespace AXDevHelper.Classes
{
    class xppDevHelper
    {
        internal static string GetActiveProject()
        {
            string name = string.Empty;

            try
            {
                DTE2 dte;
                dte = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject(Properties.Resources.VisualStudio);
                //this.dte = this.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE)) as EnvDTE80.DTE2;
                Project activeProject = null;
                if (dte != null)
                {
                    Array activeSolutionProjects = dte.ActiveSolutionProjects as Array;
                    if (activeSolutionProjects != null && activeSolutionProjects.Length > 0)
                    {
                        activeProject = activeSolutionProjects.GetValue(0) as Project;
                        name = activeProject.Name;
                    }
                }

            }
            catch (Exception ex)
            {
                Helpers.writeEventLog(ex.Message);
            }
 
            return name;
        }
        internal static string GetActiveSolution()
        {
            string name = string.Empty;

            try
            {
                DTE2 dte;
                dte = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject(Properties.Resources.VisualStudio);
                //this.dte = this.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE)) as EnvDTE80.DTE2;
                Solution solution = null;
                if (dte != null)
                {
                    solution = dte.Solution;
                    name = solution.FullName;
                    int lastindex = name.LastIndexOf("\\");
                    if (lastindex > 0)
                    {
                        name = name.Substring(lastindex);
                        name = name.Replace(".sln", string.Empty);
                        name = name.Replace("\\", string.Empty);
                    }
                }

            }
            catch (Exception ex)
            {
                Helpers.writeEventLog(ex.Message);
            }

            return name;
        }

        internal static void GetSettings(DTE2 dte)
        {
            return;
/*            DTE2 dte;
            dte = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject(Properties.Resources.VisualStudio);
            */

            EnvDTE.Properties txtEdCS = dte.get_Properties("AXDevHelper", "xppDevOptionPageGrid");
            EnvDTE.Property prop = null;
            string msg = null;

            // Loop through each item in the C# text editor options page. 
            foreach (EnvDTE.Property temp in txtEdCS)
            {
                prop = temp;
                msg += ("PROP NAME: " + prop.Name + "   VALUE: "+ prop.Value) + "\n";
            }
        }
    }
    public class RegistryHelpers
    {
#if DEBUG
        static string keyOptions= @"SOFTWARE\Microsoft\VisualStudio\14.0Exp\ApplicationPrivateSettings\AXDevHelper\xppDevOptionPageGrid";
#else
        static string keyOptions = @"SOFTWARE\Microsoft\VisualStudio\14.0\ApplicationPrivateSettings\AXDevHelper\xppDevOptionPageGrid";
#endif
#if DEBUG
        static string keyStrings = @"SOFTWARE\Microsoft\VisualStudio\14.0Exp\ApplicationPrivateSettings\AXDevHelper\xppDevOptionPageStrings";
#else
        static string keyStrings= @"SOFTWARE\Microsoft\VisualStudio\14.0\ApplicationPrivateSettings\AXDevHelper\xppDevOptionPageStrings";
#endif
        public static RegistryKey GetRegistryKey()
        {
            return GetRegistryKey(null);
        }

        public static string getCheckInComment(string status)
        {
            string checkInComment = Properties.Resources.notConfigured;

            try
            {
                string developername = string.Empty;
                RegistryHelpers.getDeveloperName(out developername);

                string keyName = "CheckInComment";
                checkInComment = RegistryHelpers.GetRegistryValue(keyStrings, keyName);
                string activeProject = xppDevHelper.GetActiveProject();
                string activeSolution = xppDevHelper.GetActiveSolution();

                checkInComment = checkInComment.Replace("{status}", status);
                checkInComment = checkInComment.Replace("{project}", activeProject);
                checkInComment = checkInComment.Replace("{solution}", activeSolution);
                checkInComment = checkInComment.Replace("{developer}", developername);
                checkInComment = checkInComment.Replace("{date}", string.Format("{0} at: {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                checkInComment = checkInComment.Replace("{workitem}", UserPrivateSettings.Instance.WITNumber);
                checkInComment = checkInComment.Replace("{lb}", Environment.NewLine + "//");

            }
            catch (Exception ex)
            {
                Helpers.writeEventLog(ex.Message);
            }

 
            return checkInComment;
        } 
        public static void getStartAndEndTag(out string startTag, out string endTag)
        {
            startTag = Properties.Resources.notConfigured;
            endTag = Properties.Resources.notConfigured;

            try
            {
                string developername = string.Empty;
                RegistryHelpers.getDeveloperName(out developername);

                string keyName = "StartTag";
                startTag = RegistryHelpers.GetRegistryValue(keyStrings, keyName);
                keyName = "EndTag";
                endTag = RegistryHelpers.GetRegistryValue(keyStrings, keyName);

                string activeProject = xppDevHelper.GetActiveProject();
                startTag = startTag.Replace("{project}", activeProject);
                startTag = startTag.Replace("{developer}", developername);
                startTag = startTag.Replace("{date}", string.Format("{0} at: {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                startTag = startTag.Replace("{workitem}", UserPrivateSettings.Instance.WITNumber);

                startTag = startTag.Replace("{lb}", Environment.NewLine + "//");

                endTag = endTag.Replace("{project}", activeProject);
                endTag = endTag.Replace("{developer}", developername);
                endTag = endTag.Replace("{date}", string.Format("{0} at: {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                endTag = endTag.Replace("{workitem}", UserPrivateSettings.Instance.WITNumber);

                endTag = endTag.Replace("{lb}", Environment.NewLine + "//");
            }
            catch (Exception ex)
            {
                Helpers.writeEventLog(ex.Message);
            }
        }

        public static void getDeveloperName(out string developername)
        {
            string keyName = "DeveloperName";
            developername = RegistryHelpers.GetRegistryValue(keyStrings, keyName);
            if (string.IsNullOrEmpty(developername))
            {
                developername = Environment.UserName;
            }

        }
        public static void getHighlightWord(out bool highlight)
        {
            highlight = false;
            string keyName = "HighLightSelectedWord";
            string strHighlight = RegistryHelpers.GetRegistryValue(keyOptions, keyName);
            if (strHighlight == "True")
            {
                highlight = true;
            }
        }
        public static void getHighlightSelectedRow(out bool highlight)
        {
            highlight = false;
            string keyName = "HighLightSelectedRow";
            string strHighlight = RegistryHelpers.GetRegistryValue(keyOptions, keyName);
            if (strHighlight == "True")
            {
                highlight = true;
            }
        }
        public static void getHighlightColorWord(out Color backColor, out Color frameColor)
        {

            backColor = Color.LemonChiffon;
            frameColor = Color.Black;

            string keyName = "BackColorWord";
            string back = RegistryHelpers.GetRegistryValue(keyOptions, keyName);
            keyName = "FrameColorWord";
            string frame = RegistryHelpers.GetRegistryValue(keyOptions, keyName);


            back = Regex.Replace(back, @"[\""]", "", RegexOptions.None);
            frame = Regex.Replace(frame, @"[\""]", "", RegexOptions.None);

            if (!string.IsNullOrEmpty(back))
            {
                backColor = Color.FromName(back);
            }
            if(!string.IsNullOrEmpty(frame))
            {
                frameColor = Color.FromName(frame);
            }
        }

        public static void getHighlightColorRow(out System.Windows.Media.Color backColor)
        {
            Color color = Color.LightGreen;
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            backColor = newColor;


            string keyName = "BackColorRow";
            string back = RegistryHelpers.GetRegistryValue(keyOptions, keyName);
            if(!string.IsNullOrEmpty(back))
            {
                back = Regex.Replace(back, @"[\""]", "", RegexOptions.None);
                color = Color.FromName(back);
                System.Windows.Media.Color savedColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                backColor = savedColor;
            }
        }

        public static void getHighlightColorRow(out Color backColor)
        {
            backColor = Color.LightGreen;
            string keyName = "BackColorRow";
            string back = RegistryHelpers.GetRegistryValue(keyOptions, keyName);
            if (!string.IsNullOrEmpty(back))
            {
                back = Regex.Replace(back, @"[\""]", "", RegexOptions.None);
                Color savedColor = Color.FromName(back);
                backColor = savedColor;
            }
        }
        public static RegistryKey GetRegistryKey(string keyPath)
        {
            RegistryKey currentUserRegistry
                = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser,
                                          Environment.Is64BitOperatingSystem
                                              ? RegistryView.Registry64
                                              : RegistryView.Registry32);

            return string.IsNullOrEmpty(keyPath)
                ? currentUserRegistry
                : currentUserRegistry.OpenSubKey(keyPath);
        }

        public static string GetRegistryValue(string keyPath, string keyName)
        {
            string value = string.Empty;
            try
            {
                RegistryKey registry = GetRegistryKey(keyPath);
                if(registry != null)
                {
                    if (registry.GetValue(keyName) != null)
                    {
                        value = registry.GetValue(keyName).ToString();
                        value = value.Replace("1", string.Empty);
                        value = value.Replace("*System.String*", string.Empty);
                        value = value.Replace("*System.Boolean*", string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.writeEventLog(ex.Message);
            }
            return value;
        }
    }
    public static class Helpers
    {
        /// <summary>
        /// Get the VersionControlExt extensibility object.
        /// </summary>
        public static VersionControlExt GetVersionControlExt(IServiceProvider serviceProvider)
        {
            if (serviceProvider != null)
            {
                DTE2 dte = serviceProvider.GetService(typeof(SDTE)) as DTE2;
                if (dte != null)
                {
                    return dte.GetObject("Microsoft.VisualStudio.TeamFoundation.VersionControl.VersionControlExt") as VersionControlExt;
                }
            }

            return null;
        }

        public static void writeEventLog(string _message = "AX7 Plugin event",EventLogEntryType _type = EventLogEntryType.Information)
        {
            string source = Properties.Resources.xppDevEventLog;
            string logName = Properties.Resources.xppDevEventLogName;

            if(!EventLog.SourceExists(source))
            {
                if (!RunningAsAdmin())
                {
                    string message = string.Format("{0}{1}{2}", Properties.Resources.registerEventSource, Environment.NewLine, Properties.Resources.logMessage);
                    MessageBox.Show(message, Properties.Resources.xppDevEventLog, MessageBoxButton.OK);
                }
                else
                {
                    EventLog.CreateEventSource(source, logName);
                }

            }

            if (!RunningAsAdmin())
            {
                string message = string.Format("{0}{1}{2}", Properties.Resources.registerEventSource, Environment.NewLine, Properties.Resources.logMessage);
                MessageBox.Show(message, Properties.Resources.xppDevEventLog, MessageBoxButton.OK);
            }
            else
            {
                var eventlog = new EventLog();
                eventlog.Source = source;
                string outMessage = string.Format("{0}\n{1}", _message, Environment.StackTrace);
                eventlog.WriteEntry(outMessage, _type);
            }
        }

        public static bool RunningAsAdmin()
        {
            var Principle = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return Principle.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
