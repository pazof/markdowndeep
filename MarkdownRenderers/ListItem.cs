// // ListItem.cs
// /*
// Paul Schneider paul@pschneider.fr 03/06/2018 01:21 20182018 6 3
// */
using System;
using System.IO.MemoryMappedFiles;
using MarkdownDeep.Rendering.Abstract;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    /// <summary>
    /// List item.
    /// </summary>
    public class ListItem<S> : MdToXamlBlock<S>
        where S : ISpan
    {
        int ListLevel { get; set; }
        IMap _map;
        private string[] Spans;
        XmlRenderer renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MarkdownAVToXaml.Rendering.Text.Xaml.ListItem"/> class.
        /// </summary>
        /// <param name="inner">Inner.</param>
        /// <param name="map">Map.</param>
        public ListItem(IEnumerable<string> inner, IMap map)
        {
            _map = map;
            Spans = inner.ToArray();
            renderer = new XmlRenderer("StackLayout",null);
            renderer.Parameters["Orientation"] = "Horizontal";
            renderer.Parameters["HorizontalContentAlignment"] = "Stretch";
        }

        /// <summary>
        /// Render this instance.
        /// </summary>
        /// <returns>a Xaml chunk</returns>
        public override string GetRenderer()
        {
            StringBuilder innerTxtBuilder = new StringBuilder($"<ImageView Image=\"{_map.GetBullet(ListLevel)}\" />");


            foreach (var s in Spans)
                 innerTxtBuilder.AppendLine(s);

                var marginLeft = _map.TabSize - _map.BulletSize;
            renderer.Parameters["Padding"] = $"{marginLeft},0,0,0";
            return renderer.Render( innerTxtBuilder.ToString());
        }
    }
}
