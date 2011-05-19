using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using xEasyApp.Core.Configurations;

namespace xEasyApp.Core.Extensions
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString Css(this HtmlHelper html, Theme theme, params string[] cssfilename)
        {
            if (cssfilename != null)
            {
                string folderpath = "~/Themes/" + theme;
                string csslink = "<link href=\"{0}\" rel=\"Stylesheet\" type=\"text/css\" />";
                StringBuilder sb = new StringBuilder();
                foreach (string filename in cssfilename)
                {
                    sb.AppendFormat(csslink, UrlHelper.GenerateContentUrl(folderpath+"/"+filename+".css", html.ViewContext.HttpContext));
                }

                return MvcHtmlString.Create(sb.ToString());
            }
            return MvcHtmlString.Empty;
 
        }
        public static MvcHtmlString Css(this HtmlHelper html, params string[] cssfilename)
        {
            return html.Css(Theme.Default, cssfilename);
        }
        public static MvcHtmlString Js(this HtmlHelper html, params string[] jsKeys)
        {
            if (jsKeys != null)
            {               
                string jslink = "<script src='{0}' type='text/javascript'></script>";
                StringBuilder sb = new StringBuilder();
                foreach (string key in jsKeys)
                {
                    var jsurl =JsConfig.GetJsUrl(key,html.ViewContext.HttpContext);
                    if(string.IsNullOrEmpty(jsurl))
                        continue;
                    sb.AppendFormat(jslink, UrlHelper.GenerateContentUrl(jsurl, html.ViewContext.HttpContext));
                }
                return MvcHtmlString.Create(sb.ToString());
            }
            return MvcHtmlString.Empty;

        }
    }
}
