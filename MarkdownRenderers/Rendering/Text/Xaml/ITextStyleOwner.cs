using MarkdownDeep.Rendering.Abstract;
namespace MarkdownAVToXaml.Rendering.Text.Xaml
{
    internal interface ITextStyleOwner
    {
        TextStyle Style { get; set; }
    }
}