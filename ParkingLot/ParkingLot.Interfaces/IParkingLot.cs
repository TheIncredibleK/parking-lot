namespace ParkingLot
{
    public interface IParkingLot
    {
        /// <summary>
        /// Creates and initializes an instance of a parking lot gate to be used as the entry gate.
        /// </summary>
        /// <returns>Entry Gate or null on error</returns>
        IParkingLotGate InitEntryGate();

        /// <summary>
        /// Creates and initializes an instance of a parking lot gate to be used as the entry gate.
        /// </summary>
        /// <returns>Exit Gate or null on error</returns>
        IParkingLotGate InitExitGate();
    }
}
