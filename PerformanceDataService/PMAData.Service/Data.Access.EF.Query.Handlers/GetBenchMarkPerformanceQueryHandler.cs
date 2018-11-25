using System.Linq;
using Performance.Data.Service.Components;
using Performance.Data.Service.Controllers.Queries;
using Performance.Data.Service.Models;

namespace Performance.Data.Service.Data.Access.EF.Query.Handlers
{
	/// <summary>A get benchmark mark performance query handler. This class cannot be inherited.</summary>
	internal sealed class GetBenchMarkPerformanceQueryHandler : IQueryHandler<GetBenchMarkPerformanceQuery, IQueryable<BenchmarkPerformanceReturnModel>>
	{
		private readonly IPerformanceDatabaseContext PerformanceDbContext;

		/// <summary>Initializes a new instance of the <see cref="GetBenchMarkPerformanceQueryHandler"/> class.</summary>
		/// <param name="performanceDbContext">Context for the am database.</param>
		public GetBenchMarkPerformanceQueryHandler(IPerformanceDatabaseContext performanceDbContext)
		{
			this.PerformanceDbContext = performanceDbContext;
		}

		/// <summary>Enumerates execute in this collection.</summary>
		/// <param name="query">The query.</param>
		/// <returns>An enumerator that allows foreach to be used to process execute in this collection.</returns>
		public IQueryable<BenchmarkPerformanceReturnModel> Execute(GetBenchMarkPerformanceQuery query)
		{
			return this.PerformanceDbContext
				.BenchmarkPerformanceEntitySet
				.Join(this.PerformanceDbContext.BenchmarkPerformanceReturnEntitySet
				.Where(
						a => a.ReturnDate.Equals(
								this.PerformanceDbContext.BenchmarkPerformanceReturnEntitySet
							.Where(j => j.BenchmarkPerformanceID == a.BenchmarkPerformanceID)
							.OrderByDescending(c => c.PerformanceImportID)
							.OrderByDescending(c => c.ReturnDate)
							.Select(x => x.ReturnDate).FirstOrDefault()
							)
						),
					a => a.BenchmarkPerformanceID,
					b => b.BenchmarkPerformanceID,

					(a, b) => new { a, b })
					.Join(this.PerformanceDbContext.PerformanceImportEntitySet.Where(pi => pi.StatusTypeEv.Equals(2)),
					pr => pr.b.PerformanceImportID,
					i => i.PerformanceImportID, (pr, i)
					=> new BenchmarkPerformanceReturnModel
					{
						BenchmarkPerformanceID = pr.a.BenchmarkPerformanceID,
						Code = pr.a.Code,
						Name = pr.a.Name,
						ReturnDate = pr.b.ReturnDate,
						GrossReturn = pr.b.GrossReturn
					}
					).Distinct().AsQueryable();
		}
	}
}