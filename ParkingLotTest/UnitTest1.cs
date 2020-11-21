using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Parking_Boy_Can_Park_A_Car_Into_Parking_Lot_Test()
        {
            //given
            var plateNumber = new string[1] { "G 123455" };
            var expectedReducedNUmberOfPosition = 1;
            var expectedIncreasedNumberOfCar = 1;
            var index = plateNumber.Length - 1;

            //when
            var parkingLot = new ParkingLot();
            var initialPositionNumber = parkingLot.PositionNumber;
            var initialCarListNumber = parkingLot.CarList.Count;
            var parkingBoy = new ParkingBoy();
            parkingBoy.ParkCars(plateNumber, parkingLot);
            var currentPositionNumber = parkingLot.PositionNumber;
            var currentCarListNumber = parkingLot.CarList.Count;
            var actualReducedNUmberOfPosition = initialPositionNumber - currentPositionNumber;
            var actualIncreasedNumberOfCar = currentCarListNumber - initialCarListNumber;

            //then
            Assert.NotNull(parkingLot.CarList.Find(number => number == plateNumber[index]));
            Assert.Equal(expectedIncreasedNumberOfCar, actualIncreasedNumberOfCar);
            Assert.Equal(expectedReducedNUmberOfPosition, actualReducedNUmberOfPosition);
        }

        [Fact]
        public void Parking_Boy_Can_Fetch_The_Car_By_Ticket_Test()
        {
            //given
            const int numberOfFetchedCar = 1;
            const int index = 0;
            var plateNumber = new string[numberOfFetchedCar] { "G 123455" };
            var ticketStrings = new string[numberOfFetchedCar] { "G 123455" };

            //when
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            Ticket[] tickets = parkingBoy.ParkCars(plateNumber, parkingLot);
            Random random = new Random();
            var intIndex = random.Next(0, tickets.Length);
            var canFetchCar = parkingBoy.FetchTheCar(tickets[intIndex], parkingLot);
            var fetchedCar = parkingLot.CarList.Find(car => car == plateNumber[index]);

            //then
            Assert.True(canFetchCar);
            Assert.Null(fetchedCar);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("G 123433")]
        public void Parking_Boy_Can_Fetch_No_Car_By_Null_Or_Wrong_Ticket_Test(string ticket)
        {
            //given
            const int numberOfFetchedCar = 1;
            const int index = 0;
            var plateNumber = new string[numberOfFetchedCar] { "G 123455" };
            var ticketStrings = new string[numberOfFetchedCar] { ticket };
            Ticket wrongTicket = new Ticket() { TicketMarker = ticket, IsUsed = false };

            //when
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            Ticket[] tickets = parkingBoy.ParkCars(plateNumber, parkingLot);
            var canFetchCar = parkingBoy.FetchTheCar(wrongTicket, parkingLot);
            var fetchedCar = parkingLot.CarList.Find(car => car == ticket);

            //then
            Assert.Null(fetchedCar);
            Assert.False(canFetchCar);
        }

        [Fact]
        public void Parking_Boy_Can_Park_Multiple_Cars_Into_Parking_Lot_Test()
        {
            //given
            var plateNumbers = new string[] { "G 123455", "G 234561", "A HG125555" };
            var expectedReducedNUmberOfPosition = plateNumbers.Length;
            var expectedIncreasedNumberOfCar = plateNumbers.Length;

            //when
            var parkingLot = new ParkingLot();
            var initialPositionNumber = parkingLot.PositionNumber;
            var initialCarListNumber = parkingLot.CarList.Count;
            var parkingBoy = new ParkingBoy();
            Ticket[] tickets = parkingBoy.ParkCars(plateNumbers, parkingLot);
            var currentPositionNumber = parkingLot.PositionNumber;
            var currentCarListNumber = parkingLot.CarList.Count;
            var actualReducedNUmberOfPosition = initialPositionNumber - currentPositionNumber;
            var actualIncreasedNumberOfCar = currentCarListNumber - initialCarListNumber;

            //then
            foreach (var plateNumber in plateNumbers)
            {
                Assert.NotNull(parkingLot.CarList.Find(number => number == plateNumber));
            }

            Assert.Equal(expectedIncreasedNumberOfCar, actualIncreasedNumberOfCar);
            Assert.Equal(expectedReducedNUmberOfPosition, actualReducedNUmberOfPosition);
        }

        [Fact]
        public void Parking_Boy_Can_Fetch_No_Car_By_Used_Ticket_Test()
        {
            //given
            const int numberOfFetchedCar = 1;
            const int index = numberOfFetchedCar - 1;
            var plateNumber = new string[numberOfFetchedCar] { "G 123455" };
            Ticket usedTicket = new Ticket() { TicketMarker = plateNumber[index], IsUsed = false };

            //when
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            Ticket[] tickets = parkingBoy.ParkCars(plateNumber, parkingLot);
            var canFetchCar = parkingBoy.FetchTheCar(usedTicket, parkingLot);
            var canFetchCarTwice = parkingBoy.FetchTheCar(usedTicket, parkingLot);
            var fetchedCar = parkingLot.CarList.Find(car => car == usedTicket.TicketMarker);

            //then
            Assert.Null(fetchedCar);
            Assert.False(canFetchCarTwice);
        }

        [Fact]
        public void Parking_Boy_Can_Fetch_No_Car_If_No_Position_In_ParkingLot_Test()
        {
            //given
            const int numberOfFetchedCar = 1;
            const int index = numberOfFetchedCar - 1;
            var plateNumber = new string[numberOfFetchedCar] { "G 123455" };
            Ticket usedTicket = new Ticket() { TicketMarker = plateNumber[index], IsUsed = false };
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            //when
            parkingLot.CarList = new List<string>();

            for (int carIndex = 0; carIndex < parkingLot.PositionNumber; carIndex++)
            {
                parkingLot.CarList.Add("G 12345" + carIndex);
            }

            Ticket[] tickets = parkingBoy.ParkCars(plateNumber, parkingLot);

            //then
            Assert.Null(tickets);
        }
    }
}
