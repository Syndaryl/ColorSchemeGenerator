using System.Windows.Media;
using System.Xml;
using KnownColor = System.Drawing.KnownColor;
using Color = System.Windows.Media.Color;
using ColorPicker.Models;

namespace ColorScheme.GUI;

public partial class DataModel
{
    public string Name { get; set; } = "example text";


    private Color _primary = new Color().FromKnownColor(KnownColor.Goldenrod);
    
    private readonly Scheme _scheme = new ();

    public Color Primary
    {
        get => _primary;
        set
        {
            _primary = value;
            if (_scheme.PrimaryColor != _primary) Update();
        }
    }
}