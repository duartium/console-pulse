


using InteractiveTrees;

/**Trace the algorithm for creating an expression tree for the expression (4*8)/6-3 **/
string arithmeticExpression = "( 4 * 8 ) / 6 - 3";

ExpressionNode root = ExpressionTree.BuildExpressionTree(arithmeticExpression);
root.Print();
Console.ReadLine();