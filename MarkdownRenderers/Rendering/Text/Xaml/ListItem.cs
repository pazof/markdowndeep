// // ListItem.cs
// /*
// Paul Schneider paul@pschneider.fr 03/06/2018 01:21 20182018 6 3
// */
using System;
using System.IO.MemoryMappedFiles;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    /// <summary>
    /// List item.
    /// </summary>
    public class ListItem : MdToXamlBlock
    {
        int ListLevel { get; set; }
        IMap _map;
        IRenderer<string> _innerNode;
        XmlRenderer renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MarkdownAVToXaml.Rendering.Text.Xaml.ListItem"/> class.
        /// </summary>
        /// <param name="inner">Inner.</param>
        /// <param name="map">Map.</param>
        public ListItem(IRenderer<string> inner, IMap map)
        {
            _map = map;
            _innerNode = inner;
            renderer = new XmlRenderer("StackLayout");
        }

        /// <summary>
        /// Render this instance.
        /// </summary>
        /// <returns>The render.</returns>
        public override string Render()
        {
            string innerTxt = _innerNode.Render();
          // FIXME  var bullet = _map.GetBullet(ListLevel);
            var marginLeft = _map.TabSize - _map.BulletSize;
            renderer.Parameters["Padding"] = $"{marginLeft},0,0,0";
            return renderer.Render(innerTxt);
        }
    }
}
