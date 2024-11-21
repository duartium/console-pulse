

using IntegersBinarySearchTree;

/**Consider the following list of integers: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10].
Show the binary search tree resulting from inserting the integers in the list.Consider the following list of integers:
[1, 2, 3, 4, 5, 6, 7, 8, 9, 10].
Show the binary search tree resulting from inserting the integers in the list.**/

int[] values = Enumerable.Range(1, 10).ToArray();

var bst = new BinarySearchTree();
foreach (var value in values)
	bst.Insert(value);

Console.WriteLine("Binary tree in order:");
bst.InOrder();
