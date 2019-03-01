using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Areas.Identity.Pages.Account.Admin
{
    public class ManageAdminPages
    {
        public static string ChangePassword => "ChangePassword";
        public static string ManageUsers => "ManageUsers";
        public static string Index => "Index";

        public static string IndexNavClass(ViewContext viewContext) => PageAdminClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageAdminClass(viewContext, ChangePassword);
        public static string ManageUsersNavClass(ViewContext viewContext) => PageAdminClass(viewContext, ManageUsers);
        public static string PageAdminClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
