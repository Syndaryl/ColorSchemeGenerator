using ColorHelper;
using ColorPicker.Models;
using Color = System.Windows.Media.Color;

namespace ColorScheme.GUI;

public static class Extensions
{
    
    public static HSV AdjustHsv( this HSV hsv, int h, int s, int v)
    {
        var tempH = hsv.H + h;
        var tempS = hsv.S + s;
        var tempL = hsv.V + v;
        
        while (tempH < 0) tempH += 360;
        while (tempH > 360) tempH -= 360;
        hsv.H = tempH;

        if (tempS < 1) tempS = 0;
        if (tempL < 0) tempL = 0;
        if (tempS > 100) tempS = 100;
        if (tempL > 100) tempL = 100;

        hsv.H = tempH;
        hsv.S = (byte)tempS;
        hsv.V = (byte)tempL;

        return hsv;
    }
    public static HSL AdjustHsl( this HSL hsl, int hueAdjust, int saturationAdjust, int luminanceSteps, double tintIncrement, double shadeIncrement)
    {
        var tempH = hsl.H + hueAdjust;
        var tempS = hsl.S + saturationAdjust;
        var luminanceAdjust = luminanceSteps * (luminanceSteps > 0? tintIncrement:shadeIncrement);
        var tempL = hsl.L + luminanceAdjust;


        
        while (tempH < 0) tempH += 360;
        while (tempH > 360) tempH -= 360;
        hsl.H = tempH;

        if (tempS < 1) tempS = 0;
        if (tempL < 0) tempL = 0;
        if (tempS > 100) tempS = 100;
        if (tempL > 100) tempL = 100;

        hsl.H = tempH;
        hsl.S = (byte)tempS;
        hsl.L = (byte)tempL;

        return hsl;
    }

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