//Generate a random list of integers.
//Show the binary heap tree resulting from inserting the integers on the list one at a time.

using ConsolePulse.Common;
using HeapRandomIntegers;

var randomNumbers = MathHelper.GenerateRandomIntegers(10, 1, 100);
randomNumbers.ForEach(x => Console.WriteLine(x));

MaxHeap maxHeap = new();
foreach (int number in randomNumbers)
{
	maxHeap.Add(number);
	maxHeap.PrintHeap();
	Console.WriteLine();
}