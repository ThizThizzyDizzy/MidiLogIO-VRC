using System;
using System.Text;
using MidiLogIO.Receiver;
using UdonSharp;
using UnityEngine;

namespace MidiLogIO
{
    public abstract class BaseMidiLogIO : UdonSharpBehaviour
    {
        public string[] advertisedCapabilities;
        private Guid uid;
        public MidiLogReceiver<byte> target;

        [Range(1, 1000)]
        public int speed = 200; // messages per second

        public void Init(string message)
        {
            uid = Guid.NewGuid();
            Send("INIT", $"{speed} {message}\t[{string.Join("]\t[", advertisedCapabilities)}]");
        }

        public void SendLine(string message) => Send($"{message}\n");
        public void Send(string message) => Send(Encoding.ASCII.GetBytes(message));

        public void Send(params byte[] message)
        {
            string hex = "";
            foreach (var b in message) hex += b.ToString("x2");
            Send("DATA", hex);
        }

        private void Send(string type, string message) => Debug.Log($"[MidiLogIO/{uid}] {type} - {message}");

        protected void Receive(byte data)
        {
            target.Receive(data);
        }
    }
}