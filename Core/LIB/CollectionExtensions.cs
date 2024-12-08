/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

namespace Core.LIB
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Returns the dictionary entry with the specified key, or the default value if the key was not found. Essentially the same as IDictionary&lt;TKey, TValue&gt;.TryGetValue, but more concise.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key">The key to search for.</param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            return source.ContainsKey(key)
                ? source[key]
                : default(TValue);
        }

        /// <summary>
        /// Convenience method for adding/updating a key/value pair to the dictionary, without risking that an exception is thrown.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            if (source.ContainsKey(key))
            {
                source[key] = value;
            }
            else
            {
                source.Add(key, value);
            }
        }

        /// <summary>
        /// Convenience method for adding/updating a key/value pair to the dictionary, without risking that an exception is thrown.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void AddOrIgnore<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            if (!source.ContainsKey(key))
            {
                source.Add(key, value);
            }
        }

        /// <summary>
        /// Finds out if the list is not containing any items.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="list">List to operate on</param>
        /// <returns>True if null or empty, false otherwise</returns>
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        /// Executing chaining method that handel items one by one. Nothing will happen if items or action is null.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="items">Sequence of items</param>
        /// <param name="action">Method that may work with all items one by one in the items sequence.</param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (action == null || items == null)
                return;

            foreach (var item in items)
            {
                action.Invoke(item);
            }
        }
    }
}
