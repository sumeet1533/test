using System;

namespace Performance.Data.Service.Data.Entities
{
	/// <summary>An model performance return entity. This class cannot be inherited.</summary>
	internal sealed class ModelPerformanceReturnEntity
	{
		/// <summary>Initializes a new instance of the <see cref="ModelPerformanceReturnEntity"/> class.</summary>
		public ModelPerformanceReturnEntity()
		{
		}

		/// <summary>Gets or sets the identifier of the ModelPerformanceReturnID.</summary>
		/// <value>The identifier of the Model Performance Return ID.</value>
		public int ModelPerformanceReturnID
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the PerformanceImportID.</summary>
		/// <value>The identifier of the Model Performance Import ID.</value>
		public int PerformanceImportID
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the ModelPerformanceID.</summary>
		/// <value>The identifier of the Model Performance ID.</value>
		public int ModelPerformanceID
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
		/// <value>The identifier of the Method Type EV.</value>
		public int? MethodTypeEv
		{
			get;
			set;
		}
	}
}