﻿using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Service;

public interface IWheelService
{
    WheelSimulationModel SimulateWheel();
    void Roll(WheelRollRequest request);
}