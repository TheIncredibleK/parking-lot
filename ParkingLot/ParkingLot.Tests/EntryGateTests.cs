using System;
using System.Collections.Generic;
using NUnit.Framework;
using ParkingLot.StateMachine;
using ParkingLot.Main.ParkingLotGates;
using ParkingLot.Main;
using ParkingLot.IO.ParkingLotIO;
namespace ParkingLot.Tests
{
    [TestFixture]
    public class EntryGateTests
    {
        public IList<string> AuthorisedDrivers;
        public IList<string> CurrentLicensePlates;
        ParkingLotManager PLotManager;

        [SetUp]
        public void SetUp()
        {
            AuthorisedDrivers = new List<string>
            {
                "1",
                "2",
                "3",
            };

            CurrentLicensePlates = new List<string>();
            PLotManager = new ParkingLotManager(CurrentLicensePlates, AuthorisedDrivers, 2);
        }

        // Security Sensor Tests
        [Test]
        public void RunCycle_InInitialStateButSecuritySensorTriggers_OutPutSaysStop()
        {
            var entryGate = PLotManager.InitEntryGate();
            var input = new ParkingLotInput(false, false, true, false, "","");
            var output = (ParkingLotOutput)entryGate.RunCycle(input);

            Assert.IsNotNull(output);
            Assert.IsTrue(output.RedLight);
            Assert.IsFalse(output.CloseGate);
            Assert.IsFalse(output.OpenGate);
            Assert.IsFalse(output.GreenLight);
            Assert.IsFalse(output.YellowLight);

        }

        // ESTOP tests
        [Test]
        public void RunCycle_InInitialStateButRecieveEStop_OutPutSaysStop()
        {
            var entryGate = PLotManager.InitEntryGate();
            var input = new ParkingLotInput(false, false, false, true, "", "");
            var output = (ParkingLotOutput)entryGate.RunCycle(input);

            Assert.IsNotNull(output);
            Assert.IsTrue(output.RedLight);
            Assert.IsFalse(output.CloseGate);
            Assert.IsFalse(output.OpenGate);
            Assert.IsFalse(output.GreenLight);
            Assert.IsFalse(output.YellowLight);
        }

        // Gate Fully Closed / Open Tests
        [Test]
        public void RunCycle_InInitialStateAndRecieveGateFullyClosed_OutPutSaysClosed()
        {
            var entryGate = PLotManager.InitEntryGate();
            var input = new ParkingLotInput(false, true, false, false, "", "");
            var output = (ParkingLotOutput)entryGate.RunCycle(input);

            Assert.IsNotNull(output);
            Assert.IsTrue(output.RedLight);
            Assert.IsFalse(output.CloseGate);
            Assert.IsFalse(output.OpenGate);
            Assert.IsFalse(output.GreenLight);
            Assert.IsFalse(output.YellowLight);
        }

        // Valid Vehicle Tests
        [Test]
        public void RunCycle_InInitialStateAndRecieveValidVehicle_MoveToOpeningState()
        {
            var entryGate = PLotManager.InitEntryGate();
            var input = new ParkingLotInput(false, false, false, false, "1", "license_plate");
            var output = (ParkingLotOutput)entryGate.RunCycle(input);

            Assert.IsNotNull(output);
            Assert.IsFalse(output.RedLight);
            Assert.IsFalse(output.CloseGate);
            Assert.IsTrue(output.OpenGate);
            Assert.IsFalse(output.GreenLight);
            Assert.IsTrue(output.YellowLight);
        }


        // Unregistered Vehicle Tests
        [Test]
        public void RunCycle_InInitialStateAndRecieveUnRegisteredId_RemainClosed()
        {
            var entryGate = PLotManager.InitEntryGate();
            var input = new ParkingLotInput(false, false, false, false, "unregistered_vehicle", "license_plate");
            var output = (ParkingLotOutput)entryGate.RunCycle(input);

            Assert.IsNotNull(output);
            Assert.IsTrue(output.RedLight);
            Assert.IsFalse(output.CloseGate);
            Assert.IsFalse(output.OpenGate);
            Assert.IsFalse(output.GreenLight);
            Assert.IsFalse(output.YellowLight);
        }

        // Max Vehicles Breached Test
        [Test]
        public void RunCycle_InInitialStateAndBreachMaxAllowedVehciles_CloseForSecondVehicle()
        {
            var entryGate = PLotManager.InitEntryGate();
            var input = new ParkingLotInput(false, false, false, false, "1", "license_plate");
            var output = (ParkingLotOutput)entryGate.RunCycle(input);
            var inputOfSecondVehicle = new ParkingLotInput(false, false, false, false, "2", "another_license_plate");
            var outputForSecondVehicle = (ParkingLotOutput)entryGate.RunCycle(inputOfSecondVehicle);
            var inputOfThirdVehicle = new ParkingLotInput(false, false, false, false, "3", "third_license_plate");
            var outputForThirdVehicle = (ParkingLotOutput)entryGate.RunCycle(inputOfThirdVehicle);

            Assert.IsNotNull(output);
            Assert.IsTrue(output.OpenGate);
            Assert.IsTrue(outputForSecondVehicle.OpenGate);
            Assert.IsTrue(outputForThirdVehicle.CloseGate);
        }
    }
}
