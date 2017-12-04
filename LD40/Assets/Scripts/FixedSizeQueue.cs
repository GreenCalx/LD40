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
        for (int i = 0; i < n_limit; i++)
            q.Enqueue(default(T));
    }

    public void enqueue(T t)
    {
        if (q.Count > Limit)
            q.Dequeue();
        q.Enqueue(t);
    }

    public T getValueAtIndex(int index)
    {
        if (q.Count < index)
            return q.ElementAt(index);
        else
            return default(T);
    }

    public T Peek()
    {
        if (q.Count >= 0)
            return q.Peek();
        else
            return default(T);
    }

}