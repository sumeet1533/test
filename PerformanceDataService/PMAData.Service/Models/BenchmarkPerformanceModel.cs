using System;

namespace Performance.Data.Service.Models
{
	/// <summary>A data Model for the benchmark performance.</summary>
	public class BenchmarkPerformanceModel
	{
		/// <summary>Initializes a new instance of the <see cref="BenchmarkPerformanceModel"/> class.</summary>
		public BenchmarkPerformanceModel()
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

		/// <summary>Gets or sets the identifier of the Description.</summary>
		/// <value>The identifier of the Description.</value>
		public string Description
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the InceptionDate.</summary>
		/// <value>The identifier of the Inception Date.</value>
		public DateTime? InceptionDate
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the ModifiedBy.</summary>
		/// <value>The identifier of the ModifiedBy.</value>
		public string ModifiedBy
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the ModifiedDate.</summary>
		/// <value>The identifier of the Modified Date.</value>
		public DateTime? ModifiedDate
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the ModifiedBy.</summary>
		/// <value>The identifier of the ModifiedBy.</value>
		public string CreatedBy
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the CreatedDate.</summary>
		/// <value>The identifier of the Create Date.</value>
		public DateTime CreatedDate
		{
			get;
			set;
		}

	}
}