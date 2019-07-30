using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Digiturk.Core.Caching
{
    public static class CacheExtensions
    {
        public static void RemoveByPattern(this ICacheManager cacheManager, string pattern, IEnumerable<string> keys)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matchesKeys = keys.Where(key => regex.IsMatch(key)).ToList();

            matchesKeys.ForEach(cacheManager.Remove);
        }
    }
}
