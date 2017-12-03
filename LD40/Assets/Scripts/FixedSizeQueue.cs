using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FixedSizedQueue<T>
{
    Queue<T> q = new Queue<T>();

    public int Limit { get; set; }

    public FixedSizedQueue(int n_limit)
    {
        Limit = n_limit; 
    }

    public void enqueue(T t)
    {
        if (q.Count > Limit)
            q.Dequeue();
        q.Enqueue(t);
    }

    public T getValueAtIndex(int index)
    {
        return q.ElementAt(index);
    }

    public T Peek()
    {
        return q.Peek();
    }

}