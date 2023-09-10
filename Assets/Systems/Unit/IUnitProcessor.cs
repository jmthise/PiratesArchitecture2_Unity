using System;

public interface IUnitProcessor
{
    bool IsDone { get; }
    void Process();
}