using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Repository
{
    public class ItemRepository
    {
        private readonly List<Item> _items = new List<Item>();

        public ItemRepository()
        {
            // Seed some initial data
            _items.Add(new Item { Id = 1, Name = "Item1", Description = "Description1" });
            _items.Add(new Item { Id = 2, Name = "Item2", Description = "Description2" });
        }

        public IEnumerable<Item> GetAll() => _items;

        public Item GetById(int id) => _items.FirstOrDefault(i => i.Id == id);

        public void Add(Item item)
        {
            item.Id = _items.Max(i => i.Id) + 1;
            _items.Add(item);
        }

        public void Update(Item item)
        {
            var index = _items.FindIndex(i => i.Id == item.Id);
            if (index != -1)
            {
                _items[index] = item;
            }
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }
    }
}
