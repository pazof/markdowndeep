// // Header.cs
// /*
// Paul Schneider paul@pschneider.fr 03/06/2018 00:28 20182018 6 3
// */
using System;
using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public class XamlHeader : MdToXamlBlock
    {
        IMap _map;
        MdToXamlBlock _inner;
        XmlRenderer _renderer;

        HeaderLevel Level { get; set; }

        public XamlHeader(MdToXamlBlock inner, HeaderLevel level, IMap map)
        {
            _map = map;
            _inner = inner;
            _renderer = new XmlRenderer("Label");
        }

        public override string Render()
        {
            _renderer.Parameters["Font"]= _map.HeaderFonts[Level];
            return _renderer.Render();
        }
    }
}
