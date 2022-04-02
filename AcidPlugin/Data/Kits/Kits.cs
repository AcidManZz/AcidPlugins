using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcidPlugin.Data.Kits
{
    [Serializable]
    public class Kits
    {
        public List<Kit> KitList { get; set; } = new List<Kit>();

        
    }
    [Serializable]
    public class Kit
    {
        public string Name { get; set; }
        public string Description { get; set; }

        
        [Serializable]
        public class Items
        {
            public List<Item> ItemList { get; set; } = new List<Item>();
        }
        [Serializable]
        public class Item
        {
            public string Name { get; set; }
            public string Id { get; set; }

            public Item() { }
            public Item(string Name, string Id)
            {
                this.Name = Name;
                this.Id = Id;
            }
        }
        public Kit() { }
        public Kit(string Name, string Description, List<Item> Items)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
    
}
