using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class Ticket
    {
        private string ticketMarker;
        private bool isUsed;

        public string TicketMarker
        {
            get { return ticketMarker; }
            set { ticketMarker = value; }
        }

        public bool IsUsed
        {
            get { return isUsed; }
            set { isUsed = value; }
        }
    }
}
