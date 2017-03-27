using System;
using Xunit;
using MarkdownDeep;
using MarkdownDeep.Rendering.Xaml;

namespace MarkdownDeepTest
{
	public class Test
	{
		[Fact ()]
		public void MarkdownXamlRuns ()
		{
			var m = new Markdown ();
			var xr = new XamlRenderer ();
			var str = Resources.ResourceManager.GetString ("LegacyTestSource");
			var result = m.Render(str, xr);
		}

		[Fact ()]
		public void MarkdownInstanceExists ()
		{
			var m = new Markdown ();
		}

		[Fact ()]
		public void MarkdownLegacyBehaviorRuns ()
		{
			var m = new Markdown ();
			var result = m.Transform (Resources.ResourceManager.GetString("LegacyTestSource"));
		}

	}
}

