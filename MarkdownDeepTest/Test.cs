using System;
using Xunit;
using MarkdownDeep;
using MarkdownAVToXaml.Rendering.Text.Xaml;

namespace MarkdownDeepTest
{
	public class Test
	{
		[Fact ()]
		public void MarkdownXamlRuns ()
		{
			var m = new Markdown ();
			var xr = new XamlRenderer ("Page");
			var str = Resources.ResourceManager.GetString ("LegacyTestSource");
            string xaml = m.Render (str, xr) ;
		}

		[Fact ()]
		public void MarkdownInstanceExists ()
		{
			new Markdown ();
		}



		[Fact ()]
		public void MarkdownLegacyBehaviorRuns ()
		{
			var m = new Markdown ();
			m.Transform (Resources.ResourceManager.GetString("LegacyTestSource"));
		}



	}
}

