using System.Web.Mvc;
using System.Web.Routing;

namespace Lib.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			//routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			//routes.MapRoute(
			//	name: "Default",
			//	url: "{controller}/{action}/{id}",
			//	defaults: new { controller = "Books", action = "Index", id = UrlParameter.Optional }
			//);

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(null,
				"",
				new
				{
					controller = "Books",
					action = "Index",
					genre = (string)null,
					page = 1
				}
			);

			routes.MapRoute(
				name: null,
				url: "Page{page}",
				defaults: new { controller = "Books", action = "Index", genre = (string)null },
				constraints: new { page = @"\d+" }
			);

			routes.MapRoute(null,
				"{genre}",
				new { controller = "Books", action = "Index", page = 1 }
			);

			routes.MapRoute(null,
				"{genre}/Page{page}",
				new { controller = "Books", action = "Index" },
				new { page = @"\d+" }
			);

			routes.MapRoute(null, "{controller}/{action}");
		}
	}
}
