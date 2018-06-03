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
            HeaderFonts = new Dictionary<HeaderLevel, string>();
            int hsize = BaseTextSize;
            for (HeaderLevel level = HeaderLevel.Max; level >= 0; level--)
            {
                HeaderFonts.Add(level, $"{FirstFontName}+{SecondFontName}+{hsize}pt");
                hsize += 2;
            }
        }
        public string FirstFontName { get; set; } = "Serif" ;
        public string SecondFontName { get; set; } = "Regular";

        public Dictionary<HeaderLevel, string> HeaderFonts { get; }

        public string GetBullet(int headerLevel)
        {
            return "bullet"+headerLevel.ToString();
        }

        public int TabSize { get; set; } 

        public int BulletSize { get; set; }

        public int BaseTextSize { get; set; } 
    }
}
