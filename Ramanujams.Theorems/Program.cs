using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections;
using Ramanujams.Theorems;
namespace Ramanujams.Theorems
{

   
    class Program
    {
       
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter any whole number");
            int actualNumber = 0;
            int multiple = 0;
            int.TryParse(Console.ReadLine(),out actualNumber);
            Console.WriteLine("Enter a multiple e.g 5 or 7 or 11");
            int.TryParse(Console.ReadLine(), out multiple);
            var sequences = new SequenceGenerator().GenerateSequence(actualNumber, multiple);

            Dictionary<int, int> partitions = new Dictionary<int, int>();

            foreach (int sequenceInput in sequences)
            {
                Partition partitionObj = new Ramanujams.Theorems.Partition();
                int totalPartitions = partitionObj.GetTotalPartitions(sequenceInput);
                partitions.Add(sequenceInput, totalPartitions);
            }

            foreach (var dictItem in partitions)
            {
                Console.WriteLine("Partitions generated for {0} is {1}", dictItem.Key, dictItem.Value);
                Console.WriteLine("Is multiples of {0}" , multiple, (dictItem.Value % multiple == 0));
            }

            
        }

    }
}
