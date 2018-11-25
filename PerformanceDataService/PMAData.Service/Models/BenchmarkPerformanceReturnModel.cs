using System;

namespace Performance.Data.Service.Models
{
	/// <summary>A data Model for the benchmark performance return model.</summary>
	public class BenchmarkPerformanceReturnModel
	{
		/// <summary>Initializes a new instance of the <see cref="BenchmarkPerformanceReturnModel"/> class.</summary>
		public BenchmarkPerformanceReturnModel()
		{
		}

		/// <summary>Gets or sets the identifier of the BenchmarkPerformanceID.</summary>
		/// <value>The identifier of the benchmark performance id.</value>
		public int BenchmarkPerformanceID
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the Code.</summary>
		/// <value>The identifier of the Code.</value>
		public string Code
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the Name.</summary>
		/// <value>The identifier of the Name.</value>
		public string Name
		{
			get;
			set;
		}

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