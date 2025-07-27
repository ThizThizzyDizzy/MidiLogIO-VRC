using MidiLogIO.Receiver;

namespace MidiLogIO.Voice
{
    public class SimpleVoiceCommandReceiver : SimpleCommandReceiver
    {
        public BaseMidiLogIO io;

        public override void Receive(string value)
        {
            if (value == "[MidiLogIO-Voice] INIT")
            {
                foreach (var command in commands)
                {
                    io.SendLine($"[MidiLogIO-Voice] COMMAND - {command}");
                    io.SendLine($"[MidiLogIO-Voice] END INIT");
                }

                return;
            }

            base.Receive(value);
        }
    }
}