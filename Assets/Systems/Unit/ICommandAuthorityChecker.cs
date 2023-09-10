using System;

public interface ICommandAuthorityChecker
{
    bool HasCommandAuthority(IUnitCommand command, ControllerIdentity identity);
}