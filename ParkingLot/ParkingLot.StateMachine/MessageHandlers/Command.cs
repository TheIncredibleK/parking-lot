using System;
using ParkingLot.StateMachine.MessageHandlers;

namespace ParkingLot.StateMachine
{
    public class Command
    {
        public readonly CommandType CommandType;

        public Command(CommandType commandType)
        {
            if(commandType == CommandType.Undefined)
            {
                throw new ArgumentException("Cannot use an undefined Command Type");
            }

            CommandType = commandType;
        }

        public static Command InitialCommand()
        {
            return new Command(CommandType.NothingDetected);
        }
    }
}
