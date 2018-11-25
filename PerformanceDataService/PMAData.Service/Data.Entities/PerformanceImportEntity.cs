using System;

namespace Performance.Data.Service.Data.Entities
{
	/// <summary>An performance import entity. This class cannot be inherited.</summary>
	internal sealed class PerformanceImportEntity
	{
		/// <summary>Initializes a new instance of the <see cref="PerformanceImportEntity"/> class.</summary>
		public PerformanceImportEntity()
		{
		}

		/// <summary>Gets or sets the identifier of the PerformanceImportID.</summary>
		/// <value>The identifier of the Model Performance Import ID.</value>
		public int PerformanceImportID
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the PerformanceTypeEV.</summary>
		/// <value>The identifier of the Model PerformanceTypeEV.</value>
		public int PerformanceTypeEv
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the FrequencyTypeEV.</summary>
		/// <value>The identifier of the Model Frequency Type EV.</value>
		public int FrequencyTypeEv
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the Name.</summary>
		/// <value>The identifier of the Model Name.</value>
		public string Name
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the StatusTypeEV.</summary>
		/// <value>The identifier of the Model Status Type EV.</value>
		public int StatusTypeEv
		{
			get;
			set;
		}

		/// <summary>Gets or sets the identifier of the Note.</summary>
		/// <value>The identifier of the Model Note.</value>
		public string Note
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