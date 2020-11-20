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
            var plateNumber = "GA12345";
            //when
            var parkingLot = new ParkingLot();
            var initialPositionNumber = parkingLot.PositionNumber;
            var parkingBoy = new ParkingBoy();
            var ticket = parkingBoy.ParkACar(plateNumber, parkingLot);
            var currentPositionNumber = parkingLot.PositionNumber;
            var actual = initialPositionNumber - currentPositionNumber;
            //then
            Assert.Equal(1, actual);
            Assert.Equal(plateNumber, ticket);
        }
    }
}
