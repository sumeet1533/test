using System.Linq;
using Performance.Data.Service.Components;
using Performance.Data.Service.Controllers.Queries;
using Performance.Data.Service.Models;

namespace Performance.Data.Service.Data.Access.EF.Query.Handlers
{
	/// <summary>A get model performance query handler. This class cannot be inherited.</summary>
	internal sealed class GetModelPerformanceQueryHandler : IQueryHandler<GetModelPerformanceQuery, IQueryable<ModelPerformanceReturnModel>>
	{
		private readonly IPerformanceDatabaseContext PerformanceDbContext;

		/// <summary>Initializes a new instance of the <see cref="GetModelPerformanceQueryHandler"/> class.</summary>
		/// <param name="performanceDbContext">Context for the am database.</param>
		public GetModelPerformanceQueryHandler(IPerformanceDatabaseContext performanceDbContext)
		{
			this.PerformanceDbContext = performanceDbContext;
		}

		/// <summary>Enumerates execute in this collection.</summary>
		/// <param name="query">The query.</param>
		/// <returns>An enumerator that allows foreach to be used to process execute in this collection.</returns>
		public IQueryable<ModelPerformanceReturnModel> Execute(GetModelPerformanceQuery query)
		{
			return this.PerformanceDbContext
				.ModelPerformanceEntitySet
				.Join(this.PerformanceDbContext.ModelPerformanceReturnEntitySet
				.Where(
						a => a.ReturnDate.Equals(
							this.PerformanceDbContext.ModelPerformanceReturnEntitySet
						.Where(j => j.ModelPerformanceID == a.ModelPerformanceID)
						.OrderByDescending(c => c.PerformanceImportID)
						.OrderByDescending(c => c.ReturnDate)
						.Select(x => x.ReturnDate).FirstOrDefault()
							)
						),
					a => a.ModelPerformanceID,
					b => b.ModelPerformanceID,
					(a, b) => new { a, b })
					.Join(this.PerformanceDbContext.PerformanceImportEntitySet.Where(pi => pi.StatusTypeEv.Equals(2)),
					pr => pr.b.PerformanceImportID,
					i => i.PerformanceImportID, (pr, i)
					=> new ModelPerformanceReturnModel
					{
						ModelPerformanceID = pr.a.ModelPerformanceID,
						Code = pr.a.Code,
						Name = pr.a.Name,
						ReturnDate = pr.b.ReturnDate,
						GrossReturn = pr.b.GrossReturn,
						NetReturn = pr.b.NetReturn,
						MethodTypeEv = pr.b.MethodTypeEv,
					}
					).AsQueryable();
		}
	}
}