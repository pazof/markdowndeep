﻿using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using Eto.Serialization.Xaml;
using System.Collections.ObjectModel;
using System.Resources;
using System.Windows.Input;

namespace MDGui
{
    using MarkdownAVToXaml.Rendering.Text.Xaml;
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

		private ButtonMenuItem btnSave;
		// private MyDynamicControl xamlContainer;

		private TextArea xamlCode;

		private TabControl viewTabs;

		/// <summary>
		/// Initializes a new instance of the <see cref="MDGui.MainForm"/> class.
		/// </summary>
		public MainForm ()
		{
			markdown = new Markdown ();
			Logs = new Log ();
			base.Initialize ();
			XamlReader.Load (this);
			sourceCode.TextChanged += OnSourceChanged; 
			DataContext = this;
		}

		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);
			SyncFromSource ();
		}

		private void SyncFromSource() {
			
			var html = markdown.Transform(sourceCode.Text);
			htmlCode.Text = html;
			htmlView.LoadHtml(html);
			//FIXME Generate a valide Xaml header
            var source = markdown.Render (sourceCode.Text, xamlRenderer);
			xamlCode.Text = source;

			string wholeSource = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
				"<TabPage xmlns=\"http://schema.picoe.ca/eto.forms\"\n" +
				" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n" +
				" xmlns:local=\"clr-namespace:MDGui;assembly=MDGui\" >" + source +
				"</TabPage>"
				;
			
			using (var reader = new StringReader (wholeSource)) {

				xamlViewTab.SuspendLayout();
				try { 
					XamlReader.Load (reader, xamlViewTab);
				}
				catch (Portable.Xaml.XamlObjectWriterException ex) {
					Log.LogError($"Xaml({ex.LineNumber},{ex.LinePosition})", ex.Message);
				}
				catch (System.Xml.XmlException ex) {
					Log.LogError($"Xml({ex.LineNumber},{ex.LinePosition})", ex.Message);
				}
				finally {
					xamlViewTab.ResumeLayout ();
				}

			}

		}

		private void OnSourceChanged(object sender, EventArgs e) 
		{	
			Dirty = true;
			SyncFromSource ();
		}

		protected void HandleRefresh (object sender, EventArgs e)
		{
			SyncFromSource ();
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
				LoadMarkdownFile (dialog.FileName);
			}
		}

		public void LoadMarkdownFile (string fileName) {
			var fi = new FileInfo(fileName);
			using (FileStream stream = fi.OpenRead ()) {
				using (var rdr = new StreamReader (stream)) {
					Source = rdr.ReadToEnd ();
				}
			}
		}
		public string Source { get { return sourceCode.Text;
			} set { sourceCode.Text = value;
			} }
		
		public string SourcePath { get; set; }  = null;

		protected void HandleSave (object sender, EventArgs e)
		{
			FileInfo fi = null;
			if (SourcePath == null) {
				fi = AskForAFile () ;
					SourcePath = fi.FullName;

			} else {
				fi = new FileInfo (SourcePath);
			}
			WriteTo (fi);
		}

		private void WriteTo(FileInfo fi)
		{
			using (var stream = fi.OpenWrite ()) {
				var wr = Encoding.UTF8.GetBytes (sourceCode.Text);
				stream.Write (wr, 0, wr.Length);
				stream.Close ();
			}
			Dirty = false;
		}

		public bool Dirty { 
			get { 
				return btnSave.Enabled;
			}
			set { 
				btnSave.Enabled = value;
			}
		}

		private FileInfo AskForAFile()
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
				return new FileInfo (dialog.FileName);
			}
			return null;
		}

		protected void HandleSaveAs (object sender, EventArgs e)
		{
			var fi = AskForAFile ();
			if (fi != null)
				WriteTo (fi);
		}

		protected void HandleLog (object sender, EventArgs e)
		{
			log.Show ();
		}

		LogMessagesDialog log = new LogMessagesDialog ();

		protected void HandleSettings(object sender, EventArgs e)
		{
			var diag = new SettingsForm (Settings);
			diag.ShowModal ();
		}

		protected void HandleCredits (object sender, EventArgs e)
		{
			new Credits ().ShowModal ();

		}
		internal static Log Logs { get; private set; }

		public Settings Settings { get; set; } = new Settings { ViewHtml = true } ;
	}
}

