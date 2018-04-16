using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage_Client
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Pen ", Description="this Color is black, made in  ." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Book ", Description="The book tells the story of a love story，Single man, you need it ." +
                        "Allergen Gluten, Eggs, Peanuts & Nuts Gluten Free "  },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Diet Coke", Description=" this drink has not the sugar, wake away fat" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "macbook", Description="this is a kind of laptop from apple company. Good performance and good design" },
               
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
