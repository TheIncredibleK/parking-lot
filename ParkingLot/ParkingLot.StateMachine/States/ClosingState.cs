using System;
using ParkingLot.IO;
using ParkingLot.StateMachine.MessageHandlers;
namespace ParkingLot.StateMachine.States
{
    /// <summary>
    /// State for when the Gate is in the process of closing
    /// </summary>
    public class ClosingState : AbstractState
    {
        public ClosingState()
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
                    NewState = new ClosingState();
                    NewOutput = ParkingLotOutputProvider.OpeningOutput();
                    return new StateContext(NewState, command, NewOutput);
                case CommandType.FullyClosed:
                    NewState = new ClosedState();
                    NewOutput = ParkingLotOutputProvider.ClosedOutput();
                    return new StateContext(NewState, command, NewOutput);
                case CommandType.FullyOpen:
                default:
                    // Here I am assuming a failure state (such as recieving a command of an unknwon command type), we
                    // would want the system to fail out. Otherwise I could simply return the closed state.
                    throw new ArgumentOutOfRangeException($"Got a command type of {command}, this is unexpected behaviour");
            }
        }
    }
}
