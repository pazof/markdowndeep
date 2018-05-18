using System;
using Xunit;
using MarkdownDeep;
using MarkdownAVToXaml.Rendering.Text.Xaml;

namespace MarkdownDeepTest
{
	public class TestXamlLink
	{

		const string link = "[linkTitle](http://www.company.com)";
		const string xamlLink = "<LinkButton Command=\"{Binding openText}\" CommandParameter=\"http://www.company.com\">linkTitle</LinkButton>";
		const string htmlLink = "<p><a href=\"http://www.company.com\">linkTitle</a></p>\n";

		const string image = "![imageTitle](http://www.company.com/image.png)";
		const string xamlImage = "<LinkButton Command=\"{Binding openImage}\" CommandParameter=\"http://www.company.com/image.png\">imageTitle</LinkButton>" ;
		const string htmlImage = "<p><img src=\"http://www.company.com/image.png\" alt=\"imageTitle\" /></p>\n" ;

		const string audio = "![audio:audioTitle](http://www.company.com/audio.mp3)";
		const string xamlAudio = "<LinkButton Command=\"{Binding openAudio}\" CommandParameter=\"http://www.company.com/audio.mp3\">audioTitle</LinkButton>";
		const string htmlAudio = "<p><audio controls=\"controls\" src=\"http://www.company.com/audio.mp3\" alt=\"audioTitle\"></audio></p>\n";

		const string video = "![video:videoTitle](http://www.company.com/video.ogg)";
		const string xamlVideo = "<LinkButton Command=\"{Binding openVideo}\" CommandParameter=\"http://www.company.com/video.ogg\">videoTitle</LinkButton>";
		const string htmlVideo = "<p><video controls=\"controls\" alt=\"videoTitle\" /><source src=\"http://www.company.com/video.ogg\"></video></p>\n";


		const string linkWithEmphasys = "[link *title*](http://www.company.com)";
		const string linkWithEmphasyshtml = "<p><a href=\"http://www.company.com\">link <em>title</em></a></p>\n";
		// TODO a RichText rendering
		const string linkWithEmphasysxaml = "<LinkButton Command=\"{Binding openText}\" CommandParameter=\"http://www.company.com\">link title</LinkButton>";

		[Theory, 
			InlineData(link,xamlLink),
			InlineData(image,xamlImage), 
			InlineData(audio,xamlAudio), 
			InlineData(video,xamlVideo), 
			InlineData(linkWithEmphasys,linkWithEmphasysxaml)]
		public void LinkToXamlAreCorrect(string source, string expxaml)
		{
			var m = new Markdown ();
			var xr = new XamlRenderer ();
            var xaml = m.Render (source, xr);
			Assert.Equal (expxaml,xaml);
		}

		[Theory, 
			InlineData(link,htmlLink),
			InlineData(image,htmlImage), 
			InlineData(audio,htmlAudio), 
			InlineData(video,htmlVideo), 
			InlineData(linkWithEmphasys,linkWithEmphasyshtml)]
		public void LinkToHtmlIsCorrect(string source, string exphtml)
		{
			var m = new Markdown ();
			var html = m.Transform (source);
			Assert.Equal (exphtml,html);
		}



	}
}

