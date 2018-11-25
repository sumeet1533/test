using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Performance.Data.Service.Data.Entities;

namespace Performance.Data.Service.Data.Access.EF
{
	/// <summary>Class for performance database context.</summary>
	internal sealed partial class PerformanceDatabaseContext : DbContext, IPerformanceDatabaseContext
	{
		/// <summary>Initializes a new instance of the <see cref="PerformanceDatabaseContext"/> class.</summary>
		/// <param name="dbContextSettings">The database context settings.</param>
		public PerformanceDatabaseContext(DbContextSettings dbContextSettings) : base(dbContextSettings.ConnectionName)
		{
			Database.SetInitializer<PerformanceDatabaseContext>(null);
			this.Configuration.UseDatabaseNullSemantics = true;
		}

		/// <summary>Gets a context for the internal object.</summary>
		/// <value>The internal object context.</value>
		private ObjectContext InternalObjectContext
		{
			get { return ((IObjectContextAdapter)this).ObjectContext; }
		}

		/// <summary>Gets or sets the set the performance benchmark entity belongs to.</summary>
		/// <value>The performance benchmark entity set.</value>
		public DbSet<BenchmarkPerformanceEntity> BenchmarkPerformanceEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance benchmark return entity belongs to.</summary>
		/// <value>The performance benchmark return entity set.</value>
		public DbSet<BenchmarkPerformanceReturnEntity> BenchmarkPerformanceReturnEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance blend entity belongs to.</summary>
		/// <value>The performance blend entity set.</value>
		public DbSet<BlendPerformanceEntity> BlendPerformanceEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance blend return entity belongs to.</summary>
		/// <value>The performance blend return entity set.</value>
		public DbSet<BlendPerformanceReturnEntity> BlendPerformanceReturnEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the model performance entity belongs to.</summary>
		/// <value>The model performance entity set.</value>
		public DbSet<ModelPerformanceEntity> ModelPerformanceEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the model performance return entity belongs to.</summary>
		/// <value>The model performance return entity set.</value>
		public DbSet<ModelPerformanceReturnEntity> ModelPerformanceReturnEntitySet
		{
			get;
			set;
		}

		/// <summary>Gets or sets the set the performance import entity belongs to.</summary>
		/// <value>The model performance import entity set.</value>
		public DbSet<PerformanceImportEntity> PerformanceImportEntitySet
		{
			get;
			set;
		}
	}
}