
public class InventoryController
{
    private UserInventoryViewModel _viewmodel;
    private IUserInventoryDataManager _userInventoryDataManager;

    public InventoryController(UserInventoryViewModel viewModel, IUserInventoryDataManager userInventoryDataManager)
    {
        _viewmodel = viewModel;
        _userInventoryDataManager = userInventoryDataManager;
        _viewmodel.OnGetUserInventory.AddListener(GetUserInventory);
    }

    public async void GetUserInventory()
    {
        var userInventory = await _userInventoryDataManager.GetUserInventory();
        GlobalEvents.RaiseGetUserInventory(userInventory);
    }
 

    //private void OnItemAdd(ItemModel item)
    //{ 
    //    SimulateBackendLogic(item);
    //}

    //private async void SimulateBackendLogic(ItemModel item)
    //{
    //    await Task.Delay(TimeSpan.FromSeconds(2));

    //    BackendItemModel backendItem = new BackendItemModel()
    //    {
    //        id = item.id,
    //        name = item.name,
    //        amount = item.amount
    //    };

    //    GlobalEvents.RaiseAddItemEvent(backendItem);     
    //}
}
