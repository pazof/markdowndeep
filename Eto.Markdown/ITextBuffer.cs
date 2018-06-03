// // ITextBuffer.cs
// /*
// Paul Schneider paul@pschneider.fr 03/06/2018 10:44 20182018 6 3
// */
using System;
using System.Collections.Generic;
using System.IO;
using Eto.Drawing;
using Eto.Forms;

namespace Eto.Markdown
{
    public interface ITextBuffer
    {
        //
        // Properties
        //
        IEnumerable<int> SupportedFormats
        {
            get;
        }

        //
        // Methods
        //
        void Clear();

        void Delete(Range<int> range);

        void Insert(int position, string text);

        void Load(Stream stream, int format);

        void Save(Stream stream, int format);

        void SetBackground(Range<int> range, Color color);

        void SetBold(Range<int> range, bool bold);

        void SetFamily(Range<int> range, FontFamily family);

        void SetFont(Range<int> range, Font font);

        void SetForeground(Range<int> range, Color color);

        void SetItalic(Range<int> range, bool italic);

        void SetStrikethrough(Range<int> range, bool strikethrough);

        void SetUnderline(Range<int> range, bool underline);
    }
}
