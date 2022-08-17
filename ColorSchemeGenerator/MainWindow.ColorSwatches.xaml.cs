
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ColorHelper;
using converter = ColorHelper.ColorConverter;

namespace ColorScheme.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.ColorSwatches.xaml
    /// </summary>
    public partial class ColorSwatches : Page
    {

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            this.DataContext = ((App)Application.Current).Model;
            ((App)Application.Current).Model.Update();
        }
        private void Swatch_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.DataContext == null) return;
            if (sender is not Button { Content: Path { Fill: SolidColorBrush brush } }) return;
            ColorRgbToClipboard(brush);
        }

        private string ColorRgbToClipboard(SolidColorBrush brush)
        {
            var clipContent = $"[{brush.Color.R}, {brush.Color.G}, {brush.Color.B}]";
            Clipboard.SetText(clipContent);
            return clipContent;
        }

        private string ColorHslToClipboard(SolidColorBrush brush)
        {
            var rgb = new RGB(brush.Color.R, brush.Color.G, brush.Color.B);
            var tmp = converter.RgbToHsl(rgb);
            var clipContent = $"[{tmp.H}, {tmp.S}, {tmp.L}]";
            Clipboard.SetText(clipContent);
            return clipContent;
        }

        private string ColorHsvToClipboard(SolidColorBrush brush)
        {
            var rgb = new RGB(brush.Color.R, brush.Color.G, brush.Color.B);
            var tmp = converter.RgbToHsv(rgb);
            var clipContent = $"[{tmp.H}, {tmp.S}, {tmp.V}]";
            Clipboard.SetText(clipContent);
            return clipContent;
        }
    }
}
