using System;

namespace Performance.Data.Service.Models
{
	/// <summary>A data model for the model performance model.</summary>
	public class ModelPerformanceModel
	{
		/// <summary>Initializes a new instance of the <see cref="ModelPerformanceModel"/> class.</summary>
		public ModelPerformanceModel()
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

		/// <summary>Gets or sets the identifier of the HistoricalInceptionDate.</summary>
		/// <value>The identifier of the Historical Inception Date.</value>
		public DateTime? HistoricalInceptionDate
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the AssetMarkInceptionDate.</summary>
		/// <value>The identifier of the AssetMark Inception Date.</value>
		public DateTime? AssetMarkInceptionDate
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the InitialCompositeDate.</summary>
		/// <value>The identifier of the Initial Composite Date.</value>
		public DateTime? InitialCompositeDate
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