using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ParkingLot
{
    public class ErrorMessage
    {
        private Dictionary<string, string> MessageDictionary { get; set; }

        public Dictionary<string, string> SetValue()
        {
            MessageDictionary = new Dictionary<string, string>();
            MessageDictionary.Add("wrongTicket", "Unrecognized parking ticket.");
            MessageDictionary.TryAdd("nullTicket", "Please provide your parking ticket.");
            MessageDictionary.TryAdd("noPosition", "Not enough position.");
            return MessageDictionary;
        }
    }
}
