using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using TravelGuide.Business.Abstract;
using TravelGuide.Business.Concreate;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Web.Models
{
    public class CacheManager
    {

        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }
        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}