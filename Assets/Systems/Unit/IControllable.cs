using System;

public interface IControllable
{
    void ParseCommand(IUnitCommand command, ControllerIdentity identity);
}