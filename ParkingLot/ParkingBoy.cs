using System.Linq;

namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        public Ticket[] ParkCars(string[] plateNumbers, ParkingLot parkingLot)
        {
            const int positionReduceNumberPerTime = 1;
            Ticket[] tickets = plateNumbers.Where(number => number != null)
                .Select(it => new Ticket { TicketMarker = it, IsUsed = false })
                .ToArray();
            foreach (var plateNumber in plateNumbers)
            {
                parkingLot.CarList.Add(plateNumber);
                parkingLot.PositionNumber -= positionReduceNumberPerTime;
            }

            return tickets;
        }

        public bool FetchTheCar(Ticket ticket, ParkingLot parkingLot)
        {
            const int positionReduceNumberPerTime = 1;
            string hasTheCar = parkingLot.CarList.Find(number => number == ticket.TicketMarker);
            if (string.IsNullOrEmpty(ticket.TicketMarker) || hasTheCar == null || ticket.IsUsed)
            {
                return false;
            }
            else
            {
                parkingLot.CarList.Remove(ticket.TicketMarker);
                ticket.IsUsed = true;
                parkingLot.PositionNumber += positionReduceNumberPerTime;
                return true;
            }
        }
    }
}
