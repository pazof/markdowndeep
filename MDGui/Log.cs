using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System.Collections.Concurrent;
using System.Linq;

namespace MDGui
{
	public class Log 
	{
		public static void LogInfo (string tag, string message)
		{
			Messages.Push (new Message { Tag = tag, Text = message, Level = ErrorLevel.Info });
		}

		public static void LogWarning (string tag, string message)
		{
			Messages.Push (new Message { Tag = tag, Text = message, Level = ErrorLevel.Warning });
		}

		public static void LogError (string tag, string message)
		{
			Messages.Push (new Message { Tag = tag, Text = message, Level = ErrorLevel.Error });
		}

		public static ObservableMessageCollection Messages { get; private set; } =
			new ObservableMessageCollection();
	}

	public class ObservableMessageCollection : 
	 IObservable<Message> {
		public ObservableMessageCollection() {
			
		}

		public void Push(Message msg){
			messages.Push (msg);
			observers.ForEach (o => o.OnNext (msg));
		}

		ConcurrentStack<Message> messages = new ConcurrentStack<Message> ();
		List<IObserver<Message>> observers = new List<IObserver<Message>> ();

		public IDisposable Subscribe (IObserver<Message> observer) {
			observers.Add (observer);
			return new Subscription (this,observer);
		}

		public void UnSubscribe(IObserver<Message> observer) {
			observers.Remove (observer);
		}
	}

	public class Subscription: IDisposable {
		ObservableMessageCollection subscribed;
		IObserver<Message> observer;

		public Subscription(ObservableMessageCollection collection, IObserver<Message> observer)
		{
			subscribed = collection;
			this.observer = observer;
		}

		public void Dispose () {
			subscribed.UnSubscribe( observer );
		}
	}

	public class Message
	{
		public ErrorLevel Level { get; set; } = ErrorLevel.Info;

		public string Text { get; set; }

		public string Tag { get; set; }
	}

	public enum ErrorLevel
	{
		Info,
		Warning,
		Error
	}
}

