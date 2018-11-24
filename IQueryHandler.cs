namespace InternetScanner
{
	public interface IQueryHandler<TQuery, TResult>
		where TQuery : FeedReaderQuery<TResult>
	{
		TResult Handle(TQuery query);
	}
}
