namespace DynamicMenubar.Models
{
    public class MenusModel
    {
        public long MenuId { get; set; }
        public string? MenuName { get; set; }
        public long ParentMenuId { get; set; }
    }
    public class ActionModel
    {
        public long Id { get; set; }
        public string? ActionName { get; set; }
        public bool IsSelected { get; set; }
    }
  

    public class NavigationItem
    {
        public long MenuId { get; set; }
        public string MenuName { get; set; }
        public long ParentMenuId { get; set; }
        public List<NavigationItem> Children { get; set; }
        public List<ActionModel> ActionList { get; set; }
    }

}
