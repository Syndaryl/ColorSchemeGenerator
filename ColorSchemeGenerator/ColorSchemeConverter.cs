using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using ColorPicker.Models;

namespace ColorScheme.GUI;

public class ColorSchemeConverter : IValueConverter
{
    #region Implementation of IValueConverter

    /// <summary>Converts a value.</summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            Color color when targetType == typeof(Color) => color,
            Color color when targetType == typeof(ColorState) => new ColorState().FromColor(color),
            Color color when targetType == typeof(System.Drawing.Color) => System.Drawing.Color.FromArgb(0,
                (int)color.R, (int)color.G, (int)color.B),
            ColorState state when targetType == typeof(ColorState) => state,
            ColorState state when targetType == typeof(Color) => new Color().FromColorState(state),
            ColorState state when targetType == typeof(System.Drawing.Color) => System.Drawing.Color.FromArgb(0,
                (int)(state.RGB_R * 255.0), (int)(state.RGB_G * 255.0), (int)(state.RGB_B * 255.0)),
            _ => Color.FromRgb(0, 0, 0)
        };
    }

    /// <summary>Converts a value.</summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            Color color when targetType == typeof(Color) => color,
            Color color when targetType == typeof(ColorState) => new ColorState().FromColor(color),
            Color color when targetType == typeof(System.Drawing.Color) => System.Drawing.Color.FromArgb(0,
                (int)color.R, (int)color.G, (int)color.B),
            ColorState state when targetType == typeof(ColorState) => state,
            ColorState state when targetType == typeof(Color) => new Color().FromColorState(state),
            ColorState state when targetType == typeof(System.Drawing.Color) => System.Drawing.Color.FromArgb(0,
                (int)(state.RGB_R * 255.0), (int)(state.RGB_G * 255.0), (int)(state.RGB_B * 255.0)),
            _ => Color.FromRgb(0, 0, 0)
        };
    }

    #endregion
}