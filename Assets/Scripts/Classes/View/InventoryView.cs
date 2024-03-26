using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour, IItemListener
{
    [SerializeField] Transform parent;
    [SerializeField] Item itemPrefab;

    private List<Item> _uiItems = new List<Item>();
    private UserInventoryViewModel _viewModel;

    public void Configure(UserInventoryViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    private void Start()
    {
        _viewModel.UserInventory.Observe(FillInventory);       

        OnGetUserInventory(); // Simulate get user inventory
    }

    public void FillInventory(InventoryModel inventory)
    {
        if (inventory == null || inventory.Items == null)
            return;
  

        foreach (var item in _uiItems)
        {
            Destroy(item.gameObject);
        }

        _uiItems.Clear();

        foreach (var item in inventory.Items)
        {
            var uiItem = Instantiate(itemPrefab, parent);
            uiItem.OnItemClickEvent.AddListener(() => OnItemClick(uiItem));
            uiItem.Setup(item);
        }
    }

    public void OnItemClick(Item itemModel)
    {
        _uiItems.Remove(itemModel);
        Destroy(itemModel.gameObject);       
    }

    public void OnGetUserInventory()
    {
        _viewModel.OnGetUserInventory.Invoke();
    }

    private void OnDestroy()
    {
        _viewModel.UserInventory.StopObserving(FillInventory);      
    }
}
