using System;
using ParkingLot.Main.ParkingLotGates;
using ParkingLot.IO;
using ParkingLot.StateMachine;
using ParkingLot.StateMachine.States;
using System.Collections.Generic;

namespace ParkingLot.Main
{
    public class ParkingLotManager : IParkingLot
    {
        // Normally I'd use a cache wrapped class around these lists so we can control the access
        // But I'm not sure what the performance needs, nor the space needs of this system would be
        // Also, I'm taking time into consideration so for now, these remain as lists.
        public IList<string> CurrentlyParkedLicensePlates { get; private set; }
        public IList<string> AuthorisedDriverIds { get; private set; }
        public int MaxSpots { get; private set; }

        public ParkingLotManager(IList<string> currentlyParkedLicensePlates, IList<string> authorisedDrivers, int maxSpots)
        {
            if (currentlyParkedLicensePlates == null)
            {
                throw new ArgumentNullException("Cannot have a null list to track parked vehicles");
            }

            if(authorisedDrivers == null)
            {
                throw new ArgumentNullException("Cannot have a null list of authorised drivers");
            }

            CurrentlyParkedLicensePlates = currentlyParkedLicensePlates;
            AuthorisedDriverIds = authorisedDrivers;
            MaxSpots = maxSpots;
        }

        // Both of these below are making the potentially faulty assumption that the system always begins in a closed sate
        // If this is false, there's definitely a way to figure out initial state from the first input
        // For example if initial input is that the gate is fully open, we can infer the initial input
        // But I didn't want to over engineer this (and I believe I already have anyways)
        public IParkingLotGate InitEntryGate()
        {
            var initialCommand = Command.InitialCommand();
            var initialState = new ClosedState();
            var initialOutput = ParkingLotOutputProvider.InitialOutput();
            var initialStateContext = new StateContext(initialState, initialCommand, initialOutput);
            var entryStateMachine = new ParkingLotStateMachine(initialStateContext);
            var entryGate = new EntryGate(entryStateMachine, CurrentlyParkedLicensePlates, AuthorisedDriverIds, MaxSpots);
            return entryGate;
        }

        public IParkingLotGate InitExitGate()
        {
            var initialCommand = Command.InitialCommand();
            var initialState = new ClosedState();
            var initialOutput = ParkingLotOutputProvider.InitialOutput();
            var initialStateContext = new StateContext(initialState, initialCommand, initialOutput);
            var exitStateMachine = new ParkingLotStateMachine(initialStateContext);
            var exitGate = new ExitGate(exitStateMachine, CurrentlyParkedLicensePlates, AuthorisedDriverIds, MaxSpots);
            return exitGate;
        }
    }
}
