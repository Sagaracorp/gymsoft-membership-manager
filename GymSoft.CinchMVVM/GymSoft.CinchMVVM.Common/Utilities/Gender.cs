using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GymSoft.CinchMVVM.Common.Utilities
{
    #region Gender enum

    /// <summary>
    /// Gender enumeration.
    /// </summary>
    public enum Gender { Male, Female }

    #endregion

    #region GenderHelper Class

    /// <summary>
    /// Helper class for the FontStylkes enum.
    /// </summary>
    /// <remarks>
    /// This class provides a Dictionary object with friendly enum names
    /// to the IValueConverters that support the FontStyles enum.
    /// </remarks>
    internal static class GenderHelper
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        static GenderHelper()
        {
            // Create forward (enum-to friendly name) dictionary
            GenderFriendlyNames = new Dictionary<Gender, string>
            {
                {Gender.Male, "MALE"},
                {Gender.Female, "FEMALE"},
            };

            // Create reverse (friendly name-to-enum) dictionary
            GenderEnumValues = GenderFriendlyNames.ToDictionary(x => x.Value, x => x.Key);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns font style friendly name for enum value passed in.
        /// </summary>
        public static Dictionary<Gender, String> GenderFriendlyNames { get; set; }

        /// <summary>
        /// Returns font style enum value for friendly name passed in.
        /// </summary>
        public static Dictionary<String, Gender> GenderEnumValues { get; set; }

        #endregion
    }

    #endregion

    #region GenderListProvider

    public class GenderListProvider : IValueConverter
    {
        #region Implementation of IValueConverter

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /* Note that this converter does not convert a value passed in. Instead, it generates 
                * a list of user-friendly counterparts for each menber of the target enum and
                * returns that list to the caller. */

            var genderList = GenderHelper.GenderFriendlyNames.Values.ToList();
            return genderList;
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion

    #region GenderValueConverter

    public class GenderValueConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = (Gender)value;
            var friendlyName = GenderHelper.GenderFriendlyNames[enumValue];
            return friendlyName;
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var friendlyName = (String)value;
            var enumValue = GenderHelper.GenderEnumValues[friendlyName];
            return enumValue;
        }

        #endregion
    }

    #endregion
}
