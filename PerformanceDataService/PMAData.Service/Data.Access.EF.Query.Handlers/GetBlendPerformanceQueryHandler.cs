using System.Linq;
using Performance.Data.Service.Components;
using Performance.Data.Service.Controllers.Queries;
using Performance.Data.Service.Models;

namespace Performance.Data.Service.Data.Access.EF.Query.Handlers
{
	/// <summary>A get blend performance query handler. This class cannot be inherited.</summary>
	internal sealed class GetBlendPerformanceQueryHandler : IQueryHandler<GetBlendPerformanceQuery, IQueryable<BlendPerformanceReturnModel>>
	{
		private readonly IPerformanceDatabaseContext PerformanceDbContext;

		/// <summary>Initializes a new instance of the <see cref="GetBlendPerformanceQueryHandler"/> class.</summary>
		/// <param name="performanceDbContext">Context for the am database.</param>
		public GetBlendPerformanceQueryHandler(IPerformanceDatabaseContext performanceDbContext)
		{
			this.PerformanceDbContext = performanceDbContext;
		}

		/// <summary>Enumerates execute in this collection.</summary>
		/// <param name="query">The query.</param>
		/// <returns>An enumerator that allows foreach to be used to process execute in this collection.</returns>
		public IQueryable<BlendPerformanceReturnModel> Execute(GetBlendPerformanceQuery query)
		{
			return this.PerformanceDbContext
				.BlendPerformanceEntitySet
				.Join(this.PerformanceDbContext.BlendPerformanceReturnEntitySet
				.Where(
						a => a.ReturnDate.Equals(
								this.PerformanceDbContext.BlendPerformanceReturnEntitySet
							.Where(j => j.BlendPerformanceID == a.BlendPerformanceID)
							.OrderByDescending(c => c.PerformanceImportID)
							.OrderByDescending(c => c.ReturnDate)
							.Select(x => x.ReturnDate).FirstOrDefault()
							)
						),
					a => a.BlendPerformanceID,
					b => b.BlendPerformanceID,

					(a, b) => new { a, b })
					.Join(this.PerformanceDbContext.PerformanceImportEntitySet.Where(pi => pi.StatusTypeEv.Equals(2)),
					pr => pr.b.PerformanceImportID,
					i => i.PerformanceImportID, (pr, i)
					=> new BlendPerformanceReturnModel
					{
						BlendPerformanceID = pr.a.BlendPerformanceID,
						Code = pr.a.Code,
						Name = pr.a.Name,
						ReturnDate = pr.b.ReturnDate,
						GrossReturn = pr.b.GrossReturn
					}
					).Distinct().AsQueryable();
		}
	}
}