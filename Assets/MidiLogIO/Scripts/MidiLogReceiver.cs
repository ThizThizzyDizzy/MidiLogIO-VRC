using UdonSharp;

namespace MidiLogIO.Receiver
{
    public abstract class MidiLogReceiver<T> : UdonSharpBehaviour
    {
        public abstract void Receive(T value);
    }
}