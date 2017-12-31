using System.Collections;
using System.Collections.Generic;

namespace Filters
{
	public static class ExtensionMethods
	{
		public static List<T> ToAList<T>(this IEnumerator enumerator)
		{
			var list = new List<T>();
			while (enumerator.MoveNext())
			{
				var current = enumerator.Current;
				if (!(current is T)) continue;
				
				list.Add((T)current);
			}
			return list;
		}
	}
}