using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using MarkdownDeep.Rendering.Xaml;
using System.IO;

namespace MDGui
{
	using MarkdownDeep;

	public partial class MainForm : Form
	{
		private WebView htmlView;

		private RichTextArea sourceCode;

		private Markdown markdown;

		private Label htmlCode;

		private XamlRenderer xamlRenderer = new XamlRenderer();

		private TabPage xamlContainer;

		private Label xamlCode;

		public MainForm ()
		{
			XamlReader.Load (this);
			markdown = new Markdown ();
			sourceCode.TextChanged += OnSourceChanged; 
			SyncFromSource ();
		}

		private void SyncFromSource() {
			var html = markdown.Transform(sourceCode.Text);
			htmlCode.Text = html;
			htmlView.LoadHtml(html);

			xamlCode.Text = markdown.Render (sourceCode.Text, xamlRenderer);
			using (var reader =
				new StringReader(xamlCode.Text))
			{
				// XamlReader.Load(reader,xamlContainer);
			}
		}

		private void OnSourceChanged(object sender, EventArgs e) 
		{	
			SyncFromSource ();
		}
		protected void HandleClickMe (object sender, EventArgs e)
		{
			MessageBox.Show ("I was clicked!");
		}

		protected void HandleQuit (object sender, EventArgs e)
		{
			Application.Instance.Quit ();
		}
	}
}

