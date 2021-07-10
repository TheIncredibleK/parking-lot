using System;
namespace ParkingLot.Main
{
    public struct Vehicle
    {
        public string DriverId { get; private set; }
        public string LicensePlate { get; private set; }

        public Vehicle(string driverId, string licensePlate)
        {
            if(string.IsNullOrWhiteSpace(driverId))
            {
                throw new ArgumentNullException($"Cannot have a null or empty {nameof(driverId)}, got {driverId}");
            }

            if (string.IsNullOrWhiteSpace(licensePlate))
            {
                throw new ArgumentNullException($"Cannot have a null or empty {nameof(licensePlate)}, got {licensePlate}");
            }

            DriverId = driverId;
            LicensePlate = licensePlate;
        }
    }
}

