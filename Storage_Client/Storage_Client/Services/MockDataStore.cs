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
                new Item { Id = Guid.NewGuid().ToString(), Text = "Pan-Fried Dumplings", Description="A Delicious traditional crispy dumplin" +
                        " stuffed with pork or minced beef and vegetables Allergens: Gluten, Eggs, Soybeans, Celery & Sesame seeds."  + "\r\n" + "\r\n" + "\r\n" + " €5.00"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Crispy Chilli Chicken", Description="Crispy shredded chicken seasoned with chilli salt and pepper." +
                        "Allergen Gluten, Eggs, Peanuts & Nuts Gluten Free "  + "\r\n" + "\r\n" + "\r\n" + "€7.00"  },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Spice Bag", Description="Shredded Chicken and Chips seasoned with our special blend of salt and chilli sauce.Allergens:" +
                        " Gluten, Eggs, Peanuts & Nuts  " + "\r\n" + "\r\n"  + "\r\n"+ " €7.00" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Veggie Mixed Salad", Description="A Fresh vegan salad mixed with greens topped with falafel and your choice of sauce." +
                        "Allergens: Gluten, Peanuts & Nuts, soybeans, Celery, Sesame seeds." + "\r\n" + "\r\n"  + "\r\n"+ " €5.00" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Amber-Fire Szchuan Style", Description="A Delicious Asian dish stir fired with mixed vegetables, fresh garlic, cumin and spicy chilli" +
                        "Allergens: Gluten, soybeans, Sesame seeds." + "\r\n" + "\r\n"  + "\r\n"+ " €10.00" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Burgers", Description="Our handmade crispy, warm flat bread buns are prepared with your choice of fillings." +
                        "Allergens: Gluten, Soybeans, Celery & Sesame Seeds." + "\r\n" + "\r\n"  + "\r\n"+ " €5.00"},
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
