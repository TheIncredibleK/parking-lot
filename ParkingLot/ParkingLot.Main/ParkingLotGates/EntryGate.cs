using System;
using ParkingLot.Main.ParkingLotGate;
using ParkingLot.StateMachine;
using ParkingLot.StateMachine.MessageHandlers;
using System.Collections.Generic;

namespace ParkingLot.Main.ParkingLotGates
{
    public class EntryGate : AbstractGate
    {
        public EntryGate(ParkingLotStateMachine entryStateMachine, IList<string> currentlyParkedLicensePlates, IList<string> authorisedDriverIds, int maxSpots)
            : base(entryStateMachine, currentlyParkedLicensePlates, authorisedDriverIds, maxSpots)
        {
        }

        protected override Command GetCommandOfGateType(IParkingLotGateInputs inputs)
        {
            var isDriverAuthorised = CheckIfDriverIsAuthorised(inputs.DriverId);
            var isLicenseAlreadyParking = CheckIfLicenseExistsAlready(inputs.LicensePlate);
            var spotAvailable = CurrentlyParkedLicensePlates.Count < MaxSpots;

            if(isLicenseAlreadyParking == false)
            {
                CurrentlyParkedLicensePlates.Add(inputs.LicensePlate);
            }

            

            return InputToCommandConverter.ProcessInput(inputs, isDriverAuthorised, isLicenseAlreadyParking, spotAvailable);
        }
    }
}
