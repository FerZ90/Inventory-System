using System.Collections.Generic;
using UnityEngine;

public class InventoryPresenter
{
    private UserInventoryViewModel _viewmodel;
    private ISpriteConverter _spriteConverter;

    public InventoryPresenter(ISpriteConverter spriteConverter, UserInventoryViewModel viewModel)
    {     
        _viewmodel = viewModel;
        _spriteConverter = spriteConverter;

        GlobalEvents.GetUserInventory += OnGetUserInventory; 
    }

    public void OnGetUserInventory(BackendInventoryModel userInventory)
    {
        _viewmodel.UserInventory.Value = ConvertInventoryToView(userInventory);
    }

    private InventoryModel ConvertInventoryToView(BackendInventoryModel userInventory)
    {
        var inventoryModel = new InventoryModel()
        {
            Items = ConvertInventoryItems(userInventory.Items)
        };

        return inventoryModel;
    }

    //public void OnAddItem(BackendItemModel backendItem)
    //{
    //    UserInventoryStaticData.AddItem(backendItem);
    //    _viewmodel.UserItems.Value = ConvertInventoryToView();
    //}

    private List<ItemModel> ConvertInventoryItems(List<BackendItemModel> backendInventoryItems)
    {
        List<ItemModel> items = new List<ItemModel>();

        foreach (var item in backendInventoryItems)
        {
            items.Add(new ItemModel()
            {
                name = item.name,
                background = _spriteConverter.ConvertItemBackground(item.id),
                icon = _spriteConverter.ConvertItemIcon(item.id),
                amount = item.amount
            });
        }

        return items;
    }

    ~InventoryPresenter()
    {
        GlobalEvents.GetUserInventory -= OnGetUserInventory;
    }
}
