namespace MidiLogIO
{
    public class FullMidiLogIO : BaseMidiLogIO
    {
        public int[] channels = new int[2];

        public void Start() => Init($"FULL {channels[0]} {channels[1]}");

        public override void MidiNoteOff(int channel, int number, int velocity)
        {
            int channelIndex = -1;
            for (int i = 0; i < channels.Length; i++)
                if (channel == channels[i])
                    channelIndex = i;
            if (channelIndex == -1) return;

            int fullNumber = (channelIndex << 14) + (number << 7) + velocity;

            Receive((byte)((fullNumber >> 8) & 0xff));
            Receive((byte)(fullNumber & 0xff));
        }

        public override void MidiNoteOn(int channel, int number, int velocity)
        {
            int channelIndex = -1;
            for (int i = 0; i < channels.Length; i++)
                if (channel == channels[i])
                    channelIndex = i;
            if (channelIndex == -1) return;

            int fullNumber = 0b10000000_00000000 + (channelIndex << 14) + (number << 7) + velocity;

            Receive((byte)((fullNumber >> 8) & 0xff));
            Receive((byte)(fullNumber & 0xff));
        }

        public override void MidiControlChange(int channel, int number, int value)
        {
            if (channel != channels[channels.Length-1]) return;

            if (number < 118 || number > 119) return;
            var n = number - 118;

            var fullNumber = (n << 7) + value;

            Receive((byte)fullNumber);
        }
    }
}