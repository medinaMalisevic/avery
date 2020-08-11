namespace Sales.Service
{
    /// <summary>
    /// Abstraction representing all command services
    /// </summary>
    /// <typeparam name="TCommand">TCommand is type of concrete parameter object</typeparam>
    public interface ICommandService<TCommand>
    {
        void Execute(TCommand command);
    }
}
