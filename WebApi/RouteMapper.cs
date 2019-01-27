using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetNuke.Web.Api;

namespace Angular6Demo.WebApi
{
    public class RouteMapper : IServiceRouteMapper
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <param name="routeManager">The route manager.</param>
        public void RegisterRoutes(IMapRoute routeManager)
        {
            routeManager.MapHttpRoute("Angular6Demo", "default", "{controller}/{action}",
                    new[] { "Angular6Demo.WebApi.controller" });

        }
    }

    //In short that means that you can address this webservice under the url
    //~/desktopmodules/Angular6Demo/api/{controller}/{action}
    //http://www.dnnsoftware.com/community-blog/cid/142400/getting-started-with-services-framework-webapi-edition 

}
