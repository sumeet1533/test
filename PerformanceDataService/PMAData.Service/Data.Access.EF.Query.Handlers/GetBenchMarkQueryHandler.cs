using System.Linq;
using Performance.Data.Service.Components;
using Performance.Data.Service.Controllers.Queries;
using Performance.Data.Service.Models;

namespace Performance.Data.Service.Data.Access.EF.Query.Handlers
{
	/// <summary>A get benchmark mark query handler. This class cannot be inherited.</summary>
	internal sealed class GetBenchMarkQueryHandler : IQueryHandler<GetBenchMarkQuery, IQueryable<BenchmarkPerformanceModel>>
	{
		private readonly IPerformanceDatabaseContext PerformanceDbContext;

		/// <summary>Initializes a new instance of the <see cref="GetBenchMarkQueryHandler"/> class.</summary>
		/// <param name="performanceDbContext">Context for the am database.</param>
		public GetBenchMarkQueryHandler(IPerformanceDatabaseContext performanceDbContext)
		{
			this.PerformanceDbContext = performanceDbContext;
		}

		/// <summary>Enumerates execute in this collection.</summary>
		/// <param name="query">The query.</param>
		/// <returns>An enumerator that allows foreach to be used to process execute in this collection.</returns>
		public IQueryable<BenchmarkPerformanceModel> Execute(GetBenchMarkQuery query)
		{
			return this.PerformanceDbContext
				.BenchmarkPerformanceEntitySet
				.Join(this.PerformanceDbContext.BenchmarkPerformanceReturnEntitySet
				.Where(
						a => a.PerformanceImportID.Equals(
								this.PerformanceDbContext.BenchmarkPerformanceReturnEntitySet
							.Where(j => j.BenchmarkPerformanceID == a.BenchmarkPerformanceID)
							.OrderByDescending(c => c.PerformanceImportID)
							.Select(x => x.PerformanceImportID).FirstOrDefault()
							)
						),
					a => a.BenchmarkPerformanceID,
					b => b.BenchmarkPerformanceID,

					(a, b) => new { a, b })
					.Join(this.PerformanceDbContext.PerformanceImportEntitySet.Where(pi => pi.StatusTypeEv.Equals(2)),
					pr => pr.b.PerformanceImportID,
					i => i.PerformanceImportID, (pr, i)
					=> new BenchmarkPerformanceModel
					{
						BenchmarkPerformanceID = pr.a.BenchmarkPerformanceID,
						Code = pr.a.Code,
						Name = pr.a.Name,
						Description = pr.a.Description,
						InceptionDate = pr.a.InceptionDate,
						ModifiedBy = pr.a.ModifiedBy,
						ModifiedDate = pr.a.ModifiedDate,
						CreatedBy = pr.a.CreatedBy,
						CreatedDate = pr.a.CreatedDate,
					}
					).Distinct().AsQueryable();
		}
	}
}