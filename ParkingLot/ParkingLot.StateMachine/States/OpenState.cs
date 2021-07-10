using System;
using ParkingLot.StateMachine.MessageHandlers;
using ParkingLot.IO;

namespace ParkingLot.StateMachine.States
{
    /// <summary>
    /// State for when the Gate is fully Open
    /// </summary>
    public class OpenState : AbstractState
    {
        public OpenState()
        {
        }

        public override StateContext AdjustState(Command command)
        {
            switch (command.CommandType)
            {
                case CommandType.UnSafe:
                    NewState = new StopState();
                    NewOutput = ParkingLotOutputProvider.InitialOutput();
                    return new StateContext(NewState, command, NewOutput);
                case CommandType.RegisteredVehicleDetected:
                    NewState = new OpeningState();
                    NewOutput = ParkingLotOutputProvider.OpeningOutput();
                    return new StateContext(NewState, command, NewOutput);
                case CommandType.Invalid:
                case CommandType.InvalidVehicleDetected:
                case CommandType.DuplicatedVehicleDetected:
                case CommandType.NothingDetected:
                case CommandType.NoSpotsDetected:
                    NewState = new ClosedState();
                    NewOutput = ParkingLotOutputProvider.ClosedOutput();
                    return new StateContext(NewState, command, NewOutput);
                case CommandType.FullyOpen:
                    NewState = new OpenState();
                    NewOutput = ParkingLotOutputProvider.OpenOutput();
                    return new StateContext(NewState, command, NewOutput);
                case CommandType.FullyClosed:
                default:
                    // Here I am assuming a failure state (such as recieving a command of an unknwon command type), we
                    // would want the system to fail out. Otherwise I could simply return the closed state.
                    throw new ArgumentOutOfRangeException($"Got a command type of {command}, this is unexpected behaviour");
            }
        }
    }
}
