namespace MidiLogIO
{
    public class HalfMidiLogIO : BaseMidiLogIO
    {
        public int channel = 15;

        public void Start()
        {
            Init($"HALF {channel}");
        }

        public override void MidiControlChange(int channel, int number, int value)
        {
            if (channel != this.channel) return;

            if (number < 118 || number > 119) return;
            var n = number - 118;

            var fullNumber = (n << 7) + value;

            Receive((byte)fullNumber);
        }
    }
}