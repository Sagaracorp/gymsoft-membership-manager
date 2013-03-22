using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GymSoft.CinchMVVM.Common
{
    public static class GymSoftConfigurationManger
    {
        private static XDocument configFile = XDocument.Load("GymSoft.Configuration.xml");

        public static XDocument ConfigFile
        {
            get { return configFile; }
            set { configFile = value; }
        }

        public static string GetDatabaseConnection()
        {
            var connectionString = from conString in configFile.Descendants("connectionString")
                                   select conString.Value;
            return connectionString.First().ToString();
        }
    }
}
