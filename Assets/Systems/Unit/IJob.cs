using System;

public interface IJob
{
    bool IsDone { get; }
    void Process();
}