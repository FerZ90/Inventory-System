using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DataManager : IUserInventoryDataManager
{
    public async Task<BackendInventoryModel> GetUserInventory()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        var userInventory = new BackendInventoryModel();

        var items = new List<BackendItemModel>();

        int randomItemsAmount = UnityEngine.Random.Range(1, 15);

        for (int i = 0; i < randomItemsAmount; i++)
        {
            items.Add(FakeData.GetRandomItem());
        }

        userInventory.Items = items;

        return userInventory;
    }

   
}

public interface IUserInventoryDataManager
{
    Task<BackendInventoryModel> GetUserInventory();
}
