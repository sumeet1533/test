using System.Linq;
using Performance.Data.Service.Models;

namespace Performance.Data.Service.Components
{
	/// <summary>Interface for performance data service.</summary>
	public interface IPerformanceDataService
	{
		/// <summary>Gets the benchmark data in this collection.</summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process the benchmark data in this collection.
		/// </returns>
		IQueryable<BenchmarkPerformanceModel> GetBenchmarkData();

		/// <summary>Gets the benchmark performance data in this collection.</summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process the benchmark performance data in this collection.
		/// </returns>
		IQueryable<BenchmarkPerformanceReturnModel> GetBenchmarkPerformanceData();

		/// <summary>Gets the blend performance data in this collection.</summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process the blend performance data in this collection.
		/// </returns>
		IQueryable<BlendPerformanceReturnModel> GetBlendPerformanceData();

		/// <summary>Gets the blend data in this collection.</summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process the blend data in this collection.
		/// </returns>
		IQueryable<BlendPerformanceModel> GetBlendData();

		/// <summary>Gets the model performance data in this collection.</summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process the model performance data in this collection.
		/// </returns>
		IQueryable<ModelPerformanceReturnModel> GetModelPerformanceData();

		/// <summary>Gets the model  data in this collection.</summary>
		/// <returns>
		/// An enumerator that allows foreach to be used to process the model data in this collection.
		/// </returns>
		IQueryable<ModelPerformanceModel> GetModelData();
	}
}