using System;
using System.Collections.Generic;
using System.Text;

namespace My_Trie
{
    class Trie<T>
    {
        private readonly Node<T> Root;
        public int Count { get; set; }

        public Trie()
        {
            Root = new Node<T>('\0', default, "");
            Count = 1;
        }
        
        public void Add(string key, T data)
        {
            AddNode(key, data, Root);
        }
        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                }
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null) 
                {
                    AddNode(key[1..], data, subnode);
                }
                else
                {
                    var newNode = new Node<T>(key[0], data, node.Prefix + key[0]);
                    node.SubNodes.Add(key[0], newNode);
                    AddNode(key[1..], data, newNode);
                }
            }
        }

        public void Remove(string key)
        {
            RemoveNode(key, Root);
        }
        private void RemoveNode(string key, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                    return;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                    RemoveNode(key[1..], subnode);
            }
        }
        public bool TrySearch(string key, out T value)
        {
            return SearchNode(key, Root, out value);
        }
        private bool SearchNode(string key, Node<T> node, out T value)
        {
            value = default;
            var result = false;
            if (string.IsNullOrWhiteSpace(key))
            {
                if (node.IsWord)
                {
                    value = node.Data;
                    result = true;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                   result = SearchNode(key[1..], subnode, out value);
                }
            }
            return result;
        }
    }
}
