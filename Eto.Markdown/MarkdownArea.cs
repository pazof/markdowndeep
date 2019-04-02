// // MyClass.cs
// /*
// Paul Schneider paul@pschneider.fr 03/06/2018 03:50 20182018 6 3
// */
using System;
using Eto.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Eto.Forms;
using Portable.Xaml;

namespace Eto.Markdown
{

    /// <summary>
    /// Text area with ability to specify rich text formatting such as font attributes and colors.
    /// </summary>
    [Handler(typeof(IMarkdownArea))]
    public class MarkdownArea : TextArea
    {
        public MarkdownArea() 
        {

        }

        /// <summary>
        /// Gets or sets the font of the selected text or insertion point.
        /// </summary>
        /// <value>The font of the selection.</value>
        public Font SelectionFont
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the foreground color of the selected text or insertion point.
        /// </summary>
        /// <value>The foreground color of the selection.</value>
        public Color SelectionForeground
        {

            get;
            set;
        }

        /// <summary>
        /// Gets or sets the background color of the selected text or insertion point.
        /// </summary>
        /// <value>The background color of the selection.</value>
        public Color SelectionBackground
        {

            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has bold text.
        /// </summary>
        /// <value><c>true</c> if selected text is bold; otherwise, <c>false</c>.</value>
        public bool SelectionBold
        {

            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has italic style.
        /// </summary>
        /// <value><c>true</c> if selected text is italic; otherwise, <c>false</c>.</value>
        public bool SelectionItalic
        {

            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has underline decorations.
        /// </summary>
        /// <value><c>true</c> if selected text is underline; otherwise, <c>false</c>.</value>
        public bool SelectionUnderline
        {

            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has strikethrough decorations.
        /// </summary>
        /// <value><c>true</c> if selected text is strikethrough; otherwise, <c>false</c>.</value>
        public bool SelectionStrikethrough
        {

            get;
            set;
        }

        /// <summary>
        /// Gets or sets the font family of the selected text or insertion point.
        /// </summary>
        /// <value>The font family of the selected text.</value>
        public FontFamily SelectionFamily
        {

            get;
            set;
        }

        /// <summary>
        /// Gets or sets the font typeface of the selected text or insertion point.
        /// </summary>
        /// <value>The font typeface of the selected text.</value>
        public FontTypeface SelectionTypeface
        {

            get;
            set;
        }

        /// <summary>
        /// Gets the formatted text buffer to set formatting and load/save to file.
        /// </summary>
        /// <remarks>
        /// The text buffer allows you to control the formatting of the text.
        /// </remarks>
        /// <value>The text buffer.</value>
        public ITextBuffer Buffer
        {
            get; set;
        }


        public string Markdown
        {
            get { return Buffer.GetMarkdown(); }
            set { Buffer.SetMarkdown(value); }
        }
        new IMarkdownArea Handler { get { return (IMarkdownArea)base.Handler; } }
        public interface IMarkdownArea : Control.IHandler
        {
            string Markdown { get; set; }
            ITextBuffer Buffer
            {
                get; 
            }
        }
    }

}