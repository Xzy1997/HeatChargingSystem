﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.utils
{
    public class AppConfigUtils
    {
        private static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {

                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {

                    }
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }


        public static string ReadSetting(string key)
        {
            try
            {
                var appsettings = ConfigurationManager.AppSettings;
                return appsettings[key] ?? string.Empty;
            }
            catch (ConfigurationErrorsException)
            {
                return string.Empty;
            }
        }

        public static void AddUpateAppSettings(string key, string value)
        {
            try
            {
                string file = System.Environment.CurrentDirectory; //System.Windows.Forms.Application.ExecutablePath;
                //var configFile = ConfigurationManager.OpenExeConfiguration(file);
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
        }

    }
}
