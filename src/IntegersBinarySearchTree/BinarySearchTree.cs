using System.Security.Principal;

namespace IntegersBinarySearchTree;

public class BinarySearchTree
{
    public Node Root { get; set; }
    public BinarySearchTree()
    {
        Root = null;
    }
    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private Node InsertRecursive(Node root, int value)
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

    private void InOrderRec(Node root)
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