using System.ComponentModel.DataAnnotations;

namespace Sales.Service
{
    /// <summary>
    /// Validation decorator for command services
    /// </summary>
    /// <typeparam name="TCommand">TCommand is type of concrete parameter object</typeparam>
    public class ValidationCommandServiceDecorator<TCommand> : ICommandService<TCommand>
    {
        readonly ICommandService<TCommand> decoratee;

        public ValidationCommandServiceDecorator(ICommandService<TCommand> decoratee)
        {
            this.decoratee = decoratee;
        }

        /// <summary>
        /// Extending execute command with validations
        /// </summary>
        /// <param name="command">Parameter object</param>
        public void Execute(TCommand command)
        {
            Validator.ValidateObject(command, new ValidationContext(command));
            decoratee.Execute(command);
        }
    }
}
