using System;

namespace Performance.Data.Service.Models
{
	/// <summary>A data model for the blend performance return model.</summary>
	public class BlendPerformanceReturnModel
	{
		/// <summary>Initializes a new instance of the <see cref="BlendPerformanceReturnModel"/> class.</summary>
		public BlendPerformanceReturnModel()
		{
		}

		/// <summary>Gets or sets the identifier of the BlendPerformanceID.</summary>
		/// <value>The identifier of the blend performance id.</value>
		public int BlendPerformanceID
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