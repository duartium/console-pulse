/**Trace the algorithm for creating an expression tree for the expression (4*8)/6-3 **/
string arithmeticExpression = "( 4 * 8 ) / 6 - 3";

ExpressionNode root = ExpressionTree.BuildExpressionTree(arithmeticExpression);
root.Print();
Console.ReadLine();

public class ExpressionNode
{
	public string Value { get; set; }
    public ExpressionNode? Left { get; set; }
	public ExpressionNode? Right { get; set; }

    public ExpressionNode(string value)
    {
        Value = value;
        Left = Right = null;
    }

	public void Print(
        string indent = "",
        bool last = true) {
        Console.Write(indent);
        if (last) {
            Console.Write("└─"); indent += " "; }
        else {
            Console.Write("├─"); indent += "| "; } Console.WriteLine(Value);

        if (Left != null) Left.Print(indent, false);
        if (Right != null) Right.Print(indent, true);
    }
}

public class ExpressionTree
{

	/// <summary>
	/// Build an expression tree from string that represent an arithmetic expression
	/// </summary>
	/// <param name="expression"></param>
	/// <returns></returns>
	public static ExpressionNode BuildExpressionTree(string expression)
	{
		var nodes = new Stack<ExpressionNode>();
		var operators = new Stack<string>();

		string[] tokens = expression.Split(' ');

		foreach (var token in tokens)
		{
			if (int.TryParse(token, out int num))
				nodes.Push(new ExpressionNode(token));
			else if (token == "(" )
				operators.Push(token);
			else if (token == ")" )
			{
				while (operators.Peek() != "(")
				{
					nodes.Push(
						CombineNodes(
							operators.Pop(),
							nodes.Pop(),
							nodes.Pop()
						)
					);
				}
				operators.Pop();
			}
			else if (IsOperator(token))
			{
				while (operators.Count > 0
					&& Precedence(operators.Peek()) >= Precedence(token))
					nodes.Push(CombineNodes(operators.Pop(), nodes.Pop(), nodes.Pop()));

				operators.Push(token);
			}
		}

		while (operators.Count > 0)
		{
			nodes.Push(CombineNodes(operators.Pop(), nodes.Pop(), nodes.Pop()));
		}
		return nodes.Pop();
	}

	private static ExpressionNode CombineNodes(
		string theOperator,
		ExpressionNode right,
		ExpressionNode left)
	{
		ExpressionNode node = new ExpressionNode(theOperator);
		node.Left = left;
		node.Right = right;
		return node;
	}

	private static bool IsOperator(string token)
	=> token == "+" || token == "-" || token == "*" || token == "/";

	private static int Precedence(string op)
	=> op switch { "+" or "-" => 1, "*" or "/" => 2, _ => 0, };
}
