using System;

class Solution
{
    static void Main(string[] args)
    {
        var node = Node.Insert(null, 40);
        Node.Insert(node, 30);
        Node.Insert(node, 65);
        Node.Insert(node.Left, 22);
        Node.Insert(node.Left, 38);
        Node.Insert(node.Right, 78);
        Node.Insert(node.Right.Right, 84);
        Console.WriteLine(Node.Diameter(node));
        Console.ReadLine();
    }
}

public class Node
{
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Data { get; set; }

    public Node(int newData)
    {
        Left = Right = null;
        Data = newData;
    }

    public static Node Insert(Node node, int data)
    {
        if (node == null)
        {
            node = new Node(data);
        }
        else
        {
            if (data < node.Data)
            {
                node.Left = Insert(node.Left, data);
            }
            else
            {
                node.Right = Insert(node.Right, data);
            }
        }
        return node;
    }

    public static int Diameter(Node node)
    {
        var diameter = (node == null) ? 0 : 1;
        var nodeInSubject = node;
        while(nodeInSubject.Left != null)
        {
            diameter++;
            nodeInSubject = nodeInSubject.Left;
        }
        nodeInSubject = node;
        while (nodeInSubject.Right != null)
        {
            diameter++;
            nodeInSubject = nodeInSubject.Right;
        }
        return diameter;
    }
}