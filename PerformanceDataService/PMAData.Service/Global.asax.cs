using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Query;
using Common.Logging;
using Performance.Data.Service.Components;
using Performance.Data.Service.Controllers;
using Performance.Data.Service.Data;
using Performance.Data.Service.Data.Access.EF;
using Performance.Data.Service.Models;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Performance.Data.Service
{
	/// <summary>Represents the application instance.</summary>
	public partial class Global : HttpApplication
	{
		static Global()
		{
			LogManager.Adapter = new PerformanceDataLoggerFactoryAdapter
				(
					PerformanceDataLoggerFactoryAdapter.CreateConfigurationProperties(WebConfigurationManager.AppSettings["LoggingConfigFile"]),
					name => new PerformanceDataLogger
					(
						NLog.LogManager.GetLogger(name),
						() => HttpContext.Current.GetCurrentContext()?.Request.GetRequestId()
					)
				);
		}

		/// <summary>Application start.</summary>
		[SuppressMessage("StyleCopPlus.StyleCopPlusRules", "SP0100:AdvancedNamingRules", Justification = "This matches a legacy ASP.NET event handler.")]
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(Register);
		}

		private static DbContextSettings ConfigureDbContext<TDbContext>() where TDbContext : DbContext
		{
			string contextName = typeof(TDbContext).Name;
			string connectionName = WebConfigurationManager.ConnectionStrings[contextName].Name;
			return new DbContextSettings(connectionName);
		}

		private static void Register(HttpConfiguration configuration)
		{
			RemoveMediaTypes();
			RegisterServices(configuration);
			RegisteroData(configuration);
		}

		private static void RemoveMediaTypes()
		{
			MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;
			formatters.Remove(formatters.XmlFormatter);
		}

		private static void RegisterServices(HttpConfiguration configuration)
		{
			Container container = new Container();
			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			container.RegisterSingleton<IQueryHandlerProvider>(() => new SimpleInjectorQueryHandlerProvider(container));
			container.Register<IPerformanceDatabaseContext>(() => new PerformanceDatabaseContext(ConfigureDbContext<PerformanceDatabaseContext>()), Lifestyle.Scoped);
			container.Register(typeof(IQueryHandler<,>), new[] { typeof(IQueryHandler<,>).Assembly }, Lifestyle.Scoped);
			container.Register<IPerformanceDataService, PerformanceDataController>(Lifestyle.Scoped);

			container.Verify();

			configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
			configuration.Services.Add(typeof(IExceptionLogger), new CommonLoggingExceptionLogger());
		}

		/// <summary>Register o-data described by config.</summary>
		/// <param name="config">The configuration.</param>
		public static void RegisteroData(HttpConfiguration config)
		{
			ODataModelBuilder modelBuilder = new ODataConventionModelBuilder(config)
			{
				Namespace = "PMAData",
				ContainerName = "AssetMark",
				OnModelCreating = model =>
				{
				model.EntitySet<BenchmarkPerformanceModel>(PerformanceDataController.Metadata.BenchmarkModelCollectionName)
					.EntityType
					.HasKey(k => k.BenchmarkPerformanceID);

				model.EntitySet<BenchmarkPerformanceReturnModel>(PerformanceDataController.Metadata.BenchmarkPerformanceModelCollectionName)
					.EntityType
					.HasKey(k => k.BenchmarkPerformanceID);

				model.EntitySet<BlendPerformanceReturnModel>(PerformanceDataController.Metadata.BlendPerformanceModelCollectionName)
					.EntityType
					.HasKey(k => k.BlendPerformanceID);

				model.EntitySet<BlendPerformanceModel>(PerformanceDataController.Metadata.BlendModelCollectionName)
					.EntityType
					.HasKey(k => k.BlendPerformanceID);

				model.EntitySet<ModelPerformanceReturnModel>(PerformanceDataController.Metadata.ModelPerformanceModelCollectionName)
					.EntityType
					.HasKey(k => k.ModelPerformanceID);

				model.EntitySet<ModelPerformanceModel>(PerformanceDataController.Metadata.ModelsModelCollectionName)
					.EntityType
						.HasKey(k => k.ModelPerformanceID);
				}
			};

			config
				.Filter(QueryOptionSetting.Allowed)
				.Select(QueryOptionSetting.Allowed)
				.OrderBy(QueryOptionSetting.Allowed)
				.Expand(QueryOptionSetting.Allowed)
				.Count(QueryOptionSetting.Allowed)
				.MaxTop(int.MaxValue)
				.MapODataServiceRoute
				(
					routeName: "odata",
					routePrefix: string.Empty,
					model: modelBuilder.GetEdmModel()
				);
		}
	}
}