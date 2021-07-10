using System;
namespace ParkingLot.StateMachine.MessageHandlers
{
    public static class InputToCommandConverter
    {
        public static Command ProcessInput(IParkingLotGateInputs input, bool isDriverAuth, bool isLicenseDupe, bool spotAvailable) 
        {
            if (InputToCommandConverter.AreInpusSafe(input) == false)
            {
                return new Command(CommandType.UnSafe);
            }

            if(isDriverAuth == false)
            {
                return new Command(CommandType.InvalidVehicleDetected);
            }

            if(isLicenseDupe)
            {
                return new Command(CommandType.DuplicatedVehicleDetected);
            }

            if(input.GateFullyClosed)
            {
                return new Command(CommandType.FullyClosed);
            }

            if(input.GateFullyOpen)
            {
                return new Command(CommandType.FullyOpen);
            }

            if(spotAvailable == false)
            {
                return new Command(CommandType.NoSpotsDetected);
            }

            if(string.IsNullOrWhiteSpace(input.DriverId) == false && string.IsNullOrWhiteSpace(input.LicensePlate) == false)
            {
                return new Command(CommandType.RegisteredVehicleDetected);
            }

            return new Command(CommandType.NothingDetected);
        }

        private static bool AreInpusSafe(IParkingLotGateInputs input)
        {
            if (input.EStop)
            {
                return false;
            }

            if (input.SafetySensor)
            {
                return false;
            }
            return true;
        }

    }
}
