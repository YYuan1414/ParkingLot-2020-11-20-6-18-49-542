using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        private const int PositionMaxNumber = 10;
        private List<string> ticketList = new List<string>();
        private int positionNumber = PositionMaxNumber;
        public int PositionNumber
        {
            get { return positionNumber; }
            set { positionNumber = value; }
        }

        public List<string> TicketList
        {
            get { return ticketList; }
            set { ticketList = value; }
        }
    }
}
