using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using MarkdownDeep.Rendering.Xaml;
using System.IO;
using System.Text;
using System.Xml;

namespace MDGui
{
	using MarkdownDeep;

	public partial class MainForm : Form
	{
		private TabPage xamlViewTab;
		/// <summary>
		/// Gets the xaml view tab.
		/// </summary>
		/// <value>The xaml view tab.</value>
		public TabPage XamlViewTab {
			get { return xamlViewTab; }
		}
		private WebView htmlView;

		private RichTextArea sourceCode;

		private Markdown markdown;

		private Label htmlCode;

		private XamlRenderer xamlRenderer = new XamlRenderer();

		// private MyDynamicControl xamlContainer;

		private Label xamlCode;

		/// <summary>
		/// Initializes a new instance of the <see cref="MDGui.MainForm"/> class.
		/// </summary>
		public MainForm ()
		{
			markdown = new Markdown ();
			MyInitialize ();
		}

		/// <summary>
		/// Mies the initialize.
		/// </summary>
		public  void MyInitialize () {
			base.Initialize ();
			XamlReader.Load (this);
			sourceCode.TextChanged += OnSourceChanged; 
			SyncFromSource ();
		}

		private void SyncFromSource() {
			
			var html = markdown.Transform(sourceCode.Text);
			htmlCode.Text = html;
			htmlView.LoadHtml(html);
			string source = markdown.Render (sourceCode.Text, xamlRenderer);
			xamlCode.Text = source;

			//FIXME Generate valide Xaml
			//source = "<Label>Pas encore implémenté</Label>";

			string wholeSource = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
				"<TabPage xmlns=\"http://schema.picoe.ca/eto.forms\"\n" +
				" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n" +
				" xmlns:local=\"clr-namespace:MDGui;assembly=MDGui\" >" + source +
				"</TabPage>"
				;
			
			using (var reader = new StringReader (wholeSource)) {
				XamlReader.Load (reader, xamlViewTab);
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

