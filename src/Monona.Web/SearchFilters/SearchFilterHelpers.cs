using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Monona.Web.SearchFilters
{
    public static class SearchFilterHelpers
    {
        private static readonly string SEARCH_FILTER_KEY_PREFIX = "MSF_";

        public static TFilter GetSearchFilter<TFilter>(Controller controller)
            where TFilter : class
        {
            string key = GetSearchFilterKey<TFilter>();
            TFilter filter = null;
            if (controller.TempData.ContainsKey(key))
            {
                string value = (string)controller.TempData.Peek(key);
                filter = JsonConvert.DeserializeObject<TFilter>(value);
            }
            if (filter == null)
            {
                filter = Activator.CreateInstance<TFilter>();
            }
            return filter;
        }

        public static void SetSearchFilter<TFilter>(Controller controller, TFilter filter)
            where TFilter : class
        {
            string key = GetSearchFilterKey<TFilter>();
            string value = JsonConvert.SerializeObject(filter);
            controller.TempData[key] = value;
        }

        public static void ClearSearchFilter<TFilter>(Controller controller)
            where TFilter : class
        {
            string key = GetSearchFilterKey<TFilter>();
            if (controller.TempData.ContainsKey(key))
            {
                controller.TempData.Remove(key);
            }
        }

        public static void ClearAllSearchFilters(Controller controller)
        {
            foreach(var key in controller.TempData.Keys)
            {
                if (key.StartsWith(SEARCH_FILTER_KEY_PREFIX))
                {
                    controller.TempData.Remove(key);
                }
            }
        }

        private static string GetSearchFilterKey<TFilter>()
            where TFilter : class
        {
            return SEARCH_FILTER_KEY_PREFIX + typeof(TFilter).Name;
        }
    }
}
