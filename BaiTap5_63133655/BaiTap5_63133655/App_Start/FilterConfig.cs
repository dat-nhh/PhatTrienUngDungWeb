﻿using System.Web;
using System.Web.Mvc;

namespace BaiTap5_63133655
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
