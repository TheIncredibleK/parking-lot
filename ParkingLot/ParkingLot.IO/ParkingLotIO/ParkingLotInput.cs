using System;
namespace ParkingLot.IO.ParkingLotIO
{
    public struct ParkingLotInput : IParkingLotGateInputs
    {
        public bool GateFullyOpen { get; set; }

        public bool GateFullyClosed { get; set; }

        public bool SafetySensor { get; set; }

        public bool EStop { get; set; }

        public string DriverId { get; set; }

        public string LicensePlate { get; set; }

        public ParkingLotInput(bool gateFullyOpen, bool gateFullyClosed, bool safetySensor, bool estop, string driverId, string licensePlate)
        {
            GateFullyOpen = gateFullyOpen;
            GateFullyClosed = gateFullyClosed;
            SafetySensor = safetySensor;
            EStop = estop;
            DriverId = driverId;
            LicensePlate = licensePlate;
        }
    }
}
