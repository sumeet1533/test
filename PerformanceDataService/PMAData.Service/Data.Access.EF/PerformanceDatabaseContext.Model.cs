using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodeFirstStoreFunctions;
using Performance.Data.Service.Data.Entities;

namespace Performance.Data.Service.Data.Access.EF
{
	internal sealed partial class PerformanceDatabaseContext
	{
		/// <summary>Initializes a new instance of the <see cref="PerformanceDatabaseContext"/> class.</summary>
		public PerformanceDatabaseContext()
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Add(new FunctionsConvention<PerformanceDatabaseContext>("dbo"));
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<BenchmarkPerformanceEntity>()
				.Map(p => p.ToTable("BenchmarkPerformance"))
				.HasKey(k => k.BenchmarkPerformanceID);

			modelBuilder.Entity<BenchmarkPerformanceReturnEntity>()
				.Map(p => p.ToTable("BenchmarkPerformanceReturn"))
				.HasKey(k => k.BenchmarkPerformanceReturnID);

			modelBuilder.Entity<BlendPerformanceEntity>()
				.Map(p => p.ToTable("BlendPerformance"))
				.HasKey(k => k.BlendPerformanceID);

			modelBuilder.Entity<BlendPerformanceReturnEntity>()
				.Map(p => p.ToTable("BlendPerformanceReturn"))
				.HasKey(k => k.BlendPerformanceReturnID);

			modelBuilder.Entity<ModelPerformanceEntity>()
				.Map(p => p.ToTable("ModelPerformance"))
				.HasKey(k => k.ModelPerformanceID);

			modelBuilder.Entity<ModelPerformanceReturnEntity>()
				.Map(p => p.ToTable("ModelPerformanceReturn"))
				.HasKey(k => k.ModelPerformanceReturnID);

			modelBuilder.Entity<PerformanceImportEntity>()
				.Map(p => p.ToTable("PerformanceImport"))
				.HasKey(k => k.PerformanceImportID);
		}
	}
}