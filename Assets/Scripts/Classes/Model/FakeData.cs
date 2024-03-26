using System.Collections.Generic;

public static class FakeData
{
    private static System.Random random = new System.Random();
    private static List<string> _itemNames = new List<string>()
        {
            "Apple",
            "TV",
            "Phone",
            "Key",
            "Bottle",
            "Photo",
            "Ring",
            "Penn"
        };

    public static BackendItemModel GetRandomItem()
    {
        var randomIndex = random.Next(0, _itemNames.Count);

        return new BackendItemModel()
        {
            id = randomIndex,
            name = _itemNames[randomIndex],
            amount = random.Next(1, 8)
        };
    }
  
}
