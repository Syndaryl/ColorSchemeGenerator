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

        public Color Harmonize(ColorHarmony harmony, int degrees = 0, int shade = 0)
        {
            if (!Enum.IsDefined(typeof(ColorHarmony), harmony))
                throw new InvalidEnumArgumentException(nameof(harmony), (int)harmony, typeof(ColorHarmony));
            if (degrees is < -180 or > 180) throw new ArgumentOutOfRangeException(nameof(degrees));

            var color = PrimaryColor;
            var hsl = ColorConverter.RgbToHsl(new RGB(PrimaryColor.R, PrimaryColor.G, PrimaryColor.B)) ?? throw new NullReferenceException("ColorConverter.RgbToHsv(new RGB(color.R, color.G, color.B))");
            
            byte lt = (byte)((100 - hsl.L)/(shade > 0? shade: 1));
            byte ls = (byte)(hsl.L / (shade > 0? shade: 1));

            switch (harmony)
            {
                case ColorHarmony.Primary:
                    PrimaryColor.A = 255;
                    return PrimaryColor;
                case ColorHarmony.Analogous1:
                    hsl.H -= degrees;
                    hsl.L -= (byte)(lt*2);
                    break;
                case ColorHarmony.Analogous2:
                    hsl.H -= degrees;
                    break;
                case ColorHarmony.Analogous3:
                    hsl.H -= degrees;
                    hsl.L += (byte)(lt*2);
                    break;
                case ColorHarmony.Analogous4:
                    hsl.L += (byte)(lt*2);
                    hsl.H += degrees;
                    break;
                case ColorHarmony.Analogous5:
                    hsl.H += degrees;
                    break;
                case ColorHarmony.Analogous6:
                    hsl.L -= (byte)(lt*2);
                    hsl.H += degrees;
                    break;
                case ColorHarmony.Complementary1:
                    hsl.H += 180;
                    hsl.L += (byte)(lt*3);
                    break;
                case ColorHarmony.Complementary2:
                    hsl.H += 180;
                    hsl.L += (byte)(lt*2);
                    break;
                case ColorHarmony.Complementary3:
                    hsl.H += 180;
                    hsl.L += (byte)(lt*1);
                    break;
                case ColorHarmony.Complementary4:
                    hsl.H += 180;
                    break;
                case ColorHarmony.Complementary5:
                    hsl.H += 180;
                    hsl.L -= (byte)(ls*1);
                    break;
                case ColorHarmony.Complementary6:
                    hsl.H += 180;
                    hsl.L -= (byte)(ls*2);
                    break;
                case ColorHarmony.Complementary7:
                    hsl.H += 180;
                    hsl.L -= (byte)(ls*3);
                    break;
                case ColorHarmony.Triadic1:
                    hsl.H += 180 - degrees;
                    hsl.L -= (byte)(ls*2);
                    break;
                case ColorHarmony.Triadic2:
                    hsl.H += 180 - degrees;
                    break;
                case ColorHarmony.Triadic3:
                    hsl.H += 180 - degrees;
                    hsl.L += (byte)(ls*2);
                    break;
                case ColorHarmony.Triadic4:
                    hsl.H += 180 + degrees;
                    hsl.L += (byte)(ls*2);
                    break;
                case ColorHarmony.Triadic5:
                    hsl.H += 180 + degrees;
                    break;
                case ColorHarmony.Triadic6:
                    hsl.H += 180 + degrees;
                    hsl.L -= (byte)(ls*2);
                    break;
                case ColorHarmony.Compound1:
                    hsl.H -= 60;
                    hsl.L -= (byte)(ls*2);
                    break;
                case ColorHarmony.Compound2:
                    hsl.H -= 60;
                    break;
                case ColorHarmony.Compound3:
                    hsl.H -= 60;
                    hsl.L += (byte)(ls*2);
                    break;
                case ColorHarmony.Compound4:
                    hsl.H += 60;
                    hsl.L += (byte)(ls*2);
                    break;
                case ColorHarmony.Compound5:
                    hsl.H += 60;
                    break;
                case ColorHarmony.Compound6:
                    hsl.H += 60;
                    hsl.L -= (byte)(ls*2);
                    break;
                case ColorHarmony.Square1:
                    hsl.H -= 45;
                    break;
                case ColorHarmony.Square2:
                    hsl.H += 180;
                    break;
                case ColorHarmony.Square3:
                    hsl.H += 45;
                    break;
                case ColorHarmony.Tint1:
                    hsl.L += lt;
                    break;
                case ColorHarmony.Tint2:
                    hsl.L += (byte)(lt*2);
                    break;
                case ColorHarmony.Tint3:
                    hsl.L += (byte)(lt*3);
                    break;
                case ColorHarmony.Shade1:
                    hsl.L -= ls;
                    break;
                case ColorHarmony.Shade2:
                    hsl.L -= (byte)(ls*2);
                    break;
                case ColorHarmony.Shade3:
                    hsl.L -= (byte)(ls*3);
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
