using System;

public interface ICommandAuthoritySystem {
    bool CheckCommand(ICommand command, IControllerIdentity sender);
}