using ColorPicker.Models;
using Color = System.Windows.Media.Color;

namespace ColorScheme.GUI;

public static class Extensions
{

    public static Color FromKnownColor(this Color color, System.Drawing.KnownColor knownColor)
    {
        var drawingColor = System.Drawing.Color.FromKnownColor(knownColor);
        color = Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
        return color;
    }
    public static Color FromColorState(this Color color, ColorState colorState)
    {
        color = Color.FromArgb((byte)(colorState.A*255.0), (byte)(colorState.RGB_R*255.0), (byte)(colorState.RGB_G*255.0), (byte)(colorState.RGB_B*255.0));
        return color;
    }

    public static ColorState FromColor(this ColorState cs, Color color)
    {
        cs.SetARGB(color.A/255.0, color.R/255.0, color.G/255.0, color.B/255.0);

        return cs;
    }
    
    public static ColorState FromColor(this ColorState cs, System.Drawing.KnownColor knownColor)
    {
        var color = System.Drawing.Color.FromKnownColor(knownColor);

        cs.SetARGB(color.A/255.0, color.R/255.0, color.G/255.0, color.B/255.0);

        return cs;
    }
    
    public static ColorState FromColor(this ColorState cs, string colorName)
    {
        var color = System.Drawing.Color.FromName(colorName);

        cs.SetARGB(color.A/255.0, color.R/255.0, color.G/255.0, color.B/255.0);

        return cs;
    }
}