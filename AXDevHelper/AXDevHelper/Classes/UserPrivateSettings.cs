using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using static AXDevHelper.Classes.GetSettings;

namespace AXDevHelper.Classes
{
    public sealed class UserPrivateSettings
    {
        private static readonly UserPrivateSettings instance = new UserPrivateSettings();
        private string witnumber;

        static UserPrivateSettings() { }
        private UserPrivateSettings() { }
        private void SaveSelectedWorkItem()
        {
            string settingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "xppDev");
            if (!Directory.Exists(settingsPath))
            {
                Directory.CreateDirectory(settingsPath);
            }

            GetSettings settings = new GetSettings();
            settings.CurrentWIT = witnumber;

            string fileAndPath = settingsPath + "\\xppDevHelper.set";
            if (File.Exists(fileAndPath))
            {
                using (FileStream fileStream = new FileStream(fileAndPath, FileMode.Open, FileAccess.Write))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(GetSettings));
                    formatter.Serialize(fileStream, settings);
                    fileStream.Close();
                    witnumber = settings.CurrentWIT;

                }
            }
            else
            {
                using (FileStream fileStream = File.OpenWrite(fileAndPath))
                {
                    try
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(GetSettings));
                        formatter.Serialize(fileStream, settings);
                        fileStream.Close();
                        witnumber = settings.CurrentWIT;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        
                    }
                }
            }
        }
        private void ReadSelectedWorkItem()
        {
            string settingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Properties.Resources.Settingfolder);

            if (string.IsNullOrEmpty(witnumber))
            {
                witnumber = Properties.Resources.NoWIT;
            }

            try
            {
                if (Directory.Exists(settingsPath))
                {
                    string fileAndPath = settingsPath + Properties.Resources.Settingsfile;
                    if (File.Exists(fileAndPath))
                    {
                        using (FileStream file = new FileStream(fileAndPath, FileMode.Open, FileAccess.Read))
                        {
                            if (file != null)
                            {
                                XmlSerializer formatter = new XmlSerializer(typeof(GetSettings));
                                GetSettings settings = formatter.Deserialize(file) as GetSettings;
                                file.Close();
                                if (settings != null)
                                {
                                    witnumber = settings.CurrentWIT;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.writeEventLog(ex.Message);
            }
        }
        private void createConstants(List<FormatKeyWord> keywords)
        {
            FormatKeyWord keyword = new FormatKeyWord("{workitem}", "Work Item Id");
            keywords.Add(keyword);

            keyword = new FormatKeyWord("{project}", "Active project");
            keywords.Add(keyword);

            keyword = new FormatKeyWord("{status}", "Check in status");
            keywords.Add(keyword);

            keyword = new FormatKeyWord("{developer}", "Developer name");
            keywords.Add(keyword);

            keyword = new FormatKeyWord("{date}", "Current date and time");
            keywords.Add(keyword);

            keyword = new FormatKeyWord("{lb}", "Line break");
            keywords.Add(keyword);
        }

        public static UserPrivateSettings Instance
        {
            get
            {
                return instance;
            }
        }
        public string WITNumber
        {
            get
            {
               instance.ReadSelectedWorkItem();
               return witnumber;
            }
            set
            {
                witnumber = value;
                instance.SaveSelectedWorkItem();
            }
        }
    }
}
