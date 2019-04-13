using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Validation.Pages
{
    public class IndexModel : PageModel
    {
        public string Message;
        public void OnGet()
        {
            var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(20)
            };
            Response.Cookies.Append("JamesMidtermCookie", "FirstCookie", cookieOptions);

            if (Request.Cookies["JamesMidtermCookie"] != null)
            {
                Message = "Welcome back";
            }

            else Message = "Welcome";
        }
    }
}
