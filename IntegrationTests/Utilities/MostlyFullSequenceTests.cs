using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Utilities.Implementation;

namespace IntegrationTests.Utilities
{
    [TestFixture]
    public class MostlyFullSequenceTests
    {
        private MostlyFullSequence _mostlyFullSequence;

        [SetUp]
        public void Setup()
        {
            _mostlyFullSequence = new MostlyFullSequence();
        }

        [Test]
        public void Add100_RandomDelete20()
        {
            var random = new Random();
            for (var i = 0; i < 100; i++)
            {
                _mostlyFullSequence.Add();
            }

            var listOfDeletedNums = new List<int>();
            listOfDeletedNums.Add(0);
            for (var i = 0; i < 10; i++)
            {
                var randomNumberToDelete = 0;
                while (listOfDeletedNums.Contains(randomNumberToDelete))
                {
                    randomNumberToDelete = random.Next(0, 100 - i);
                }
                listOfDeletedNums.Add(randomNumberToDelete);

                _mostlyFullSequence.DeleteAt(randomNumberToDelete);
            }

            listOfDeletedNums.Sort();

            foreach (var i in listOfDeletedNums)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine();
            var internalList = _mostlyFullSequence.GetInternaList();
            for (var i = 0; i < internalList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"{internalList[i]}-");
                }
                else
                {
                    Console.Write($"{internalList[i]} ");
                }
                
            }
        }
    }
}
