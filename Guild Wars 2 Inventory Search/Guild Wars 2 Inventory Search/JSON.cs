using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guild_Wars_2_Inventory_Search
{
    public class Item
    {
        public int id { get; set; }
        public int count { get; set; }
        public List<int> upgrades { get; set; }
    }

    public class Bag
    {
        public int id { get; set; }
        public int size { get; set; }
        public List<Item> inventory { get; set; }
    }

    public class RootObject
    {
        public List<Bag> bags { get; set; }
    }
}
