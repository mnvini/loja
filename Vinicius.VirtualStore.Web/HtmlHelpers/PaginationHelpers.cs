using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Vinicius.VirtualStore.Web.Models;

namespace Vinicius.VirtualStore.Web.HtmlHelpers
{
    public static class PaginationHelpers
    {
        public static MvcHtmlString PageLinks(this System.Web.Mvc.HtmlHelper html , Pagination pagination,
            Func<int, string> pageUrl)
        {
            StringBuilder result =  new StringBuilder();

            for (int i = 1; i <= pagination.PagesTotal; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href",pageUrl(i));
                tag.InnerHtml = i.ToString();
                 
                if (i.Equals(pagination.CurrentPage))
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag);
            }
            return MvcHtmlString.Create(result.ToString());

        }
    }
}