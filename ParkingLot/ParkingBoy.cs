namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        public string ParkACar(string plateNumber, ParkingLot parkingLot)
        {
            parkingLot.PositionNumber -= 1;
            parkingLot.TicketList.Add(plateNumber);
            return parkingLot.TicketList.Find(number => number == plateNumber);
        }
    }
}
