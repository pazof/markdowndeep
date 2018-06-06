// // IBlockList.cs
// /*
// Paul Schneider paul@pschneider.fr 04/06/2018 10:30 20182018 6 4
// */
using System;
using System.Collections.Generic;
using MarkdownDeep.Rendering.Abstract;

namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    public interface IBlockList
    {
         List<IRenderer<string>> Blocks { get; }
    }
}
