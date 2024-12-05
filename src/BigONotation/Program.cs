using AlgorithmicComplexity;

int[] sampleArray = { 5, 3, 8, 6, 2, 7, 4, 1 };
int target = 7;
bool exit  = false;
var notation = new BigONotation();

while (!exit)
{
	Console.WriteLine("Select an option:");
	Console.WriteLine("1. O(1) - Get first element");
	Console.WriteLine("2. O(log n) - Binary search");
	Console.WriteLine("3. O(n) - Find element");
	Console.WriteLine("4. O(n^2) - Sort using Bubble Sort"); 
	Console.WriteLine("5. Exit");
	Console.Write("Option: ");

	switch (Console.ReadLine())
	{
		case "1": Console.WriteLine($"First element: {notation.GetFirstElement(sampleArray)}"); break;
		case "2": Console.WriteLine($"Target index: {notation.BinarySearch(sampleArray, target)}"); break;
		case "3": Console.WriteLine($"Target index: {notation.FindElement(sampleArray, target)}"); break;
		case "4":
			int[] bubbleSortedArray = (int[])sampleArray.Clone(); notation.BubbleSort(bubbleSortedArray);
			Console.WriteLine("Array sorted (Bubble Sort): " + string.Join(", ", bubbleSortedArray)); 
			break;
		case "5": exit = true; break;
		default: Console.WriteLine("Invalid option. Please try again."); break;
	}
}