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
    public class ListItem : MdToXamlBlock
    {
        int ListLevel { get; set; }
        IMap _map;
        XmlRenderer renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MarkdownAVToXaml.Rendering.Text.Xaml.ListItem"/> class.
        /// </summary>
        /// <param name="inner">Inner.</param>
        /// <param name="map">Map.</param>
        public ListItem(IEnumerable<IRenderer<string>> inner, IMap map)
        {
            _map = map;
            Spans = inner.ToArray();

            renderer = new XmlRenderer("StackLayout");
            renderer.Parameters["HorizontalContentAlignment"] = "Stretch";
        }

        /// <summary>
        /// Render this instance.
        /// </summary>
        /// <returns>The render.</returns>
        public override string Render()
        {
            StringBuilder innerTxtBuilder = new StringBuilder();
            foreach (var s in Spans)
                innerTxtBuilder.AppendLine(s.Render());
            
          // FIXME  var bullet = _map.GetBullet(ListLevel);
            var marginLeft = _map.TabSize - _map.BulletSize;
            renderer.Parameters["Padding"] = $"0,0,{marginLeft},0";
            return renderer.RenderRaw(innerTxtBuilder.ToString());
        }
    }
}
