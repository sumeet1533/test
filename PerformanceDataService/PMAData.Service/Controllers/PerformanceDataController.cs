using System.Linq;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using Performance.Data.Service.Components;
using Performance.Data.Service.Controllers.Queries;
using Performance.Data.Service.Models;

namespace Performance.Data.Service.Controllers
{
	/// <summary>Class for performance data controller.</summary>
	[ODataRouting]
	public sealed partial class PerformanceDataController : ControllerBase, IPerformanceDataService
	{
		/// <summary>Initializes a new instance of the <see cref="PerformanceDataController"/> class.</summary>
		/// <param name="queryHandlerProvider">Using query handler provider.</param>
		public PerformanceDataController(IQueryHandlerProvider queryHandlerProvider) : base(queryHandlerProvider)
		{
		}

		/// <summary>Gets the benchmark data.</summary>
		/// <returns>The benchmark data.</returns>
		[HttpGet]
		[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute(Metadata.BenchmarkModelCollectionName)]
		public IQueryable<BenchmarkPerformanceModel> GetBenchmarkData()
		{
			return this.ExecuteQuery<GetBenchMarkQuery, IQueryable<BenchmarkPerformanceModel>>(new GetBenchMarkQuery());
		}

		/// <summary>Gets the benchmark performance data.</summary>
		/// <returns>The benchmark performance data.</returns>
		[HttpGet]
		[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute(Metadata.BenchmarkPerformanceModelCollectionName)]
		public IQueryable<BenchmarkPerformanceReturnModel> GetBenchmarkPerformanceData()
		{
			return this.ExecuteQuery<GetBenchMarkPerformanceQuery, IQueryable<BenchmarkPerformanceReturnModel>>(new GetBenchMarkPerformanceQuery());
		}

		/// <summary>Gets the blend performance data.</summary>
		/// <returns>The blend data.</returns>
		[HttpGet]
		[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute(Metadata.BlendPerformanceModelCollectionName)]
		public IQueryable<BlendPerformanceReturnModel> GetBlendPerformanceData()
		{
			return this.ExecuteQuery<GetBlendPerformanceQuery, IQueryable<BlendPerformanceReturnModel>>(new GetBlendPerformanceQuery());
		}

		/// <summary>Gets the blend  data.</summary>
		/// <returns>The blend data.</returns>
		[HttpGet]
		[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute(Metadata.BlendModelCollectionName)]
		public IQueryable<BlendPerformanceModel> GetBlendData()
		{
			return this.ExecuteQuery<GetBlendQuery, IQueryable<BlendPerformanceModel>>(new GetBlendQuery());
		}

		/// <summary>Gets the model performance data.</summary>
		/// <returns>The model performance data.</returns>
		[HttpGet]
		[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute(Metadata.ModelPerformanceModelCollectionName)]
		public IQueryable<ModelPerformanceReturnModel> GetModelPerformanceData()
		{
			return this.ExecuteQuery<GetModelPerformanceQuery, IQueryable<ModelPerformanceReturnModel>>(new GetModelPerformanceQuery());
		}

		/// <summary>Gets the model  data.</summary>
		/// <returns>The model performance data.</returns>
		[HttpGet]
		[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute(Metadata.ModelsModelCollectionName)]
		public IQueryable<ModelPerformanceModel> GetModelData()
		{
			return this.ExecuteQuery<GetModelQuery, IQueryable<ModelPerformanceModel>>(new GetModelQuery());
		}
	}
}