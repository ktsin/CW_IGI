using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUI.HtmlHelpers
{
    public static class ModalButtonHtmlHelper
    {
        public static HtmlString ButtonWithModal(this IHtmlHelper html, string ajaxUrl, string buttonName)
        {
            StringBuilder res = new StringBuilder();
            res.AppendLine($"<p><a href=\"\" data-ajax=\"true\" data-ajax-url=\"{ajaxUrl}\" data-ajax-update=\"#innerModalAdd\">");
            res.AppendLine("<button class=\"btn btn-success\" data-bs-toggle=\"modal\" data-bs-target=\"#staticBackdrop\">");
            res.AppendLine(buttonName);
            res.AppendLine("</button></a></p>");
            res.Append(@"<!-- Modal -->");
            res.AppendLine("<div class=\"modal fade\" id=\"staticBackdrop\" data-bs-backdrop=\"static\" data-bs-keyboard=\"false\" tabindex=\" - 1\" aria-labelledby=\"staticBackdropLabel\" aria-hidden=\"true\">"
                           + "<div class=\"modal-dialog\">"
                           + "<div class=\"modal-content\">"
                           + "<div class=\"modal-header\">"
                           + $"<h5 class=\"modal-title\" id=\"staticBackdropLabel\">{buttonName}</h5>"
                           + "<button type = \"button\" class=\"btn btn-close\" data-bs-dismiss=\"modal\" aria-label=\"Close\"></button>"
                           + "</div>"
                           + "<div class=\"modal-body\" id=\"innerModalAdd\"></div></div></div></div>");
            res.AppendLine("<script>completed = function(xhr) {alert(`${ xhr.responseText}!`);$('#staticBackdrop').modal('hide');};</script>");
            return new HtmlString(res.ToString());
        }
    }
}
