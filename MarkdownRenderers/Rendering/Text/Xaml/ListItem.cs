// // ListItem.cs
// /*
// Paul Schneider paul@pschneider.fr 03/06/2018 01:21 20182018 6 3
// */
using System;
using System.IO.MemoryMappedFiles;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    /// <summary>
    /// List item.
    /// </summary>
    public class ListItem : MdToXamlBlock
    {
        int ListLevel { get; set; }
        IMap _map;
        MdToXamlNode _innerNode; 

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MarkdownAVToXaml.Rendering.Text.Xaml.ListItem"/> class.
        /// </summary>
        /// <param name="inner">Inner.</param>
        /// <param name="map">Map.</param>
        public ListItem(MdToXamlNode inner, IMap map)
        {
            _map = map;
            _innerNode = inner;
        }

        /// <summary>
        /// Render this instance.
        /// </summary>
        /// <returns>The render.</returns>
        public override string Render()
        {
            string innerTxt = _innerNode.Render();
            var bullet = _map.GetBullet(ListLevel);
            var marginLeft = _map.TabSize - _map.BulletSize;
            return $"<StackLayout Maring=\"{marginLeft},0,0,0\"><ImageView Image=\"{bullet}\" Width=\"{_map.BulletSize}\">{innerTxt}</StackLayout>";

        }
    }
}
