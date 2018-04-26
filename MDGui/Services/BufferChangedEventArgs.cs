using System;

namespace MDGui
{
    public class BufferChangedEventArgs: EventArgs
    {
        public virtual string Source { get; }
        public virtual long StartingPostion { get;  }
    }
}