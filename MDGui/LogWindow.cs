using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace MDGui
{
	public class LogWindow : Dialog
	{
		public LogWindow ()
		{
			Title = "My LogWindow dialog";
			// buttons
			DefaultButton = new Button { Text = "OK" };

			DefaultButton.Click += (sender, e) => Close ();

			var buttons = new StackLayout {
				Orientation = Orientation.Horizontal,
				Spacing = 5,
				Items = { DefaultButton }
			};

			Content = new StackLayout {
				Items = {
					new LogMessagesDialog(),
					new StackLayoutItem (buttons, HorizontalAlignment.Right)
				}
			};
		}
	}
}

