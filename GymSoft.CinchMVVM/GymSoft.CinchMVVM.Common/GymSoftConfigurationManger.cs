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
        public static Uri GetUserDefaultPictureDirectory()
        {
            var userDefaultPictureDirectory = from userImages in configFile.Descendants("user_images")
                                              let xElement = userImages.Element("default_directory")
                                              where xElement != null
                                              select xElement.Value;
            return new Uri(userDefaultPictureDirectory.First().ToString(), UriKind.RelativeOrAbsolute);
        }
        public static Uri GetDefaultUserPicture()
        {
            var userDefaultPicture = from userImages in configFile.Descendants("user_images")
                                     let xElement = userImages.Element("default_picture")
                                     where xElement != null
                                     select xElement.Value;
          
            return new Uri(userDefaultPicture.First(), UriKind.Relative);
        }
        public static string GetUserPicturesAssemblyRoot()
        {
            var userPicturesAssemblyRoot = from userImages in configFile.Descendants("user_images")
                                     let xElement = userImages.Element("default_assembly_root")
                                     where xElement != null
                                     select xElement.Value;
            return userPicturesAssemblyRoot.First().ToString();
        }
    }
}
