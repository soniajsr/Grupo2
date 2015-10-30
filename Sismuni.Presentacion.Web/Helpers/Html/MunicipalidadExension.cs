using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Sismuni.Presentacion.Web.Helpers.Html
{
    public static class MunicipalidadExension
    {
        public static MvcForm BeginSecureForm(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, object htmlAttributes)
        {
            TagBuilder tagBuilder = new TagBuilder("form");

            Dictionary<string, object> htmlAttributesDictionary = new Dictionary<string, object>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(htmlAttributes))
                htmlAttributesDictionary.Add(property.Name, property.GetValue(htmlAttributes));

            tagBuilder.MergeAttributes(htmlAttributesDictionary);
            tagBuilder.MergeAttribute("action", UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(), htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true));
            tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(method), true);
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            htmlHelper.ViewContext.Writer.Write(htmlHelper.AntiForgeryToken().ToHtmlString());
            var theForm = new MvcForm(htmlHelper.ViewContext);

            return theForm;
        }
    }
}