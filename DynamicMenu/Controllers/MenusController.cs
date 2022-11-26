using DynamicMenubar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicMenubar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            List<ActionModel> ActionList = new List<ActionModel>()
{
    new ActionModel() { Id = 1, ActionName = "NoAction" },
    new ActionModel() { Id = 1, ActionName = "Create" },
    new ActionModel() { Id = 1, ActionName = "Edit" },
};
            List<MenusModel> AllMenuList = new List<MenusModel>()
{
    new MenusModel() { MenuId = 1, MenuName = "Google", ParentMenuId = -1 },
    new MenusModel() { MenuId = 2, MenuName = "Microsoft", ParentMenuId = -1 },
    new MenusModel() { MenuId = 3, MenuName = "Oracle", ParentMenuId = -1 },
    new MenusModel() { MenuId = 4, MenuName = "Gmail", ParentMenuId = 1 },
    new MenusModel() { MenuId = 5, MenuName = "Sheets", ParentMenuId = 1 },
    new MenusModel() { MenuId = 6, MenuName = "Adsense", ParentMenuId = 1 },
    new MenusModel() { MenuId = 7, MenuName = "Azure", ParentMenuId = 2 },
    new MenusModel() { MenuId = 8, MenuName = "SharePoint", ParentMenuId = 2 },
    new MenusModel() { MenuId = 9, MenuName = "Office", ParentMenuId = 2 },
    new MenusModel() { MenuId = 10, MenuName = "Java", ParentMenuId = 3 },
    new MenusModel() { MenuId = 11, MenuName = "Word", ParentMenuId = 9 },
    new MenusModel() { MenuId = 12, MenuName = "Excel", ParentMenuId = 9 },
    new MenusModel() { MenuId = 13, MenuName = "PowerPoint", ParentMenuId = 9 },
};
            var AllMenuList1 = AllMenuList;
            var navigationItems = AllMenuList1.Select(i => new NavigationItem { MenuId = i.MenuId, MenuName = i.MenuName, ParentMenuId = i.ParentMenuId }
).ToList();

            foreach (var i in navigationItems)
            {
                i.Children = navigationItems.Where(n => n.ParentMenuId == i.MenuId).ToList();
                i.ActionList = ActionList;
            }            

            var rootNavigationItems = navigationItems.Where(n => n.ParentMenuId == -1);
            var test = rootNavigationItems.ToList();
            return Ok(rootNavigationItems.ToList());
        }
    }
}
