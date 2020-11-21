namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        public void ParkCars(string[] plateNumbers, ParkingLot parkingLot)
        {
            const int positionReduceNumberPerTime = 1;
            foreach (var plateNumber in plateNumbers)
            {
                parkingLot.CarList.Add(plateNumber);
                parkingLot.TicketList.Add(plateNumber);
                parkingLot.PositionNumber -= positionReduceNumberPerTime;
            }
        }

        public bool FetchCars(string[] tickets, ParkingLot parkingLot)
        {
            const int positionReduceNumberPerTime = 1;
            foreach (var ticket in tickets)
            {
                string hasTheCar = parkingLot.CarList.Find(number => number == ticket);
                if (string.IsNullOrEmpty(ticket) || hasTheCar == null)
                {
                    return false;
                }
                else
                {
                    parkingLot.CarList.Remove(ticket);
                    parkingLot.TicketList.Remove(ticket);
                    parkingLot.PositionNumber += positionReduceNumberPerTime;
                }
            }

            return true;
        }
    }
}
