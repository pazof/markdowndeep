// // MyForm.xeto.cs
// /*
// Paul Schneider paul@pschneider.fr 04/06/2018 02:50 20182018 6 4
// */
using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace MDGui
{
    public class MyForm : Form
    {
        Drawable bullet;
        Label label;
        RichTextArea richText;
        public MyForm()
        {
            XamlReader.Load(this);

            ITextBuffer buffer = richText.Buffer;
            var range = new Range<int>(0,richText.CaretIndex);

            buffer.SetBackground(range,Colors.Beige);


        }
    }
}
