using System;
using Microsoft.AspNetCore.Html;

namespace MvcKatalog.Helpers
{
    public static class OwnHelper
    {
        public static HtmlString Button(string target)
        {
            return new HtmlString(String.Format("<button type = 'submit' class='nav-link btn btn-link text-dark'>{0}</button>", target));
        }
    }
}