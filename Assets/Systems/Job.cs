using System;
<<<<<<< HEAD

public class Job
{

=======
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    bool isDone = false;
    public event Action OnCompleted;
    public void Execute() { }
>>>>>>> refs/remotes/origin/main
}