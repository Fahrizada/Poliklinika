using System;
using System.Collections.Generic;
using System.Text;

namespace Poliklinika.Mobile
{
    public class IsLogedIn
    {
        public bool LogedIn { get; set; }
        public bool NotLogedIn { get; set; }

        public IsLogedIn()
        {
            this.LogedIn = CurrentUser.IsLogedIn();
            this.NotLogedIn = !CurrentUser.IsLogedIn();
        }
    }
}
