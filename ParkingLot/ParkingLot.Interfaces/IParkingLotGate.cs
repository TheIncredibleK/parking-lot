namespace ParkingLot
{
    public interface IParkingLotGate
    {
        /// <summary>
        /// Runs the control logic for the parking lot gate
        /// </summary>
        /// <param name="inputs">Inputs to be used on the current logic cycle</param>
        ///
        //NOTE: I removed the output requirement on the function, and changed it to return outputs
        IParkingLotGateOutputs RunCycle(IParkingLotGateInputs inputs);
    }
}
