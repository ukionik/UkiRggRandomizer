using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Tests;

public class WheelTest
{
    private readonly List<WheelItem> _items = new()
    {
        new SimpleWheelItem("1. Battletoads"),
        new SimpleWheelItem("2. Contra"),
        new SimpleWheelItem("3. Darkwing Duck"),
        new SimpleWheelItem("4. Battletoads & Double Dragon"),
        new SimpleWheelItem("5. Double Dragon II"),
        new SimpleWheelItem("6. Felix The Cat"),
        new SimpleWheelItem("7. Mega Man 2"),
        new SimpleWheelItem("8. DuckTales"),
        new SimpleWheelItem("9. The Legend of Zelda"),
        new SimpleWheelItem("10. The Guardian Legend"),
        new SimpleWheelItem("11. Adventure Island"),
        new SimpleWheelItem("12. Blaster Master"),
        new SimpleWheelItem("13. Castlevania"),
        new SimpleWheelItem("14. Jungle Book"),
        new SimpleWheelItem("15. The Little Mermaid"),
        new SimpleWheelItem("16. Donkey Kong"),
        new SimpleWheelItem("17. Final Fantasy"),
        new SimpleWheelItem("18. Super Mario Bros."),
        new SimpleWheelItem("19. New Ghostbusters II"),
        new SimpleWheelItem("20. Holy Diver"),
        new SimpleWheelItem("21. Lode Runner"),
        new SimpleWheelItem("22. Metroid"),
        new SimpleWheelItem("23. Monster In My Pocket"),
        new SimpleWheelItem("24. Ninja Gaiden"),
        new SimpleWheelItem("25. Power Blade 2"),
        new SimpleWheelItem("26. Tiny Toon Adventures"),
        new SimpleWheelItem("27. Teenage Mutant Ninja Turtles"),
        new SimpleWheelItem("28. Wai Wai World"),
        new SimpleWheelItem("29. Snake Rattle 'n Roll"),
        new SimpleWheelItem("30. Rockin' Kats")
    };

    [Test]
    public void ShuffleTest()
    {
        var wheelEngine = new WheelEngine(_items);
        wheelEngine.Shuffle();
        wheelEngine.WheelItems.ForEach(Console.WriteLine);
    }

    [Test]
    public void ScheduleTest()
    {
        var wheelEngine = new WheelEngine(_items);
        var schedule = wheelEngine.GenerateWheelSchedule(new WheelEngineParams(30));
        schedule.ForEach(Console.WriteLine);
    }
}