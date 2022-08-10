using System.Collections.Generic;
using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Service;

public interface IWheelService
{
    List<WheelItemSchedule> GenerateWheelSchedule();
    List<WheelItem> GetItems();
}