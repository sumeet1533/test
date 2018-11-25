using System.Web.OData;

namespace Performance.Data.Service.Components
{
	/// <summary>A controller base.</summary>
	public abstract class ControllerBase : ODataController
	{
		private readonly IQueryHandlerProvider QueryHandlerProvider;

		/// <summary>Initializes a new instance of the <see cref="ControllerBase"/> class.</summary>
		/// <param name="queryHandlerProvider">The query handler provider.</param>
		protected ControllerBase(IQueryHandlerProvider queryHandlerProvider)
		{
			this.QueryHandlerProvider = queryHandlerProvider;
		}

		/// <summary>Executes the query operation.</summary>
		/// <typeparam name="TQuery">Type of the query.</typeparam>
		/// <typeparam name="TResult">Type of the result.</typeparam>
		/// <param name="query">The query.</param>
		/// <returns>A TResult.</returns>
		protected TResult ExecuteQuery<TQuery, TResult>(TQuery query)
		{
			var queryHandler = this.QueryHandlerProvider.GetQueryHandler<TQuery, TResult>();
			return queryHandler.Execute(query);
		}
	}
}