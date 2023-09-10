﻿using System.Text;

namespace MyLibrary;

public class Deque<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public Deque(T item)
    {
        _head = new Node<T>(item);
        _tail = _head;
    }
    
    public void PushFront(T item)
    {
        var node = new Node<T>(item);
        if (_head == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.Next = _head;
            _head.Previous = node;
            _head = node;
        }
    }
    
    public T PopFront()
    {
        if (_head == null)
        {
            throw new InvalidOperationException("Deque is empty");
        }
        var item = _head.Data;
        _head = _head.Next;
        if (_head != null)
        {
            _head.Previous = null;
        }
        else
        {
            _tail = null;
        }
        return item;
    }

    public T PeekFront()
    {
        if(_head == null)
        {
            throw new InvalidOperationException("Deque is empty");
        }
        
        return _head.Data;
    }
    
    public void PushBack(T item)
    {
        var node = new Node<T>(item);
        if (_tail == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.Previous = _tail;
            _tail.Next = node;
            _tail = node;
        }
    }
    
    public T PopBack()
    {
        if (_tail == null)
        {
            throw new InvalidOperationException("Deque is empty");
        }
        var item = _tail.Data;
        _tail = _tail.Previous;
        if (_tail != null)
        {
            _tail.Next = null;
        }
        else
        {
            _head = null;
        }
        return item;
    }
    
    public T PeekBack()
    {
        if(_tail == null)
        {
            throw new InvalidOperationException("Deque is empty");
        }
        
        return _tail.Data;
    }
    
    public bool IsEmpty()
    {
        return _head == null;
    }
    
    public void Clear()
    {
        _head = null;
        _tail = null;
    }
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("[");
        var node = _head;
        while (node != null)
        {
            sb.Append(node.Data);
            node = node.Next;
            if (node != null)
            {
                sb.Append(", ");
            }
        }
        sb.Append("]");
        return sb.ToString();
    }
    
    public void Reverse()
    {
        if (_head == null)
        {
            return;
        }
        var node = _head;
        while (node != null)
        {
            var temp = node.Next;
            node.Next = node.Previous;
            node.Previous = temp;
            node = temp;
        }
        (_head, _tail) = (_tail, _head);
    }
}