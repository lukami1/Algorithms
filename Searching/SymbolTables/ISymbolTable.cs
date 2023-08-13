using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.SymbolTables
{
    public interface ISymbolTable<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Gets value paired with key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue GetValue(TKey key);
        /// <summary>
        /// Adds key-value pair to the collection
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(TKey key, TValue value);
        /// <summary>
        /// Deletes the key-value pair from the collection
        /// </summary>
        /// <param name="key"></param>
        void Delete(TKey key);
        /// <summary>
        /// Returns true if key is present in collection. Otherwise false.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(TKey key);
        /// <summary>
        /// Returns true if collection is empty, otherwise false.
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
        /// <summary>
        /// Returns the count of the collection.
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// Count of keys in [lo..hi] range.
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        int Count(TKey lo, TKey hi);
        /// <summary>
        /// Returns smallest key in collection.
        /// </summary>
        /// <returns></returns>
        TKey Min();
        /// <summary>
        /// Returns largest key in collection.
        /// </summary>
        /// <returns></returns>
        TKey Max();
        /// <summary>
        /// Returns largets key less than or equal to key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TKey Floor(TKey key);
        /// <summary>
        /// Returns smallest key greater than or equal to key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TKey Ceiling(TKey key);
        /// <summary>
        /// Returns the number of keys smaller than key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int Rank(TKey key);
        /// <summary>
        /// Returns key of rank k
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        TKey Select(int k);
        /// <summary>
        /// Delets smallest key.
        /// </summary>
        void DeleteMin();
        /// <summary>
        /// Delets largest key.
        /// </summary>
        void DeleteMax();
        /// <summary>
        /// Returns enumerable sorted collection in [lo..hi]
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        IEnumerable<TKey> Keys(TKey lo, TKey hi);
        /// <summary>
        /// Returns enumerable sorted collection of all keys
        /// </summary>
        /// <returns></returns>
        IEnumerable<TKey> Keys();
    }
}
