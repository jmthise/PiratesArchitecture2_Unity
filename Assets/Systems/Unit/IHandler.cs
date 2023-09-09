using System;

public interface IHandler {
    IJob GetJob(ICommand command);
}