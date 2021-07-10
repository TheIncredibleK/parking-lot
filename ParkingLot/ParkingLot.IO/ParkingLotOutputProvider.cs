using System;
using ParkingLot.IO.ParkingLotIO;

namespace ParkingLot.IO
{
    public static class ParkingLotOutputProvider

    {
        public static IParkingLotGateOutputs ClosedOutput()
        {
            ParkingLotOutput output = new ParkingLotOutput(false, false, false, false, true);
            return output;
        }

        public static IParkingLotGateOutputs ClosingOutput()
        {
            ParkingLotOutput output = new ParkingLotOutput(false, true, false, true, false);
            return output;
        }

        public static IParkingLotGateOutputs OpeningOutput()
        {
            ParkingLotOutput output = new ParkingLotOutput(true, false, false, true, false);
            return output;
        }

        public static IParkingLotGateOutputs OpenOutput()
        {
            ParkingLotOutput output = new ParkingLotOutput(true, false, true, false, false);
            return output;
        }

        public static IParkingLotGateOutputs InitialOutput()
        {
            ParkingLotOutput output = new ParkingLotOutput(false, false, false, false, true);
            return output;
        }
    }
}
