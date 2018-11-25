using System;

namespace Performance.Data.Service.Data.Entities
{
	/// <summary>An blend performance return entity. This class cannot be inherited.</summary>
	internal sealed class BlendPerformanceReturnEntity
	{
		/// <summary>Initializes a new instance of the <see cref="BlendPerformanceReturnEntity"/> class.</summary>
		public BlendPerformanceReturnEntity()
		{

		}

		/// <summary>Gets or sets the identifier of the BenchmarkPerformanceReturnID.</summary>
		/// <value>The identifier of the Benchmark Performance ReturnID.</value>
		public int BlendPerformanceReturnID { get; set; }

		/// <summary>Gets or sets the identifier of the PerformanceImportID.</summary>
		/// <value>The identifier of the Model Performance Import ID.</value>
		public int PerformanceImportID
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the BenchmarkPerformanceID.</summary>
		/// <value>The identifier of the Benchmark Performance ID.</value>
		public int BlendPerformanceID { get; set; }

		/// <summary>Gets or sets the identifier of the ReturnDate.</summary>
		/// <value>The identifier of the Return Date.</value>
		public DateTime ReturnDate
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the GrossReturn.</summary>
		/// <value>The identifier of the Gross Return.</value>
		public decimal GrossReturn
		{
			get;
			set;
		}
	}
}