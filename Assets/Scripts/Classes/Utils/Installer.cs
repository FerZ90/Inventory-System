using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private InventoryView inventoryView;

    private DataManager _dataManager;

    private void Awake()
    {
        _dataManager = new DataManager();
        var userInventoryViewModel = new UserInventoryViewModel();
        var inventoryPresenter = new InventoryPresenter(new SpriteConverter(), userInventoryViewModel);
        var inventoryController = new InventoryController(userInventoryViewModel, _dataManager);

        inventoryView.Configure(userInventoryViewModel);
    }
}
