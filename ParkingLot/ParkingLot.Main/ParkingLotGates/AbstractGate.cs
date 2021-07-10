using System;
using ParkingLot.StateMachine;
using System.Collections.Generic;
namespace ParkingLot.Main.ParkingLotGate
{
    public abstract class AbstractGate : IParkingLotGate
    {
        private ParkingLotStateMachine _stateMachine;
        public IList<string> CurrentlyParkedLicensePlates { get; private set; }
        public IList<string> AuthorisedDriverIds { get; private set; }
        public int MaxSpots { get; private set; }

        public AbstractGate(ParkingLotStateMachine stateMachine, IList<string> currentlyParkedLicensePlates, IList<string> authorisedDriverIds, int maxSpots)
        {
            if(stateMachine == null)
            {
                throw new ArgumentNullException("Cannot have a null for a gate");
            }

            _stateMachine = stateMachine;
            CurrentlyParkedLicensePlates = currentlyParkedLicensePlates;
            AuthorisedDriverIds = authorisedDriverIds;
            MaxSpots = maxSpots;
        }

        public IParkingLotGateOutputs RunCycle(IParkingLotGateInputs inputs)
        {
            Command command = GetCommandOfGateType(inputs);
            return _stateMachine.AcceptMessage(command);
        }

        protected bool CheckIfDriverIsAuthorised(string driverId)
        {
            return AuthorisedDriverIds.Contains(driverId);
        }

        protected bool CheckIfLicenseExistsAlready(string licensePlate)
        {
            return CurrentlyParkedLicensePlates.Contains(licensePlate);
        }

        protected abstract Command GetCommandOfGateType(IParkingLotGateInputs inputs);
    }
}
