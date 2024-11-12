using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveTrees;

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
