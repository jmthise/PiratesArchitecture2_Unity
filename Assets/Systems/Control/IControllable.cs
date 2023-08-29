using System;

public interface IControllable {
    IController Controller { get; }
    IHandler Handler { get; }
    INotifier Notifier { get; }
}