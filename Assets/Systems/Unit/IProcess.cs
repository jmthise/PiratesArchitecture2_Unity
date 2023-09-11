using System;

public interface IProcess {
    bool IsDone { get; }
    void Execute(Unit unit);
}