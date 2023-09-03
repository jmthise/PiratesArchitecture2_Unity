using System;
using System.Collections.Generic;
using UnityEngine;

public class JobQueue
{
    private List<Job> Queue = new List<Job>();
    private List<Job> Completed = new List<Job>();
    public void ExecuteQueue()
    {
        if (Queue.Count <= 0) return;
        Job current = Queue[0];
        current.Execute();
    }
}