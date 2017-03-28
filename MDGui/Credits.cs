using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;

namespace MDGui
{
	public class Credits : Dialog
	{
		public Credits ()
		{
			Title = "My Credits dialog";

			// buttons
			DefaultButton = new Button { Text = "OK" };

			AbortButton = new Button { Text = "C&ancel" };
			AbortButton.Click += (sender, e) => Close ();

			var buttons = new StackLayout {
				Orientation = Orientation.Horizontal,
				Spacing = 5,
				Items = { DefaultButton, AbortButton }
			};

			Content = new StackLayout {
				Items = {
					new Label { Text = "Some content" },
					new StackLayoutItem (buttons, HorizontalAlignment.Right)
				}
			};
		}
	}
}

