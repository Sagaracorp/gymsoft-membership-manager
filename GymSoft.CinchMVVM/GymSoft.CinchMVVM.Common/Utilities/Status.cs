using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace GymSoft.CinchMVVM.Common.Utilities
{
    #region Status enum

    /// <summary>
    /// Status enumeration.
    /// </summary>
    public enum Status { Active, Expired, Inactive }

    #endregion

    #region StatusHelper Class

    /// <summary>
    /// Helper class for the Status enum.
    /// </summary>
    /// <remarks>
    /// This class provides a Dictionary object with friendly enum names
    /// to the IValueConverters that support the FontStyles enum.
    /// </remarks>
    internal static class StatusHelper
    {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        static StatusHelper()
        {
            // Create forward (enum-to friendly name) dictionary
            StatusFriendlyNames = new Dictionary<Status, string>
            {
                {Status.Active, "ACTIVE"},
                {Status.Expired, "EXPIRED"},
                {Status.Inactive, "INACTIVE"},
            };

            // Create reverse (friendly name-to-enum) dictionary
            StatusEnumValues = StatusFriendlyNames.ToDictionary(x => x.Value, x => x.Key);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns font style friendly name for enum value passed in.
        /// </summary>
        public static Dictionary<Status, String> StatusFriendlyNames { get; set; }

        /// <summary>
        /// Returns font style enum value for friendly name passed in.
        /// </summary>
        public static Dictionary<String, Status> StatusEnumValues { get; set; }

        #endregion
    }

    #endregion

    #region StatusListProvider

    public class StatusListProvider : IValueConverter
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

            var statusList = StatusHelper.StatusFriendlyNames.Values.ToList();
            return statusList;
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

    #region StatusValueConverter

    public class StatusValueConverter : IValueConverter
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
            var enumValue = (Status)value;
            var friendlyName = StatusHelper.StatusFriendlyNames[enumValue];
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
            var enumValue = StatusHelper.StatusEnumValues[friendlyName];
            return enumValue;
        }

        #endregion
    }

    #endregion
}
