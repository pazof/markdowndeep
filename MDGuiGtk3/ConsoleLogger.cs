using System;

namespace MDGui.Gtk3
{
	public class ConsoleLogger : IObserver<Message>
	{
		public ConsoleLogger ()
		{
		}
		public void OnCompleted (){
		}

		public void OnError (Exception error){
		}

		public void OnNext (Message value) {
			Console.WriteLine($"{value.Level} [{value.Tag}] {value.Text}");
		}

	}
}

