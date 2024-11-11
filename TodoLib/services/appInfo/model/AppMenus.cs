namespace TodoLib.services.appInfo.model;

public class AppMenu
{
    public string? Id { get; set; }
    public string? RoutePath { get; set; }
    public int SortOrder { get; set; } = 0;
    public string? Name { get; set; }
    public bool IsEnabled { get; set; } = true;
    
    public string Description { get; set; } = string.Empty;
    public List<AppMenu> SubMenus { get; set; } = new List<AppMenu>();
    public bool HasSubMenu => SubMenus.Any();

    public static List<AppMenu> GetUserMenus()
    {
        // Return Menus based on user's Permission
        return new List<AppMenu>()
        {
            new()
            {
                Id = "dashboard", SortOrder = 0, Name = "Dashboard", Description = "Dashboard Summary", 
                SubMenus = new List<AppMenu>()
                {
                    new(){ Id = "todo-app",Name = "Todo Task", Description = "Simple Todo Task"},
                    new(){ Id = "counter-app",Name = "Counter Demo", Description = "Signal Store Counter App", SortOrder = 1},
                    new(){ Id = "login-page",Name = "Login UI", Description = "Simple Login Page", SortOrder = 2},
                }
                    
            },
            new()
            {
                Id = "sales", SortOrder = 1, Name = "Sales", Description = "Sales Management", 
                SubMenus = new List<AppMenu>()
                {
                    new(){ Id = "sales-order",Name = "Sales Orders", Description = "All Sales Orders"},
                    new(){ Id = "new-sales-order",Name = "New Sales Order", Description = "New Sales Order", SortOrder = 1},
                    new(){ Id = "new-sales-invoice",Name = "New Invoice", Description = "New Sales Invoice", SortOrder = 2},
                    new(){ Id = "receive-sales-payment",Name = "Receive Payment", Description = "Receive Payment", SortOrder = 3},
                }
                    
            },
            new()
            {
                Id = "purchases", SortOrder = 2, Name = "Purchases", Description = "Purchase Management", 
                SubMenus = new List<AppMenu>()
                {
                    new(){ Id = "purchase-order",Name = "Purchase Orders", Description = "All Purchase Orders"},
                    new(){ Id = "new-purchase-order",Name = "New Purchase Order", Description = "New Purchase Order", SortOrder = 1},
                    new(){ Id = "new-purchase-invoice",Name = "New Invoice", Description = "New Purchase Invoice", SortOrder = 2},
                    new(){ Id = "make-purchase-payment",Name = "Make Payment", Description = "Make Payment", SortOrder = 3},
                }
                    
            },
            new()
            {
                Id = "inventory", SortOrder = 3, Name = "Inventory", Description = "Inventory Management", 
                SubMenus = new List<AppMenu>()
                {
                    new(){ Id = "inventory",Name = "Product List", Description = "All Products"},
                    new(){ Id = "new-inventory",Name = "New Product", Description = "New Product", SortOrder = 1},
                    new(){ Id = "inventory-category",Name = "Categories", Description = "Inventory Categories", SortOrder = 2},
                    new(){ Id = "inventory-stock",Name = "Inventory Stock", Description = "Inventory Stock Record", SortOrder = 3},
                    new(){ Id = "inventory-price-adjustment",Name = "Adjust Price", Description = "Manage Inventory Price", SortOrder = 4},
                }
                    
            },
            new()
            {
                Id = "customers", SortOrder = 4, Name = "Customers", Description = "CRM", 
                SubMenus = new List<AppMenu>()
                {
                    new(){ Id = "customer-list",Name = "Customer List", Description = "Customer List"},
                    new(){ Id = "new-customer",Name = "New Customer", Description = "New Customer", SortOrder = 1},
                    new(){ Id = "new-contact",Name = "New Contact", Description = "New Contact", SortOrder = 2}
                }
                    
            },
            new()
            {
                Id = "financial-account", SortOrder = 5, Name = "Financials", Description = "Financial Accounting", 
                SubMenus = new List<AppMenu>()
                {
                    new(){ Id = "chart-of-account",Name = "Chat Of Account", Description = "All Financial Accounts"},
                    /*new(){ Id = "new-sales-order",Name = "New Sales Order", Description = "New Sales Order", SortOrder = 1},
                    new(){ Id = "new-sales-invoice",Name = "New Invoice", Description = "New Sales Invoice", SortOrder = 2},
                    new(){ Id = "receive-sales-payment",Name = "Receive Payment", Description = "Receive Payment", SortOrder = 3},*/
                }
                    
            },
            new()
            {
                Id = "settings", SortOrder = 6, Name = "Settings", Description = "Settings Management", 
                SubMenus = new List<AppMenu>()
                {
                    new(){ Id = "change-password",Name = "Change Password", Description = "Change Password"},
                    new(){ Id = "profile-detail",Name = "My Profile", Description = "My Profile", SortOrder = 1},
                    /*new(){ Id = "new-sales-invoice",Name = "New Invoice", Description = "New Sales Invoice", SortOrder = 2},
                    new(){ Id = "receive-sales-payment",Name = "Receive Payment", Description = "Receive Payment", SortOrder = 3},*/
                }
                    
            },
            
        };
        
    }
}
