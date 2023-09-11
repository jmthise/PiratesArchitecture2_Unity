using System;

public interface IControllable {
    void ParseCommand(Command command, ControllerIdentity identity);
}