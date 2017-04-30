using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramanujams.Theorems
{
    public class Partition
    {

        public  System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                Console.WriteLine("before yield");
                yield return result;
            }
        }



        internal class Combination
        {
            internal int Num;
            internal IEnumerable<Combination> Partitions;
        }

        internal  IEnumerable<Combination> GetCombinationTrees(int num, int max)
        {
            return Enumerable.Range(1, num)
                             .Where(n => n <= max)
                             .Select(n =>
                                 new Combination
                                 {
                                     Num = n,
                                     Partitions = GetCombinationTrees(num - n, n)
                                 });
        }

        internal  IEnumerable<IEnumerable<int>> BuildPartitions(
                                                       IEnumerable<Combination> combinations)
        {
            if (combinations.Count() == 0)
            {
                return new[] { new int[0] };
            }
            else
            {
                return combinations.SelectMany(c =>
                                      BuildPartitions(c.Partitions)
                                           .Select(l => new[] { c.Num }.Concat(l))
                                    );
            }
        }

        public  IEnumerable<IEnumerable<int>> GetPartitions(int num)
        {
            var combinationsList = GetCombinationTrees(num, num);

            return BuildPartitions(combinationsList);
        }

        public  int GetTotalPartitions(int num)
        {
            var allPartitions = GetPartitions(num);

            return allPartitions.Count();
        }
    }
}
