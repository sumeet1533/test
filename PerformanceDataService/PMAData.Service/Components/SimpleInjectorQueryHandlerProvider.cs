using SimpleInjector;

namespace Performance.Data.Service.Components
{
	/// <summary>This class cannot be inherited.</summary>
	internal sealed class SimpleInjectorQueryHandlerProvider : IQueryHandlerProvider
	{
		private readonly Container Container;

		/// <summary>Initializes a new instance of the <see cref="SimpleInjectorQueryHandlerProvider"/> class.</summary>
		/// <param name="container">Describing container name.</param>
		public SimpleInjectorQueryHandlerProvider(Container container)
		{
			this.Container = container;
		}

		public IQueryHandler<TQuery, TResult> GetQueryHandler<TQuery, TResult>()
		{
			return this.Container.GetInstance<IQueryHandler<TQuery, TResult>>();
		}
	}
}