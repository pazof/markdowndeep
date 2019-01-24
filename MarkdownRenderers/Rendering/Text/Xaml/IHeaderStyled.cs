// // IHeaderStyleOwner.cs
// /*
// Paul Schneider paul@pschneider.fr 04/06/2018 09:35 20182018 6 4
// */
using System;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public interface IHeaderStyled
    {
        HeaderLevel Level { get; set; }
    }
}
