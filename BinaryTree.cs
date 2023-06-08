using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lab7
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTree<T> ParentNode, LeftNode, RightNode;
        private T Value;

        public BinaryTree(T value, BinaryTree<T> parent)
        {
            Value = value;
            ParentNode = parent;
        }

        public void Add(T value)
        {
            if (value.CompareTo(this.Value) < 0)
            {
                if (LeftNode == null)
                {
                    LeftNode = new BinaryTree<T>(value, this);
                }
                else
                {
                    LeftNode.Add(value);
                }
            }
            else
            {
                if (RightNode == null)
                {
                    RightNode = new BinaryTree<T>(value, this);
                }
                else
                {
                    RightNode.Add(value);
                }
            }
        }

        public BinaryTree<T> Current() => this;


        public BinaryTree<T> Next()
        {
            if (RightNode == null)
            {
                if (this == ParentNode.RightNode)
                {
                    return DeadEndNext(this); 
                }
                else
                {
                    return ParentNode.Next();
                }
            }
            else 
            {
                BinaryTree<T> FinalLeftNode = RightNode.LeftNode;
                while (FinalLeftNode != null) 
                {
                    FinalLeftNode = FinalLeftNode.LeftNode;
                }

                return FinalLeftNode;
            }
        }

        private BinaryTree<T> DeadEndNext(BinaryTree<T> CurrentElement)
        {
            BinaryTree<T> FinalParentNode = CurrentElement.ParentNode;
            if (FinalParentNode != null)
            {
                while (FinalParentNode != null)
                {
                    FinalParentNode = FinalParentNode.ParentNode;
                }
                return FinalParentNode;
            }
            else
            {
               return CurrentElement.Next();
            }
            
        }

        public BinaryTree<T> Previous() => ParentNode;

        public static BinaryTree<T> operator ++(BinaryTree<T> CurrentNode)
        {
            return CurrentNode.Next();
        }

        public static BinaryTree<T> operator --(BinaryTree<T> CurrentNode)
        {
            return CurrentNode.Previous();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (LeftNode != null)
            {
                foreach (var item in LeftNode)
                {
                    yield return item;
                }
            }

            yield return Value;

            if (RightNode != null)
            {
                foreach (var Element in RightNode)
                {
                    yield return Element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (LeftNode != null)
            {
                foreach (var Element in LeftNode)
                {
                    yield return Element;
                }
            }

            yield return Value;

            if (RightNode != null)
            {
                foreach (var Element in RightNode)
                {
                    yield return Element;
                }
            }
        }
    }
}
