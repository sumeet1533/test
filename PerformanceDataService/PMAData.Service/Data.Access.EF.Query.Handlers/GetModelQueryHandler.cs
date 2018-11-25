using System.Linq;
using Performance.Data.Service.Components;
using Performance.Data.Service.Controllers.Queries;
using Performance.Data.Service.Models;

namespace Performance.Data.Service.Data.Access.EF.Query.Handlers
{
	/// <summary>A get model query handler. This class cannot be inherited.</summary>
	internal sealed class GetModelQueryHandler : IQueryHandler<GetModelQuery, IQueryable<ModelPerformanceModel>>
	{
		private readonly IPerformanceDatabaseContext PerformanceDbContext;

		/// <summary>Initializes a new instance of the <see cref="GetModelQueryHandler"/> class.</summary>
		/// <param name="performanceDbContext">Context for the am database.</param>
		public GetModelQueryHandler(IPerformanceDatabaseContext performanceDbContext)
		{
			this.PerformanceDbContext = performanceDbContext;
		}

		/// <summary>Enumerates execute in this collection.</summary>
		/// <param name="query">The query.</param>
		/// <returns>An enumerator that allows foreach to be used to process execute in this collection.</returns>
		public IQueryable<ModelPerformanceModel> Execute(GetModelQuery query)
		{
			return this.PerformanceDbContext
				.ModelPerformanceEntitySet
				.Join(this.PerformanceDbContext.ModelPerformanceReturnEntitySet
				.Where(
							a => a.PerformanceImportID.Equals(
								this.PerformanceDbContext.ModelPerformanceReturnEntitySet
							.Where(j => j.ModelPerformanceID == a.ModelPerformanceID)
							.OrderByDescending(c => c.PerformanceImportID)
							.Select(x => x.PerformanceImportID).FirstOrDefault()
							)
						),
					a => a.ModelPerformanceID,
					b => b.ModelPerformanceID,
					(a, b) => new { a, b })
					.Join(this.PerformanceDbContext.PerformanceImportEntitySet.Where(pi => pi.StatusTypeEv.Equals(2)),
					pr => pr.b.PerformanceImportID,
					i => i.PerformanceImportID, (pr, i)
					=> new ModelPerformanceModel
					{
						ModelPerformanceID = pr.a.ModelPerformanceID,
						Code = pr.a.Code,
						Name = pr.a.Name,
						HistoricalInceptionDate = pr.a.HistoricalInceptionDate,
						AssetMarkInceptionDate = pr.a.AssetMarkInceptionDate,
						InitialCompositeDate = pr.a.InitialCompositeDate,
						ModifiedBy = pr.a.ModifiedBy,
						ModifiedDate = pr.a.ModifiedDate,
						CreatedBy = pr.a.CreatedBy,
						CreatedDate = pr.a.CreatedDate,
					}
					).Distinct().AsQueryable();
		}
	}
}