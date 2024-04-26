using asom.lib.core;
using Microsoft.AspNetCore.Mvc;
using TodoLib.services.appInfo.model;

namespace TodoApi.Controller;

[Route("app-menu")]
public class AppUserFeaturesController :BaseController
{
    [HttpGet("")]
    public async Task<IActionResult> GetUserFeaturesMenus()
    {
        // Expect a valid user to be login
        // Menus are returned based on User Permission
        var data = new
        {
            menus = AppMenu.GetUserMenus(),
            notificationCount = 7
        };
        var response = CommandResponse<dynamic>.SuccessResponse("User App Features returned", data);
        return Ok(response);
    }
}
