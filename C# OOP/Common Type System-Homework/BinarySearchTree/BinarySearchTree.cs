namespace BinarySearchTreeImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <remarks>The binary tree allows inserting duplicate keys.</remarks>
    public class BinarySearchTree<K, T> : IEnumerable<T> where K : IComparable<K>
    {
        private const string NodeNotFoundExceptionMessage = "A node with key = {0} is not found!";

        protected K key;

        protected T value;

        public BinarySearchTree<K, T> parentNode;

        public BinarySearchTree<K, T> rightChild;

        public BinarySearchTree<K, T> leftChild;

        public BinarySearchTree(K key, T value)
        {
            this.key = key;
            this.value = value;
        }

        public T Search(K key)
        {
            var currentNode = this;
            bool isFound = false;
            while (currentNode != null)
            {
                if (currentNode.key.CompareTo(key) == 0)
                {
                    isFound = true;
                    break;
                }
                else if (currentNode.key.CompareTo(key) < 0)
                {
                    currentNode = currentNode.rightChild;
                }
                else
                {
                    currentNode = currentNode.leftChild;
                }
            }

            if (!isFound)
            {
                return currentNode.value;
            }
            else
            {
                throw new InvalidOperationException(string.Format(NodeNotFoundExceptionMessage, key));
            }
        }

        public virtual void Add(K key, T value)
        {
            if (this.key.CompareTo(key) > 0)
            {
                if (this.leftChild == null)
                {
                    var newNode = new BinarySearchTree<K, T>(key, value);
                    this.leftChild = newNode;
                    this.leftChild.parentNode = this;
                }
                else
                {
                    this.leftChild.Add(key, value);
                }
            }
            else
            {
                if (this.rightChild == null)
                {
                    var newNode = new BinarySearchTree<K, T>(key, value);
                    this.rightChild = newNode;
                    this.rightChild.parentNode = this;
                }
                else
                {
                    this.rightChild.Add(key, value);
                }
            }
        }

        public void Delete(K key)
        {
            if (this.key.CompareTo(key) > 0)
            {
                this.leftChild.Delete(key);
            }
            else if (this.key.CompareTo(key) < 0)
            {
                this.rightChild.Delete(key);
            }
            else
            {
                if (this.leftChild != null && this.rightChild != null)
                {
                    var successor = this.FindMinNode(this.rightChild);
                    this.key = successor.key;
                    this.value = successor.value;

                    successor.Delete(successor.key);
                }
                else
                {
                    if (this.leftChild != null)
                    {
                        this.ReplaceNodeInParent(this, this.leftChild);
                    }
                    else
                    {
                        this.ReplaceNodeInParent(this, this.rightChild);
                    }
                }
            }
        }

        public override string ToString()
        {
            var result = new List<T>();
            var nodes = new Stack<BinarySearchTree<K, T>>();
            nodes.Push(this);
            while (nodes.Count > 0)
            {
                var currentNode = nodes.Pop();
                result.Add(currentNode.value);

                if (currentNode.rightChild != null)
                {
                    nodes.Push(currentNode.rightChild);
                }

                if (currentNode.leftChild != null)
                {
                    nodes.Push(currentNode.leftChild);
                }
            }
            return string.Join(", ", result);
        }

        private void ReplaceNodeInParent(BinarySearchTree<K, T> self, BinarySearchTree<K, T> nextNode)
        {
            if (self.parentNode != null)
            {
                if (self.parentNode.leftChild == self)
                {
                    self.parentNode.leftChild = nextNode;
                }
                else
                {
                    self.parentNode.rightChild = nextNode;
                }

                if (nextNode != null)
                {
                    nextNode.parentNode = self.parentNode;
                }
            }
        }

        private BinarySearchTree<K, T> FindMinNode(BinarySearchTree<K, T> node)
        {
            var currentNode = node;
            while (currentNode.leftChild != null)
            {
                currentNode = currentNode.leftChild;
            }

            return currentNode;
        }

        public IEnumerator<T> GetEnumerator()
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
