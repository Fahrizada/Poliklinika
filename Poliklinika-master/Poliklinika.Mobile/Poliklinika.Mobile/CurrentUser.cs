using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poliklinika.Mobile
{
    public static class CurrentUser
    {
        public static User User { get; set; }
        public static string JWT { get; set; }

        public static bool IsLogedIn()
        {
            if (User != null && JWT != null)
                return true;
            return false;
        }
    }
}
