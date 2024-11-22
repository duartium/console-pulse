namespace HeapRandomIntegers;

public class MaxHeap
{
	private List<int> _elements = new List<int>();

	public int GetSize()
	{
		return _elements.Count;
	}

	public int Peek()
	{
		if (_elements.Count == 0)
			throw new Exception("Heap is empty");
		return _elements[0];
	}

	public void Add(int element)
	{
		_elements.Add(element);
		HeapifyUp(_elements.Count - 1);
	}

	/// <summary>
	/// Remove and return max value of heap
	/// </summary>
	/// <returns></returns>
	/// <exception cref="Exception"></exception>
	public int RemoveMax()
	{
		if (_elements.Count == 0)
			throw new Exception("Heap is empty");

		int result  = _elements[0];
		_elements[0] = _elements[_elements.Count - 1];
		_elements.RemoveAt(_elements.Count - 1);

		HeapifyDown(0);
		return result;
	}

	private void HeapifyUp(int index) {
		while(HasParent(index) 
			&& _elements[index] > GetParent(index))
		{
			int parentIndex = GetParentIndex(index);
			Swap(index, parentIndex);
			index = parentIndex;
		}
	}
	/// <summary>
	/// Adjustment the heap from up to down to maintain max-heap property after remove max element
	/// </summary>
	/// <param name="index"></param>
	private void HeapifyDown(int index)
	{
		while (HasLeftChild(index))
		{
			int largerChildIndex = GetLeftChildIndex(index);
			if(HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
			{
				largerChildIndex = GetRightChildIndex(index);
			}

			if (_elements[index] > _elements[largerChildIndex])
				break;
			else
				Swap(index, largerChildIndex);

			index = largerChildIndex;
		}
	}

	public void PrintHeap()
	{
		Console.WriteLine(string.Join(", ", _elements));
	}

	#region Auxiliar methods

	private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
	private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
	private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

	private int GetLeftChild(int index) => _elements[GetLeftChildIndex(index)];
	private int GetRightChild(int index) => _elements[GetRightChildIndex(index)];
	private int GetParent(int index) => _elements[GetParentIndex(index)];

	private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _elements.Count;
	private bool HasRightChild(int index) => GetRightChildIndex(index) < _elements.Count;
	private bool HasParent(int index) => GetParentIndex(index) >= 0;


	/// <summary>
	/// Get left, right and parent childs values of one node
	/// </summary>
	/// <param name="indexOne"></param>
	/// <param name="indexTwo"></param>
	private void Swap(int indexOne, int indexTwo)
	{
		int temp = _elements[indexOne];
		_elements[indexOne] = _elements[indexTwo];
		_elements[indexTwo] = temp;
	}

	#endregion
}
