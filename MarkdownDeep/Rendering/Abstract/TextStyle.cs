// // TextStyles.cs
// /*
// Paul Schneider paul@pschneider.fr 06/05/2018 02:44 20182018 5 6
// */
using System;
namespace MarkdownDeep.Rendering.Abstract
{
    /// <summary>
    /// Text style.
    /// </summary>
    [Flags][Serializable]
    public enum TextStyle: int
    {
        Normal=0,     // normal body text style
        Emphasys=1,   // **emphasys**
        Underline=2,  // _underline_ 
        Italic=4,     // *italic*
        Strike=8,     // ~~strike~~
        Fixed=16  // `code`
    }
}
