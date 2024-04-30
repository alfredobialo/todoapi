using asom.lib.core.util;

namespace asom.effectiv.inventory.core.items;
public class InventoryItem
{
    public string?  Name { get; set; }
    public string?  Description { get; set; }
    public Money BasePrice { get; set;}
    public Money CostPrice { get; set;}
    public string PurchaseAccountId { get; set; }
    public string SalesAccountId { get; set; }
    //Cost Of Goods AccountId
    public string CogAccountId { get; set; }
    public string GroupId { get; set; }
    public string GroupTag { get; set; }
    public bool IsService { get; set; }
    public string OrgId { get; set; }
    public bool  IsEnabled { get; set; }
}
