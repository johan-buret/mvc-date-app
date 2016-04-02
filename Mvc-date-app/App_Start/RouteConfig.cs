using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Globalization;

namespace Mvc_date_app
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Date"
                , url: "{controller}/{action}/bydate/{date}"
                , defaults: new { controller = "Home", action = "Index", datespecialformat = UrlParameter.Optional }
                , constraints: new { datespecialformat = @"\d{12}" }).RouteHandler = new DateRouteHandler();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }


    public class DateRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var dateValue = requestContext.RouteData.Values["date"];
            if(dateValue!=null)
            {
                var dateS = dateValue.ToString();
                requestContext.RouteData.Values["date"] = DateTime.ParseExact(dateS, "yyyyMMddHHmm", CultureInfo.InvariantCulture.DateTimeFormat);
            }
            return base.GetHttpHandler(requestContext);
        }
    }
}
