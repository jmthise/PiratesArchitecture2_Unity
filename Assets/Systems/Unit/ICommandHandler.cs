using System;

public interface ICommandHandler {
    IProcess GetAction(Command command);
}