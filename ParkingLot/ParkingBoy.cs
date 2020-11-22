using System.Linq;
using System.Xml.Schema;

namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        private string response = string.Empty;

        public string Response
        {
            get { return response; }
        }

        public Ticket[] ParkCars(string[] plateNumbers, ParkingLot parkingLot, bool queryErrorMessage)
        {
            var hasPositions = plateNumbers.Length <= ParkingLot.PositionMaxNumber - parkingLot.CarList.Count;
            if (!hasPositions)
            {
                SendErrorMessage(queryErrorMessage, "noPosition");
                return null;
            }

            Ticket[] tickets = plateNumbers.Where(number => number != null)
                    .Select(it => new Ticket { TicketMarker = it, IsUsed = false })
                    .ToArray();
            foreach (var plateNumber in plateNumbers)
            {
                    parkingLot.CarList.Add(plateNumber);
            }

            return tickets;
        }

        public Ticket[] ParkCarsSequently(string[] plateNumbers, ParkingLot[] parkingLots, bool queryErrorMessage)
        {
            const int positionReduceNumberPerTime = 1;
            var totalPositions = parkingLots.Select(parkingLot => { return parkingLot.PositionNumber; }).Sum();
            Ticket[] allTickets = null;
            if (totalPositions == 0)
            {
                SendErrorMessage(queryErrorMessage, "noPosition");
                return null;
            }

            foreach (var parkingLot in parkingLots)
            {
                var positionsOfEachParkingLots = parkingLot.PositionNumber > plateNumbers.Length
                    ? plateNumbers.Length
                    : parkingLot.PositionNumber;

                var subPlateNumbers = plateNumbers.ToList().Take(positionReduceNumberPerTime).ToArray();
                if (positionsOfEachParkingLots != 0)
                {
                    Ticket[] tickets = subPlateNumbers.Where(number => number != null)
                        .Select(it => new Ticket { TicketMarker = it, IsUsed = false })
                        .ToArray();
                    foreach (var plateNumber in subPlateNumbers)
                    {
                        parkingLot.CarList.Add(plateNumber);
                    }

                    if (allTickets == null)
                    {
                        allTickets = tickets;
                    }

                    allTickets = allTickets.Concat(tickets).ToArray();
                }

                var numberOfRemainedPlateNumbers = plateNumbers.Length - positionsOfEachParkingLots;
                plateNumbers = plateNumbers.ToList().TakeLast(numberOfRemainedPlateNumbers).ToArray();
            }

            return allTickets;
        }

        public bool FetchTheCar(Ticket ticket, ParkingLot parkingLot, bool queryErrorMessage)
        {
            if (!string.IsNullOrEmpty(response))
            {
                return false;
            }

            const int positionReduceNumberPerTime = 1;
            string hasTheCar = parkingLot.CarList.Find(number => number == ticket.TicketMarker);
            if (string.IsNullOrEmpty(ticket.TicketMarker))
            {
                SendErrorMessage(queryErrorMessage, "nullTicket");
                return false;
            }

            if (hasTheCar == null || ticket.IsUsed)
            {
                SendErrorMessage(queryErrorMessage, "wrongTicket");
                return false;
            }

            parkingLot.CarList.Remove(ticket.TicketMarker);
            ticket.IsUsed = true;
            parkingLot.PositionNumber += positionReduceNumberPerTime;
            return true;
        }

        private string SendErrorMessage(bool queryErrorMessage, string condition)
        {
            if (queryErrorMessage)
            {
                var errorMessage = new ErrorMessage();
                var messageBox = errorMessage.SetValue();
                response = messageBox[condition];
            }

            return response;
        }
    }
}
