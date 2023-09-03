using System;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    bool isDone = false;
    public event Action OnCompleted;
    public void Execute() { }
}