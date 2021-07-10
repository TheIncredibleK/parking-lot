using System;
namespace ParkingLot.StateMachine.MessageHandlers
{
    public enum CommandType
    {
        Undefined = 0,
        Invalid,
        UnSafe,
        RegisteredVehicleDetected,
        InvalidVehicleDetected,
        DuplicatedVehicleDetected,
        NoSpotsDetected,
        NothingDetected,
        FullyOpen,
        FullyClosed
    }
}
