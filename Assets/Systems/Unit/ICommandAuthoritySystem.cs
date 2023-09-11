using System;

public interface ICommandAuthoritySystem {
    bool HasCommandAuthority(Command command, ControllerIdentity identity);
}