using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LIMS.HTMLExtensions
{
    public static class HTMLExtensions
    {
        public static MvcHtmlString DisplayOrEditFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            if (html.ViewContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return html.EditorFor(expression);
            }
            else
            {
                return html.DisplayFor(expression);
            }
        }

        public static MvcHtmlString DisplayOrEdit(this HtmlHelper html, string expression)
        {
            if (html.ViewContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return html.Editor(expression);
            }
            else
            {
                return html.Display(expression);
            }
        }
    }
}