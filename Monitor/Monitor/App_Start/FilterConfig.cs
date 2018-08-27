using System.Web;
using System.Web.Mvc;
using Monitor.Models.ActionFilters;

namespace Monitor
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new StatisticsTrackerAttribute());
        }
    }
}