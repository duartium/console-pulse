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

public class BinarySearchTree
{
    public Node? Root { get; set; }
    public BinarySearchTree()
    {
        Root = null;
    }
    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private Node InsertRecursive(Node? root, int value)
    {
        if(root == null)
        {
			root = new Node(value);
            return root;
		}

        if(value < root.Data)
            root.Left = InsertRecursive(root.Left, value);
        else if(value > root.Data)
            root.Right  = InsertRecursive(root.Right, value);

        return root;
    }

    public void InOrder()
    {
        InOrderRec(Root);
    }

    private void InOrderRec(Node? root)
    {
        if(root != null)
        {
            InOrderRec(root.Left);
            Console.Write(root.Data + " ");
            InOrderRec(root.Right);
        }
    }
}

public class Node
{
    public Node? Left { get; set; }
	public Node? Right { get; set; }
    public int Data { get; set; }
    public Node(int value)
    {
        Data = value;
        Left = null;
        Right = null;
    }
}
