using System.Collections.Generic;

namespace SpazioDati.Dandelion.Extensions
{
    public static class RedundancyList
    {
        public static bool hasDuplicates<T>(this List<T> list) {
            if(list != null)
            {
                var hs = new HashSet<T>();

                for (var i = 0; i < list.Count; ++i) {
                    if (!hs.Add(list[i])) return true;
                }
            }
            return false;
        }
    }
}