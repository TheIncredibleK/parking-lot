using System;

namespace ParkingLot.StateMachine.States
{
    public abstract class AbstractState
    {
        protected AbstractState NewState;
        protected IParkingLotGateOutputs NewOutput;
        public AbstractState()
        {
        }

        /// <summary>
        /// Takes in a command, proccesses this and returns a new context for the State Machine.
        /// </summary>
        /// <param name="command"> Command, with a specific type.</param>
        /// <returns> StateContext, used by state machine, and is the accessor to the state machine for commands</returns>
        public abstract StateContext AdjustState(Command command);
    }
}
