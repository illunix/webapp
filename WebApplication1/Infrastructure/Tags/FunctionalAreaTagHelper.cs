using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Web.Infrastructure.Tags
{
    [HtmlTargetElement("a", Attributes = "asp-controller")]
    [HtmlTargetElement("form", Attributes = "asp-controller")]
    public class FunctionalAreaTagHelper : AnchorTagHelper
    {
        [HtmlAttributeName("asp-subarea")]
        public string SubArea { get; set; }

        public FunctionalAreaTagHelper(IHtmlGenerator generator) : base(generator)
        {

        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            RouteValues["subarea"] = SubArea;

            if (output.Attributes.TryGetAttribute("href", out TagHelperAttribute attr))
            {
                output.Attributes.Remove(attr);
            }

            base.Process(context, output);
        }
    }
}
