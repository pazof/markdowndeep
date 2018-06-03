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
    [Handler(typeof(IHandler))]
    public class MarkdownArea : TextArea
    {
        new IHandler Handler { get { return (IHandler) base.Handler; } }
        void test () 
        {
        }
        /// <summary>
        /// Gets or sets the font of the selected text or insertion point.
        /// </summary>
        /// <value>The font of the selection.</value>
        public Font SelectionFont
        {
            get { return Handler.SelectionFont; }
            set { Handler.SelectionFont = value; }
        }

        /// <summary>
        /// Gets or sets the foreground color of the selected text or insertion point.
        /// </summary>
        /// <value>The foreground color of the selection.</value>
        public Color SelectionForeground
        {
            get { return Handler.SelectionForeground; }
            set { Handler.SelectionForeground = value; }
        }

        /// <summary>
        /// Gets or sets the background color of the selected text or insertion point.
        /// </summary>
        /// <value>The background color of the selection.</value>
        public Color SelectionBackground
        {
            get { return Handler.SelectionBackground; }
            set { Handler.SelectionBackground = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has bold text.
        /// </summary>
        /// <value><c>true</c> if selected text is bold; otherwise, <c>false</c>.</value>
        public bool SelectionBold
        {
            get { return Handler.SelectionBold; }
            set { Handler.SelectionBold = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has italic style.
        /// </summary>
        /// <value><c>true</c> if selected text is italic; otherwise, <c>false</c>.</value>
        public bool SelectionItalic
        {
            get { return Handler.SelectionItalic; }
            set { Handler.SelectionItalic = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has underline decorations.
        /// </summary>
        /// <value><c>true</c> if selected text is underline; otherwise, <c>false</c>.</value>
        public bool SelectionUnderline
        {
            get { return Handler.SelectionUnderline; }
            set { Handler.SelectionUnderline = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the selected text or insertion point has strikethrough decorations.
        /// </summary>
        /// <value><c>true</c> if selected text is strikethrough; otherwise, <c>false</c>.</value>
        public bool SelectionStrikethrough
        {
            get { return Handler.SelectionStrikethrough; }
            set { Handler.SelectionStrikethrough = value; }
        }

        /// <summary>
        /// Gets or sets the font family of the selected text or insertion point.
        /// </summary>
        /// <value>The font family of the selected text.</value>
        public FontFamily SelectionFamily
        {
            get { return Handler.SelectionFamily; }
            set { Handler.SelectionFamily = value; }
        }

        /// <summary>
        /// Gets or sets the font typeface of the selected text or insertion point.
        /// </summary>
        /// <value>The font typeface of the selected text.</value>
        public FontTypeface SelectionTypeface
        {
            get { return Handler.SelectionTypeface; }
            set { Handler.SelectionTypeface = value; }
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
            get { return Handler.Buffer; }
        }


        public string Markdown
        {
            get { return Buffer.GetMarkdown(); }
            set { Buffer.SetMarkdown(value); }
        }

        /// <summary>
        /// Handler interface for the <see cref="RichTextArea"/>.
        /// </summary>
        public new interface IHandler : TextArea.IHandler
        {
            /// <summary>
            /// Gets or sets a value indicating whether the selected text or insertion point has bold text.
            /// </summary>
            /// <value><c>true</c> if selected text is bold; otherwise, <c>false</c>.</value>
            bool SelectionBold { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the selected text or insertion point has italic style.
            /// </summary>
            /// <value><c>true</c> if selected text is italic; otherwise, <c>false</c>.</value>
            bool SelectionItalic { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the selected text or insertion point has underline decorations.
            /// </summary>
            /// <value><c>true</c> if selected text is underline; otherwise, <c>false</c>.</value>
            bool SelectionUnderline { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the selected text or insertion point has strikethrough decorations.
            /// </summary>
            /// <value><c>true</c> if selected text is strikethrough; otherwise, <c>false</c>.</value>
            bool SelectionStrikethrough { get; set; }

            /// <summary>
            /// Gets or sets the font of the selected text or insertion point.
            /// </summary>
            /// <value>The font of the selection.</value>
            Font SelectionFont { get; set; }

            /// <summary>
            /// Gets or sets the foreground color of the selected text or insertion point.
            /// </summary>
            /// <value>The foreground color of the selection.</value>
            Color SelectionForeground { get; set; }

            /// <summary>
            /// Gets or sets the background color of the selected text or insertion point.
            /// </summary>
            /// <value>The background color of the selection.</value>
            Color SelectionBackground { get; set; }

            /// <summary>
            /// Gets the formatted text buffer to set formatting and load/save to file.
            /// </summary>
            /// <remarks>
            /// The text buffer allows you to control the formatting of the text.
            /// </remarks>
            /// <value>The text buffer.</value>
            ITextBuffer Buffer { get; }

            /// <summary>
            /// Gets or sets the font family of the selected text or insertion point.
            /// </summary>
            /// <value>The font family of the selected text.</value>
            FontFamily SelectionFamily { get; set; }

            /// <summary>
            /// Gets or sets the font typeface of the selected text or insertion point.
            /// </summary>
            /// <value>The font typeface of the selected text.</value>
            FontTypeface SelectionTypeface { get; set; }
        }
    }
}