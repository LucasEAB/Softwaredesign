﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace sdAufgabe4
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child2");
            var child3 = tree.CreateNode("child2");
            root.AppendChild(child1);
            root.AppendChild(child2);
            root.AppendChild(child3);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            var test = (tree.Find("child2"));

            root.PrintTree();
        }
    }

    public class Tree<Type>
    {
        public List<TreeNode<Type>> Nodes = new List<TreeNode<Type>>();
        public TreeNode<Type> CreateNode(Type data)
        {
            TreeNode<Type> newNode = new TreeNode<Type>
            {
                Data = data
            };
            Nodes.Add(newNode);
            return newNode;
        }
        public List<TreeNode<Type>> Find(Type search)
        {
            return (Nodes.FindAll(x => x.Data.Equals(search)));
        }
    }

    public class TreeNode<Type>
    {
        public Type Data;
        public TreeNode<Type> Parent;
        public List<TreeNode<Type>> Children = new List<TreeNode<Type>>();

        public void RemoveChild(TreeNode<Type> child)
        {
            Children.Remove(child);
        }

        public void AppendChild(TreeNode<Type> child)
        {
            Children.Add(child);
        }

        public void PrintTree(int tierCounter = 0)
        {
            string depth = "";
            for (int i = 1; i <= tierCounter; i++)
                depth += "*";

            Console.WriteLine(depth + Data);

            foreach (TreeNode<Type> child in Children)
                child.PrintTree(tierCounter + 1);
        }
    }
}