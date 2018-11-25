using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Performance.Data.Service.Models
{
	/// <summary>A data model for the model performance return model.</summary>
	public class ModelPerformanceReturnModel
	{
		/// <summary>Initializes a new instance of the <see cref="ModelPerformanceReturnModel"/> class.</summary>
		public ModelPerformanceReturnModel()
		{
		}

		/// <summary>Gets or sets the identifier of the BenchmarkPerformanceID.</summary>
		/// <value>The identifier of the benchmark performance id.</value>
		public int ModelPerformanceID
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
		public decimal? GrossReturn
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the NetReturn.</summary>
		/// <value>The identifier of the Net Return.</value>
		public decimal? NetReturn
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the MethodTypeEV.</summary>
		/// <value>The identifier of the Method TypeEV.</value>
		public int? MethodTypeEv
		{
			get;
			set;
		}
	}
}