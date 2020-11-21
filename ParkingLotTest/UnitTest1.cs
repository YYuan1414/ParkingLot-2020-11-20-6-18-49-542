using System;
using System.Collections;

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
            parkingBoy.ParkCars(plateNumber, parkingLot);
            var canFetchCar = parkingBoy.FetchCars(ticketStrings, parkingLot);
            var fetchedCar = parkingLot.CarList.Find(car => car == plateNumber[index]);

            //then
            Assert.True(canFetchCar);
            Assert.Null(fetchedCar);
        }

        [Fact]
        public void Parking_Boy_Can_Park_Multiple_Cars_Into_Parking_Lot_Test()
        {
            //given
            var plateNumber = new string[] { "G 123455", "G 234561", "A HG125555" };
            var expectedReducedNUmberOfPosition = plateNumber.Length;
            var expectedIncreasedNumberOfCar = plateNumber.Length;

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
            Assert.Equal(expectedIncreasedNumberOfCar, actualIncreasedNumberOfCar);
            Assert.Equal(expectedReducedNUmberOfPosition, actualReducedNUmberOfPosition);
        }
    }
}
