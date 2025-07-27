using MidiLogIO.Receiver;

namespace MidiLogIO.Converter
{
    public abstract class MidiLogConverter<T, V> : MidiLogReceiver<T>
    {
        public MidiLogReceiver<V> receiver;
    }
}