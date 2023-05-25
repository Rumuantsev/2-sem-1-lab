using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab7
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTree<T> ParentElement, LeftElement, RightElement;
        private T Value;

        public BinaryTree(T value, BinaryTree<T> parent)
        {
            Value = value;
            ParentElement = parent;
        }

        public void Add(T value)
        {
            if (value.CompareTo(this.Value) < 0)
            {
                if (LeftElement == null)
                {
                    LeftElement = new BinaryTree<T>(value, this);
                }
                else
                {
                    LeftElement.Add(value);
                }
            }
            else
            {
                if (RightElement == null)
                {
                    RightElement = new BinaryTree<T>(value, this);
                }
                else
                {
                    RightElement.Add(value);
                }
            }
        }

        public BinaryTree<T> Current() => this;

        public BinaryTree<T> Next()
        {
            if (LeftElement != null)
            {
                return LeftElement;
            }
            else if (RightElement != null)
            {
                return RightElement;
            }
            else
            {
                BinaryTree<T> CurrentElement = this;
                BinaryTree<T> RightNeighbour = ParentElement.RightElement;
                return DeadEndNext(CurrentElement, RightNeighbour);
            }
        }

        private BinaryTree<T> DeadEndNext(BinaryTree<T> CurrentElement, BinaryTree<T> RightNeighbour)
        {
            if (CurrentElement == RightNeighbour)
            {
                return DeadEndNext(RightNeighbour, RightNeighbour.ParentElement.RightElement);
            }
            else
            {
                return RightNeighbour;
            }
        }

        public BinaryTree<T> Previous() => ParentElement;

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
            if (LeftElement != null)
            {
                foreach (var item in LeftElement)
                {
                    yield return item;
                }
            }

            yield return Value;

            if (RightElement != null)
            {
                foreach (var Element in RightElement)
                {
                    yield return Element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (LeftElement != null)
            {
                foreach (var Element in LeftElement)
                {
                    yield return Element;
                }
            }

            yield return Value;

            if (RightElement != null)
            {
                foreach (var Element in RightElement)
                {
                    yield return Element;
                }
            }
        }
    }
}
