using System;
using ParkingLot;
namespace ParkingLot.IO.ParkingLotIO
{
    public struct ParkingLotOutput : IParkingLotGateOutputs
    {
        public bool OpenGate { get; set; }
        public bool CloseGate { get; set; }
        public bool GreenLight { get; set; }
        public bool YellowLight { get; set; }
        public bool RedLight { get; set; }

        public ParkingLotOutput(bool openGate, bool closeGate, bool greenLight, bool yellowLight, bool redLight)
        {
            OpenGate = openGate;
            CloseGate = closeGate;
            GreenLight = greenLight;
            YellowLight = yellowLight;
            RedLight = redLight;
        }

  
    }
}
