﻿using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Web.Infrastructure
{
    public class SubAreaViewLocationExpander : IViewLocationExpander
    {
        private const string _subArea = "subarea";

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //check if subarea key contain  
            if (context.ActionContext.RouteData.Values.ContainsKey(_subArea))
            {
                var subArea = RazorViewEngine.GetNormalizedRouteValue(context.ActionContext, _subArea);
                var subAreaViewLocation = new string[]
                {
                    "/Areas/{2}/SubAreas/"+subArea+"/{1}/{0}.cshtml"
                };

                viewLocations = subAreaViewLocation.Concat(viewLocations);
            }

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            string subArea = string.Empty;
            context.ActionContext.ActionDescriptor.RouteValues.TryGetValue(_subArea, out subArea);

            context.Values[_subArea] = subArea;
        }
    }
}