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
		case "5": case null: exit = true; break;
		default: Console.WriteLine("Invalid option. Please try again."); break;
	}
}

public class BigONotation
{
	/// <summary>
	/// 0(1) Constant - because it always returns the first element, regardless of the size
	/// </summary>
	/// <param name="array"></param>
	/// <returns></returns>
	public int GetFirstElement(int[] array)
	{
		return array[0];
	}

	/// <summary>
	/// O(log n) Logaritmic - execution time grows logarithmically with the size of the input
	/// </summary>
	/// <param name="sortedArray"></param>
	/// <param name="target"></param>
	/// <returns></returns>
	public int BinarySearch(int[] sortedArray, int target)
	{
		int left = 0;
		int right = sortedArray.Length - 1;

		while(left <= right)
		{
			int middle = left + (right - left) / 2;

			if (sortedArray[middle] == target)
				return middle;

			if (sortedArray[middle] < target)
				left = middle + 1;
			else right = middle - 1;
		}
		return -1;
	}

	/// <summary>
	/// O(n) Lineal - because have to go through the entire list at worse case
	/// </summary>
	/// <param name="array"></param>
	/// <param name="target"></param>
	public int FindElement(int[] array, int target)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == target)
				return 1;
		}
		return -1; //not found element
	}

	/// <summary>
	/// O(n^2) Quadratic - the execution time growths quadratically with the size of the input
	/// </summary>
	/// <param name="array"></param>
	public void BubbleSort(int[] array)
	{
		int n = array.Length;
		for (int i = 0; i < n - 1; i++)
		{
			for(int j = 0; j < n - i - 1; j++)
			{
				if (array[j] > array[j + 1])
				{
					int temp = array[j];
					array[j] = array[j + 1];
					array[j + 1] = temp;
				}
			}
		}
	}
}
