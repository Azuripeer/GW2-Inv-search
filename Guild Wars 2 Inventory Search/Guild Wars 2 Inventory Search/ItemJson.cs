using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guild_Wars_2_Inventory_Search
{
    public class Attribute
{
    public string attribute { get; set; }
    public int modifier { get; set; }
}

public class InfusionSlot
{
    public List<string> flags { get; set; }
    public int item_id { get; set; }
}

public class Buff
{
    public int skill_id { get; set; }
    public string description { get; set; }
}

public class InfixUpgrade
{
    public List<Attribute> attributes { get; set; }
    public Buff buff { get; set; }

}

public class Details
{
    public string type { get; set; }
    public string weight_class { get; set; }
    public int defense { get; set; }
    public List<InfusionSlot> infusion_slots { get; set; }
    public InfixUpgrade infix_upgrade { get; set; }
    public int suffix_item_id { get; set; }
    public string secondary_suffix_item_id { get; set; }
    public int size { get; set; }
    public Boolean no_sell_or_sort { get; set; }
    public string description { get; set; }
    public int duration_ms { get; set; }
    public string unlock_type { get; set; }
    public int color_id { get; set; }
    public int recipe_id { get; set; }
    public int charges { get; set; }
    public List<string> flags { get; set; }
    public List<string> infusion_upgrade_flags { get; set; }
    public string suffix { get; set; }
    public List<string> bonuses { get; set; }
    public string damage_type { get; set; }
    public int min_power { get; set; }
    public int max_power { get; set; }


}

public class Name
{
    public string name { get; set; }
    public string description { get; set; }
    public string type { get; set; }
    public int level { get; set; }
    public string rarity { get; set; }
    public int vendor_value { get; set; }
    public int default_skin { get; set; }
    public List<string> game_types { get; set; }
    public List<string> flags { get; set; }
    public List<string> restrictions { get; set; }
    public int id { get; set; }
    public string icon { get; set; }
    public Details details { get; set; }
}
}
