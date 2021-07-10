using ParkingLot.Main.ParkingLotGate;
using ParkingLot.StateMachine;
using ParkingLot.StateMachine.MessageHandlers;
using System.Collections.Generic;

namespace ParkingLot.Main.ParkingLotGates
{
    public class ExitGate : AbstractGate
    {
        public ExitGate(ParkingLotStateMachine exitStateMachine, IList<string> currentlyParkedLicensePlates, IList<string> authorisedDriverIds, int maxSpots)
            : base(exitStateMachine, currentlyParkedLicensePlates, authorisedDriverIds, maxSpots)
        {
        }

        protected override Command GetCommandOfGateType(IParkingLotGateInputs inputs)
        {
            var isDriverAuthorised = CheckIfDriverIsAuthorised(inputs.DriverId);
            var isLicenseAlreadyParking = CheckIfLicenseExistsAlready(inputs.LicensePlate);

            if (isLicenseAlreadyParking == true)
            {
                CurrentlyParkedLicensePlates.Remove(inputs.LicensePlate);
            }

            //Always passing in true here simply because there's no reason not to, if it is leaving the park it doesn't matter regarding a spot available.
            return InputToCommandConverter.ProcessInput(inputs, isDriverAuthorised, isLicenseAlreadyParking, true);
        }
    }
}
