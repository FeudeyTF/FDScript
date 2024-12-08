
namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class BinOperator : Node
    {
        public string Operator { get; }

        public Node LeftNode { get; }

        public Node RightNode { get; }

        public BinOperator(string oper, Node leftNode, Node rightNode)
        {
            Operator = oper;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public override object? Run(List<Variable> variables)
        {
            var leftResult = LeftNode.Run(variables);
            var rightResult = RightNode.Run(variables);
            switch (Operator)
            {
                case "+":
                    {
                        if (leftResult is int num1 && rightResult is int num2)
                            return num1 + num2;
                        else if (leftResult is string str1 && rightResult is string str2)
                            return str1 + str2;
                        else if (leftResult is int num3 && rightResult is string str3)
                            return num3.ToString() + str3;
                        else if (leftResult is string str4 && rightResult is int num4)
                            return str4 + num4.ToString();
                        else
                            throw new Exception("Can't cast objects!");
                    }
                case "-":
                    {
                        if (leftResult is int num1 && rightResult is int num2)
                            return num1 - num2;
                        else
                            throw new Exception("Can't minus NaNs!");
                    }
                case "*":
                    {
                        if (leftResult is int num1 && rightResult is int num2)
                            return num1 * num2;
                        else
                            throw new Exception("Can't multiply NaNs!");
                    }
                case "/":
                    {
                        if (leftResult is int num1 && rightResult is int num2)
                        {
                            if (num2 == 0)
                                throw new DivideByZeroException();
                            else
                                return num1 / num2;
                        }
                        else
                            throw new Exception("Can't divide NaNs!");
                    }
                default:
                    throw new Exception("Invalid operator!");
            }
        }

        public override string ToString()
        {
            return LeftNode + " " + Operator + " " + RightNode;
        }
    }
}
