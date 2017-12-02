using System.Collections.Generic;

namespace SpazioDati.Dandelion.Business.Extensions
{
    /// <summary> 
    ///     Class that contains extension methods for the <c>List</c>
    /// </summary>
    public static class RedundancyList
    {
        /// <summary> 
        ///     Method that check if a list contains duplicate values       
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Returns true if the list has duplicate values, false otherwise </returns>
        public static bool hasDuplicates<T>(this List<T> list)
        {
            if (list != null)
            {
                var hs = new HashSet<T>();

                for (var i = 0; i < list.Count; ++i)
                {
                    if (!hs.Add(list[i])) return true;
                }
            }
            return false;
        }
    }
}