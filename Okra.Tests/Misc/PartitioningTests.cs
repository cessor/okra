using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Should.Fluent;

namespace Okra.Tests.Misc
{

    public static class ListPartitioning 
    {
        /// <summary>
        /// Partitions a set into two supsets by a certain predicate.
        /// </summary>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="enumerable">The original set to partition.</param>
        /// <param name="predicate">The function to determine what to split the list by.</param>
        /// <returns>A tuple containing the two partitions. The first item in the tuple contains the items matched by the predicate. The second item contains the nonmatching items.</returns>
        public static Tuple<IEnumerable<TArg>, IEnumerable<TArg>> Partition<TArg>(this IEnumerable<TArg> enumerable, Func<TArg,bool> predicate) 
        {
            List<TArg> matching = new List<TArg>();
            List<TArg> nonMatching = new List<TArg>();
            foreach (var item in enumerable)
            {
                if (predicate(item))
                {
                    matching.Add(item);
                    continue;
                }
                nonMatching.Add(item);
            }
            return new Tuple<IEnumerable<TArg>, IEnumerable<TArg>>(matching, nonMatching);
        }
    }

    [TestFixture]
    class PartitioningTests
    {
        [Test]
        public void ShouldPartitionASetIntoMatchingAndNonMatchingItems()
        {
            var evenPartition = new []{2,4,6,8,10};
            var oddPartition = new []{1,3,5,7,9};
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Tuple<IEnumerable<int>, IEnumerable<int>> partitions = items.Partition(i => i % 2 == 0);
            partitions.Item1.Should().Equal(evenPartition);
            partitions.Item2.Should().Equal(oddPartition);
        }
    }
}
