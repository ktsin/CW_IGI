using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WUI.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    public class ModalLinkTagHelper : TagHelper
    {
        public string ModalId { get; set; }

        public string Url { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("data-ajax", true);
            output.Attributes.SetAttribute("data-ajax-update", ModalId);
            output.Attributes.SetAttribute("data-ajax-url", Url);
            output.Attributes.SetAttribute("href", "");
            output.Attributes.SetAttribute("onclick", "(function(){$('" + ModalId + "').modal('toggle');})()");
        }
    }
}
