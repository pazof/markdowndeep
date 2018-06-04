// // Maps.cs
// /*
// Paul Schneider paul@pschneider.fr 02/06/2018 04:12 20182018 6 2
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;
using System.Text;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class DefaultMap : IMap
    {
        public DefaultMap()
        {
            BulletSize = BaseTextSize = 10;
            TabSize = 16;
            HeaderFont = new Dictionary<HeaderLevel, string>();
            int hsize = BaseTextSize;
            for (HeaderLevel level = HeaderLevel.Max; level >= 0; level--)
            {
                HeaderFont.Add(level, $"{FirstFontName}+{SecondFontName}+{hsize}pt");
                hsize += 2;
            }

            TextFont = new Dictionary<TextStyle, string>();
            TextFont.Add(TextStyle.Emphasys, "bold");
            TextFont.Add(TextStyle.Underline, "underline");
            TextFont.Add(TextStyle.Italic, "italic");
            TextFont.Add(TextStyle.Strike, "strikethrough");
        }
        public string FirstFontName { get; set; } = "Serif" ;
        public string SecondFontName { get; set; } = "Regular";

        public Dictionary<HeaderLevel, string> HeaderFont { get; }

        public string GetBullet(int headerLevel)
        {
            return "bullet"+headerLevel.ToString()+".png";
        }

        public int TabSize { get; set; } 

        public int BulletSize { get; set; }

        public int BaseTextSize { get; set; }

        public Dictionary<TextStyle, string> TextFont { get; set; }
    }
}
