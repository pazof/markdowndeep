// // MDImage.cs
// /*
// Paul Schneider paul@pschneider.fr 17/05/2018 18:12 20182018 5 17
// */
using System;

namespace MarkdownAVToXaml.Rendering.Text.Md
{
    public class MDImage : MDLink
    {
        public MDImage()
        {
        }
        string title;
        public override string Title
        {
            get
            {
                if (mimeCat == null) return title;
                return mimeCat + ':' + title;
            }
            set
            {
                var icat = value.IndexOf(':');
                MimeCat = icat >= 0 ? value.Substring(0, icat) : null;
                title = value.Substring(icat + 1);
            }
        }

        public string Alt { get; set; }

        string mimeCat;
        public string MimeCat { 
            get
            {
                return mimeCat;
            }
            set
            {
                mimeCat = value;
            }
        }

	}
}
