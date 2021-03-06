﻿using System.Collections.Generic;
using System.Linq;

namespace Okra.View.Wheel.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Break a list of items into chunks of a specific size
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
}