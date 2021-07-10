using System;
using ParkingLot.StateMachine.States;

namespace ParkingLot.StateMachine
{
    public class ParkingLotStateMachine
    {
       public StateContext Context { get; private set; }

        public ParkingLotStateMachine(StateContext initialStateContext)
        {
            Context = initialStateContext;
        }

        public IParkingLotGateOutputs AcceptMessage(Command command)
        {
            Context = Context.CurrentState.AdjustState(command);
            return Context.Result;
        }
    }
}
