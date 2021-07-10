using System;
using ParkingLot.StateMachine.MessageHandlers;
using ParkingLot.StateMachine.States;

namespace ParkingLot.StateMachine
{
    public class StateContext
    {
        public AbstractState CurrentState { get; }
        public Command Command { get; }
        public IParkingLotGateOutputs Result { get; }

        public StateContext(AbstractState state, Command command, IParkingLotGateOutputs result)
        {
            if(state == null)
            {
                throw new ArgumentNullException($"Cannot have a context with a null state");
            }

            if(command == null)
            {
                throw new ArgumentNullException($"Cannot have a context with a null command");
            }

            if(result == null)
            {
                throw new ArgumentNullException($"Cannot have a context with a null result");
            }

            CurrentState = state;
            Command = command;
            Result = result;
        }
    }
}
