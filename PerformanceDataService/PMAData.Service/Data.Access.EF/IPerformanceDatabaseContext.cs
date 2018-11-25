using System.Data.Entity;
using Performance.Data.Service.Data.Entities;

namespace Performance.Data.Service.Data.Access.EF
{
	/// <summary>Interface for performance database context.</summary>
	internal interface IPerformanceDatabaseContext
	{
		/// <summary>Gets or sets the set the performance benchmark entity belongs to.</summary>
		/// <value>The performance benchmark entity set.</value>
		DbSet<BenchmarkPerformanceEntity> BenchmarkPerformanceEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance benchmark return entity belongs to.</summary>
		/// <value>The performance benchmark return entity set.</value>
		DbSet<BenchmarkPerformanceReturnEntity> BenchmarkPerformanceReturnEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance blend entity belongs to.</summary>
		/// <value>The performance blend entity set.</value>
		DbSet<BlendPerformanceEntity> BlendPerformanceEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance blend return entity belongs to.</summary>
		/// <value>The performance blend return entity set.</value>
		DbSet<BlendPerformanceReturnEntity> BlendPerformanceReturnEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the model performance entity belongs to.</summary>
		/// <value>The model performance entity set.</value>
		DbSet<ModelPerformanceEntity> ModelPerformanceEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the model performance return entity belongs to.</summary>
		/// <value>The model performance return entity set.</value>
		DbSet<ModelPerformanceReturnEntity> ModelPerformanceReturnEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance import entity belongs to.</summary>
		/// <value>The model performance import entity set.</value>
		DbSet<PerformanceImportEntity> PerformanceImportEntitySet
		{
			get;
			set;
		}
	}
}