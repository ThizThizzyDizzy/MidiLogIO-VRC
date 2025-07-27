namespace MidiLogIO.Converter
{
    public class LineConverter : MidiLogConverter<byte, string>
    {
        private const char LINE_TERMINATOR = '\n';
        private string buffer = "";

        public override void Receive(byte b)
        {
            if (b == LINE_TERMINATOR)
            {
                receiver.Receive($"{buffer}");
                buffer = "";
                return;
            }

            buffer += (char)b;
        }
    }
}