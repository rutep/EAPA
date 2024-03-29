﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Areas.Identity.Pages.Account.Admin
{
    public static class ManageAdminPages
    {
        public static string ActivePageKey => "ActivePage";
        public static string ChangePassword => "ChangePassword";
        public static string ManageUsers => "ManageUsers";
        public static string Index => "Index";
        public static string Events => "Events";
        public static string Grants => "Grants";

        public static string Votes => "Votes";
        public static string BoardMembers => "BoardMembers";



        public static string IndexNavClass(ViewContext viewContext) => PageAdminClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageAdminClass(viewContext, ChangePassword);
        public static string ManageUsersNavClass(ViewContext viewContext) => PageAdminClass(viewContext, ManageUsers);
        public static string ManageEventsNavClass(ViewContext viewContext) => PageAdminClass(viewContext, Events);
        public static string ManageGrantsNavClass(ViewContext viewContext) => PageAdminClass(viewContext, Grants);
        public static string ManageVotesNavClass(ViewContext viewContext) => PageAdminClass(viewContext, Votes);
        public static string ManageBoardMembersNavClass(ViewContext viewContext) => PageAdminClass(viewContext, BoardMembers);
        public static string PageAdminClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
