using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace MDGui
{
	public class SettingsForm : Dialog
	{
		Settings old;

		public SettingsForm (Settings target)
		{
			XamlReader.Load (this);
			this.DataContext = target;
			old = target.CreateBackup ();
			
			this.DefaultButton.Click += CloseButton_Click;
			this.AbortButton.Click += AbortButton_Click;
		}

		void CloseButton_Click (object sender, EventArgs e)
		{
			
			this.Close ();
		}

		void AbortButton_Click (object sender, EventArgs e)
		{
			((Settings)this.DataContext).Restore (old);
			this.Close ();
		}

	}
}

