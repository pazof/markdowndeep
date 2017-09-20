using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MDGui
{
	public class Settings : INotifyPropertyChanged
	{
		private bool viewHtmlCode;
		private bool viewXamlCode;
		private bool viewHtml;
		private bool viewXaml;

		public bool ViewHtmlCode { get { return viewHtmlCode; }
			set { viewHtmlCode=value; OnPropertyChanged (); } } 
		public bool ViewXamlCode { get { return viewXamlCode; }
			set { viewXamlCode=value; OnPropertyChanged (); } }
		public bool ViewHtml { get { return viewHtml; }
			set { viewHtml=value; OnPropertyChanged (); } } 
		public bool ViewXaml { get { return viewXaml; }
			set { viewXaml=value; OnPropertyChanged (); } } 

		private int recentListLength;
		public int RecentListLength { get { return recentListLength; }
			set { recentListLength=value; OnPropertyChanged (); }  }
		
		void OnPropertyChanged([CallerMemberName] string memberName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

		public Settings CreateBackup()
		{
			return (Settings) MemberwiseClone ();
		}
		public void Restore(Settings settings)
		{
			ViewHtml = settings.ViewHtml;
			ViewXaml = settings.ViewXaml;
			ViewHtmlCode = settings.ViewHtmlCode;
			ViewXamlCode = settings.ViewXamlCode;
			RecentListLength = settings.RecentListLength;
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}

