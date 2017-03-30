using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using Eto.Serialization.Xaml;
using System.Collections.ObjectModel;
using MarkdownDeep.Rendering.Xaml;
using System.Resources;
using System.Windows.Input;

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

		private TextArea htmlCode;

		private XamlRenderer xamlRenderer = new XamlRenderer();

		// private MyDynamicControl xamlContainer;

		private TextArea xamlCode;

		/// <summary>
		/// Initializes a new instance of the <see cref="MDGui.MainForm"/> class.
		/// </summary>
		public MainForm ()
		{
			markdown = new Markdown ();
			Logs = new Log ();
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
			var node = markdown.Render (sourceCode.Text, xamlRenderer);
			string source = node?.ToXaml();
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
				SuspendLayout ();
				try { 
					XamlReader.Load (reader, xamlViewTab);
				}
				catch (Portable.Xaml.XamlObjectWriterException ex) {
					// FIXME handle?

					Log.LogError($"Xaml({ex.LineNumber},{ex.LinePosition})", ex.Message);
				}
				catch (System.Xml.XmlException ex) {
					Log.LogError($"Xml({ex.LineNumber},{ex.LinePosition})", ex.Message);
				}
				finally {
					ResumeLayout ();
				}

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
		protected void HandleOpen (object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog {
				Filters = { 
					new FileDialogFilter ("Markdown", 
						new string[] { "*.md", "*.txt" }),
					new FileDialogFilter ("Tous", 
						new string[] { "*" })
				},
				Title = "Ouvrir un fichier texte"
			};
			DialogResult fileToLoad = dialog.ShowDialog (this.Content);
			if (fileToLoad.HasFlag (DialogResult.Ok)) {
				var fi = new FileInfo(dialog.FileName);
				using (FileStream stream = fi.OpenRead ()) {
					using (var rdr = new StreamReader (stream)) {
						sourceCode.Text = rdr.ReadToEnd ();
					}
				}
			}
		}


		protected void HandleSave (object sender, EventArgs e)
		{
			var dialog = new SaveFileDialog { 
				Filters = { 
					new FileDialogFilter ("Markdown", 
						new string[] { "*.md", "*.txt" }),
					new FileDialogFilter ("Tous", 
						new string[] { "*" })
				}
			};
			DialogResult fileToSave = dialog.ShowDialog (this.Content);
			if (fileToSave.HasFlag (DialogResult.Ok)) {
				// If file exists, user should have been warn about.
				var fi = new FileInfo(dialog.FileName);
				using (var stream = fi.OpenWrite ()) {
					var wr = Encoding.UTF8.GetBytes(sourceCode.Text);
					stream.Write (wr, 0, wr.Length);
					stream.Close ();
				}
			}
		}
		protected void HandleLog (object sender, EventArgs e)
		{
			FontFormat ();
			log.Show ();
		}
		LogMessagesDialog log = new LogMessagesDialog ();

		protected void HandleCredits (object sender, EventArgs e)
		{
			new Credits ().ShowModal ();
		}

		internal static Log Logs { get; private set; }
		public void FontFormat() 
		{
			string font1 = new Font("Serif",45).ToString ();
			font1 = new Font("Serif",45,FontStyle.Bold,FontDecoration.Strikethrough).ToString ();
			font1 = new Font("Serif",45,FontStyle.Italic,FontDecoration.Underline).ToString ();


		}

	}
}

