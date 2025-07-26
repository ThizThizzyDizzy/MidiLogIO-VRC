using MidiLogIO.Receiver;

public abstract class MidiLogConverter<T, V> : MidiLogReceiver<T>
{
    public MidiLogReceiver<V> receiver;
}