namespace ReviewApp.ReviewTaskApi
{
    public class DateOnlyRouteConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContext httpContext,
            IRouter route,
            string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            // Get the value from the route
            if (!values.TryGetValue(routeKey, out var routeValue))
            {
                return false;
            }

            // Attempt to parse the route value as a DateOnly
            if (DateOnly.TryParse(routeValue.ToString(), out _))
            {
                return true; // Return true if it's a valid DateOnly
            }

            return false; // Return false if it's not a valid DateOnly
        }
    }
}
