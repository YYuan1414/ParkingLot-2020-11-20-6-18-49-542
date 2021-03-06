﻿using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        public const int PositionMaxNumber = 10;
        private List<string> carList = new List<string>();
        private int positionNumber = PositionMaxNumber;
        public int PositionNumber
        {
            get { return positionNumber - CarList.Count; }
            set { positionNumber = value; }
        }

        public List<string> CarList
        {
            get { return carList; }
            set { carList = value; }
        }
    }
}
