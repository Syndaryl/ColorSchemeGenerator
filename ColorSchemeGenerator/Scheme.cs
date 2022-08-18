using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Windows.Media.Color;
using ColorHelper;

namespace ColorScheme.GUI
{
    
    public class Scheme
    {
        public Scheme(Color primary)
        {
            PrimaryColor = primary;
        }
        
        public Scheme()
        {
            PrimaryColor = new Color();
        }

        public Color PrimaryColor;

        public Color Harmonize(ColorHarmony harmony, int degrees = 0, int tintLevel=0, int tintDivisions = 0)
        {
            if (!Enum.IsDefined(typeof(ColorHarmony), harmony))
                throw new InvalidEnumArgumentException(nameof(harmony), (int)harmony, typeof(ColorHarmony));
            if (degrees is < -180 or > 180) throw new ArgumentOutOfRangeException(nameof(degrees));
            
            PrimaryColor.A = 255;
            var color = PrimaryColor;
            var hsl = ColorConverter.RgbToHsl(new RGB(PrimaryColor.R, PrimaryColor.G, PrimaryColor.B)) ?? throw new NullReferenceException("ColorConverter.RgbToHsv(new RGB(color.R, color.G, color.B))");
            
            var lt = ((100.0 - hsl.L)/(tintDivisions > 0? tintDivisions: 1.0));
            var ls = (hsl.L / (tintDivisions > 0? tintDivisions: 1.0));

            switch (harmony)
            {
                case ColorHarmony.Primary:
                    hsl.AdjustHsl(0, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Gray:
                    hsl.S = 1;
                    hsl.AdjustHsl(0, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Complementary:
                    hsl.AdjustHsl(180, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Analogous1:
                    hsl.AdjustHsl(0 - degrees, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Analogous2:
                    hsl.AdjustHsl(degrees, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Triadic1:
                    hsl.AdjustHsl(-60, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Triadic2:
                    hsl.AdjustHsl(60, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Compound1:
                    hsl.AdjustHsl(180 - degrees, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Compound2:
                    hsl.AdjustHsl(180 + degrees, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Square1:
                    hsl.AdjustHsl(-90, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Square2:
                    hsl.AdjustHsl(180, 0, tintLevel, lt, ls);
                    break;
                case ColorHarmony.Square3:
                    hsl.AdjustHsl(90, 0, tintLevel, lt, ls);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(harmony), harmony, null);
            }
            var rgb = ColorConverter.HslToRgb(hsl) ?? new RGB(127,127,127);
            color.R = rgb.R;
            color.G = rgb.G;
            color.B = rgb.B;
            color.A = 255;

            return color;
        }
        
    }
}
