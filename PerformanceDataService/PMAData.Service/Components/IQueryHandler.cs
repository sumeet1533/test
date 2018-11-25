namespace Performance.Data.Service.Components
{
	/// <summary>Interface for query handler.</summary>
	/// <typeparam name="TQuery">Type of the query.</typeparam>
	/// <typeparam name="TResult">Type of the result.</typeparam>
	public interface IQueryHandler<in TQuery, out TResult>
	{
		/// <summary>Executes the query operation.</summary>
		/// <param name="query">The query.</param>
		/// <returns>A TResult.</returns>
		TResult Execute(TQuery query);
	}
}