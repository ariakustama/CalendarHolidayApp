using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarHolidayApp.ViewComponents
{
    public class UserInfoViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.User = "Admin";
            return View();
        }
    }
}
