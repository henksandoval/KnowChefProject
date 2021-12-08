﻿namespace Chef.Infrastructure.Configurations.Culture
{
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Routing;

	public class RouteConstraint : IRouteConstraint
	{
		public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
		{
			if (!values.ContainsKey("culture"))
				return false;

			var culture = values["culture"]?.ToString() ?? "en";
			return culture is "en" or "es";
		}
	}
}