using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Lib
{
    public static class EnumberableLib
    {
        public delegate bool SearchCondition<T>(T item);
        public delegate int SelectCondition<T>(T item);
        public static IEnumerable<T> Search<T>(this IEnumerable<T> items, SearchCondition<T> searchCondition)
        {
            IList<T> result = new List<T>();
            foreach (var item in items)
                if (searchCondition(item))
                    result.Add(item);
            return result;
        }

        public static T GetFirstOrDefault<T>(this IEnumerable<T> items, SearchCondition<T> searchCondition)
        {
            foreach (var n in items)
                if (searchCondition(n))
                    return n;

            return default(T);
        }

        public static T GetLastOrDefault<T>(this IEnumerable<T> items, SearchCondition<T> searchCondition)
        {
            for(int i = items.Count() - 1; i >= 0; i--)
            {
                if (searchCondition(items.ElementAt(i)))
                    return items.ElementAt(i);
            }
            return default(T);
        }

        public static int Count<T>(this IEnumerable<T> items, SearchCondition<T> searchCondition)
        {
            int count = 0;
            foreach (var n in items)
            {
                if (searchCondition(n))
                    count++;
            }
            return count;
        }

        public static double Average<T>(this IEnumerable<T> items, SelectCondition<T> selectCondition)
        {
            double sum = 0;
            foreach (var item in items)
            {
                int value = selectCondition(item);
                sum = sum + value;
            }
            return sum / items.Count();
        }

        public static double Avg<T>(this IEnumerable<T> items, Func<T, decimal> selectCondition)
        {
            double sum = 0;
            foreach (var item in items)
            {
                decimal value = selectCondition(item);
                sum = sum + (double)value;
            }
            return sum / items.Count();
        }
    }
}
