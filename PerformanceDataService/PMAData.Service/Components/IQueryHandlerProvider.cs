namespace Performance.Data.Service.Components
{
	/// <summary>Interface for query handler provider.</summary>
	public interface IQueryHandlerProvider
	{
		/// <summary>Handler, called when the get query.</summary>
		/// <typeparam name="TQuery">Type of the query.</typeparam>
		/// <typeparam name="TResult">Type of the result.</typeparam>
		/// <returns>The query handler.</returns>
		IQueryHandler<TQuery, TResult> GetQueryHandler<TQuery, TResult>();
	}
}