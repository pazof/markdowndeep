using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace MDGui
{
	public partial class LogMessagesDialog : Form, IObserver<Message>
	{
		DynamicLayout rows;

		protected override void OnClosing (System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true; // FIXME frankly why?
			this.Visible = false;
		}

		public LogMessagesDialog ()
		{
			XamlReader.Load (this);
			Log.Messages.Subscribe (this);
		}

		public void OnNext(Message value)
		{
			this.SuspendLayout ();
			rows.SuspendLayout ();
			rows.AddRow(new Label { Text = value.Level.ToString() },
				new Label { Text = value.Tag },
				new Label { Text = value.Text }
			);
			rows.Create ();
			rows.ResumeLayout ();
			ResumeLayout ();
		}
		public void OnError(Exception ex)
		{
		}
		public void OnCompleted()
		{
		}

        public void OnDoKo(object sender, EventArgs args)
        {
            throw new Exception("OkkO");
        }

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			Log.Messages.UnSubscribe (this);
		}
	}
}

