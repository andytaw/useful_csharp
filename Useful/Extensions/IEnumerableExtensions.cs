namespace Useful.Extensions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Standard ForEach function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items == null) throw new NullReferenceException();
            foreach (var item in items) action?.Invoke(item);
        }

        /// <summary>
        /// For a set / table of permutation data, adds another permutation based on newData.
        /// Example:
        /// data    =   {
        ///               {1, a},
        ///               {1, b},
        ///               {1, c},
        ///               {2, a},
        ///               {2, b},
        ///               {2, c}
        ///             };
        /// newData =   {x, y};
        /// result  =   {
        ///               {1, a, x},
        ///               {1, b, x},
        ///               {1, c, x},
        ///               {2, a, x},
        ///               {2, b, x},
        ///               {2, c, x},
        ///               {1, a, y},
        ///               {1, b, y},
        ///               {1, c, y},
        ///               {2, a, y},
        ///               {2, b, y},
        ///               {2, c, y}
        ///             }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Original table of permutations</param>
        /// <param name="newData">New set of data to add</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<IEnumerable<T>> data, IEnumerable<T> newData)
        {
            if (data == null) throw new NullReferenceException();
            if (!data.Any()) return new List<List<T>>();

            if (newData == null) return data;
            if (!newData.Any()) return data;

            return data.SelectMany(row => newData.Select(value => row.Concat(new[] { value })));
        }

        /// <summary>
        /// Calculates all permutations of a set of sets of data values.
        /// Example:
        /// data    =   {{1}, {a, b}, {x, y, z}}
        /// result  =   {
        ///               {1, a, x},
        ///               {1, a, y},
        ///               {1, a, z},
        ///               {1, b, x},
        ///               {1, b, y},
        ///               {1, b, z}
        ///             }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Set of sets of values</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<IEnumerable<T>> data)
        {
            if (data == null) throw new NullReferenceException();
            if (!data.Any()) return new List<List<T>>();

            return data.Skip(1).Aggregate(
                data.First().Select(x => new List<T> { x }),
                (x, y) => x.Permute(y).ToLists()
            );
        }

        public static T[][] ToArrays<T>(this IEnumerable<IEnumerable<T>> data)
        {
            if (data == null) throw new NullReferenceException();
            return data.Select(x => x.ToArray()).ToArray();
        }

        public static List<List<T>> ToLists<T>(this IEnumerable<IEnumerable<T>> data)
        {
            if (data == null) throw new NullReferenceException();
            return data.Select(x => x.ToList()).ToList();
        }
    }
}
