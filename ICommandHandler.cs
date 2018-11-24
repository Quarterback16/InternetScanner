using CSharpFunctionalExtensions;

namespace InternetScanner
{
	public interface ICommandHandler<TCommand>
		where TCommand : ICommand
	{
		Result Handle(TCommand command);
	}
}
