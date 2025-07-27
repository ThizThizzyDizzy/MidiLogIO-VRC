using UnityEngine;
using VRC.Udon;

namespace MidiLogIO.Receiver
{
    public class SimpleCommandReceiver : MidiLogReceiver<string>
    {
        public string[] commands;
        public UdonBehaviour[] targetBehaviors;
        public string[] targetEvents;

        public override void Receive(string value)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                if (value == commands[i])
                {
                    Debug.Log($"Received command: {value}, triggering custom event {targetEvents[i]} in {targetBehaviors[i].gameObject.name}");
                    targetBehaviors[i].SendCustomEvent(targetEvents[i]);
                    return;
                }
            }

            Debug.LogWarning($"Received invalid command: {value}");
        }
    }
}