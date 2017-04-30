using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramanujams.Theorems
{
    public class SequenceGenerator
    {
        private IList<int> _sequencesForTest = null;
        private int startingNumber = 0;

        Dictionary<int, int> startingNumberCollection = new Dictionary<int, int>();

        public SequenceGenerator()
        {
            startingNumberCollection.Add(5, 4);
            startingNumberCollection.Add(7, 5);
            startingNumberCollection.Add(11, 6);
            _sequencesForTest = new List<int>();
        }

        private int FindNearestStartingNumber(int actualNumber, int multiple)
        {
            

            //Determine nearest multiple number;
            //iF the number is less than the multiple, start with that number;
            if (actualNumber % multiple == actualNumber)
                startingNumber = startingNumberCollection[multiple];
            else
            {
                // 8  : 5 (12
                int modulus = actualNumber % multiple;
                startingNumber = (actualNumber - modulus) + startingNumberCollection[multiple];

            }

            return startingNumber;

        }
        public IList<int> GenerateSequence(int actualNumber,int multiple)
        {
            int nearestNumber = FindNearestStartingNumber(actualNumber, multiple);

            _sequencesForTest.Add(nearestNumber);

            int nextNumber = nearestNumber;
            for (int i = 0; i < 5; i++)
            {
                nextNumber = nextNumber + multiple;
                _sequencesForTest.Add(nextNumber);
                //_sequencesForTest.Add(nearestNumber + startingNumberCollection[multiple]);
            }


            return _sequencesForTest;
        }
    }
}
