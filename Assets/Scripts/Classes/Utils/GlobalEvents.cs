
public static class GlobalEvents
{ 
    public delegate void GetUserInventoryDelegate(BackendInventoryModel userInventory); 
    public static event GetUserInventoryDelegate GetUserInventory; 

    public static void RaiseGetUserInventory(BackendInventoryModel userInventory)
    {
        GetUserInventory.Invoke(userInventory);
    }
}
