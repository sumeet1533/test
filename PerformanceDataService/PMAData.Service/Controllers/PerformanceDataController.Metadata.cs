namespace Performance.Data.Service.Controllers
{
	public partial class PerformanceDataController
	{
		/// <summary>A metadata class to hold constants about the OData feed.</summary>
		internal static class Metadata
		{
			/// <summary>Name of the benchmark model collection.</summary>
			public const string BenchmarkModelCollectionName = "benchmark";

			/// <summary>Name of the benchmark performance model collection.</summary>
			public const string BenchmarkPerformanceModelCollectionName = "benchmarkPerformance";

			/// <summary>Name of the blend performance model collection.</summary>
			public const string BlendPerformanceModelCollectionName = "blendPerformance";

			/// <summary>Name of the blend model collection.</summary>
			public const string BlendModelCollectionName = "blend";

			/// <summary>Name of the model performance model collection.</summary>
			public const string ModelPerformanceModelCollectionName = "modelPerformance";

			/// <summary>Name of the models model collection.</summary>
			public const string ModelsModelCollectionName = "getModels";
		}
	}
}