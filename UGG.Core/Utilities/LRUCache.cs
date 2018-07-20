using System;
using System.Collections.Generic;
using System.Linq;

namespace UGG.Core.Utilities
{
    public class LRUCache<T>
    {
        private int _size; //链表长度

        private int _capacity; //缓存容量 

        private Dictionary<int, ListNode<T>> _dic; //key +缓存数据

        private ListNode<T> _linkHead;

        public LRUCache(int capacity)
        {
            _linkHead = new ListNode<T>(-1, default(T));
            _linkHead.Next = _linkHead.Prev = _linkHead;
            this._size = 0;
            this._capacity = capacity;
            this._dic = new Dictionary<int, ListNode<T>>();
        }

        public T Get(int key)
        {
            if (_dic.ContainsKey(key))
            {
                ListNode<T> n = _dic[key];
                MoveToHead(n);
                return n.Value;
            }
            else
            {
                return default(T);
            }
        }

        public void Set(int key, T value)
        {
            ListNode<T> n;
            if (_dic.ContainsKey(key))
            {
                n = _dic[key];
                n.Value = value;
                MoveToHead(n);
            }
            else
            {
                n = new ListNode<T>(key, value);
                AttachToHead(n);
                _size++;
            }
            if (_size > _capacity)
            {
                RemoveLast(); // 如果更新节点后超出容量，删除最后一个
                _size--;
            }
            _dic.Add(key, n);
        }

        // 移出链表最后一个节点
        private void RemoveLast()
        {
            ListNode<T> deNode = _linkHead.Prev;
            RemoveFromList(deNode);
            _dic.Remove(deNode.Key);
        }

        // 将一个孤立节点放到头部
        private void AttachToHead(ListNode<T> n)
        {
            n.Prev = _linkHead;
            n.Next = _linkHead.Next;
            _linkHead.Next.Prev = n;
            _linkHead.Next = n;
        }

        // 将一个链表中的节点放到头部
        private void MoveToHead(ListNode<T> n)
        {
            RemoveFromList(n);
            AttachToHead(n);
        }

        private void RemoveFromList(ListNode<T> n)
        {
            //将该节点从链表删除
            n.Prev.Next = n.Next;
            n.Next.Prev = n.Prev;
        }

        public class ListNode<T>
        {
            public ListNode<T> Prev;

            public ListNode<T> Next;

            public T Value;

            public int Key;

            public ListNode(int key, T val)
            {
                Value = val;
                Key = key;
                this.Prev = null;
                this.Next = null;
            }
        }
    }
}