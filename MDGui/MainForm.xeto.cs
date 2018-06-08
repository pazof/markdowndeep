using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.ObjectModel;
using System.Resources;
using System.Windows.Input;
using System.ComponentModel;

namespace MDGui
{
    using Eto.Markdown;
    using Eto.Serialization.Xaml;
    using MarkdownAVToXaml.Rendering.Text;
    using MarkdownAVToXaml.Rendering.Text.Xaml;
    using MarkdownDeep;
    public partial class MainForm : Form, INotifyPropertyChanged
    {
        #pragma warning disable CS0649
        TabPage xamlViewTab;
        WebView htmlView;
        TextArea htmlCode;
        RichTextArea sourceCode;
        ButtonMenuItem btnSave;
        TextArea xamlCode;
        MenuBar menuBar;
        MarkdownArea mdArea;
        #pragma warning disable CS0649


		private Markdown markdown;

		private XamlRenderer xamlRenderer = new XamlRenderer("TabPage");

		// private MyDynamicControl xamlContainer;


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
            // TODO Localization
            menuBar.ApplicationMenu.Text = Resources.TitreMenuFichier;
            menuBar.HelpMenu.Text = "Aide";
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
			
            var source = markdown.Render (sourceCode.Text, xamlRenderer);
			xamlCode.Text = source;

			using (var reader = new StringReader (source)) {

				xamlViewTab.SuspendLayout();
				try { 
					XamlReader.Load (reader, xamlViewTab);
				}
				catch (XmlException ex) {
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

        string DirtyHint { get { return Dirty ? "*" : ""; }}

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
                Filters =  {
                    new FileDialogFilter("Markdown", new string[] { "*.md", "*.txt" }),
                    new FileDialogFilter("Tous", new string[] { "*" })
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
                
				using (var rdr = new StreamReader (stream,true)) {
					Source = rdr.ReadToEnd ();
                    encoding = rdr.CurrentEncoding;
				}
			}
            SourcePath = fi.FullName;
            Dirty = false;
		}

        string EncodingDisplay {
            get {
                return encoding.EncodingName;
            }
        }

		public string Source { get { return sourceCode.Text;
			} set { sourceCode.Text = value;
		} }

        string sourcePath;

        public string SourcePath { 
            get {
                return sourcePath;
            } 
            set {
                if (value != sourcePath)
                {
                    sourcePath = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SourcePath)));
                }
            } 
        }  

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

        Encoding encoding = Encoding.UTF8;

		private void WriteTo(FileInfo fi)
		{
			using (var stream = fi.OpenWrite ()) {
                var wr = encoding.GetBytes (sourceCode.Text);
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dirty)));
			}
		}

        string fileName;
		private FileInfo AskForAFile()
		{
			var dialog = new SaveFileDialog { 
                Title = "Fichier de destination",
				Filters = { 
					new FileDialogFilter ("Markdown", new string[] { "*.md", "*.txt" }),
					new FileDialogFilter ("Tous", new string[] { "*" })
				},
                FileName = fileName
			};
			DialogResult fileToSave = dialog.ShowDialog (this);
			if (fileToSave.HasFlag (DialogResult.Ok)) {
                fileName = dialog.FileName;
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

        public event PropertyChangedEventHandler PropertyChanged;

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

        public Settings Settings { get; set; } = new Settings { ViewXaml = true, ViewXamlCode = true } ;
	}
}

