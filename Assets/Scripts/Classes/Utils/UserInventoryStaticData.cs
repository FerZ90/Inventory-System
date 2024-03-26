using System.Collections.Generic;

public static class UserInventoryStaticData
{
    private static InventoryModel _userInventory;
    public static InventoryModel UserInventory => _userInventory;

    static UserInventoryStaticData()
    {
        _userInventory = new InventoryModel();
    }   
}
