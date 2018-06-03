using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public interface IMap
    {
        Dictionary<HeaderLevel, string> HeaderFonts { get; }

        string GetBullet(int headerLevel);

        int TabSize { get; set; } 

        int BulletSize { get; set; }

        int BaseTextSize { get; set; } 
    }
}