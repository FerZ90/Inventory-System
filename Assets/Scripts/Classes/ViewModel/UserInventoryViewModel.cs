using UnityEngine.Events;

public class UserInventoryViewModel
{
    public readonly ReactiveData<InventoryModel> UserInventory = new ReactiveData<InventoryModel>();
    public readonly UnityEvent OnGetUserInventory = new UnityEvent();
    
}
