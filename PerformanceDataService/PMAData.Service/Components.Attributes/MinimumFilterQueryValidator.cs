using System.Collections.Generic;
using System.Linq;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Query.Validators;
using Microsoft.OData.UriParser;

namespace Performance.Data.Service.Components.Attributes
{
	/// <summary>A minimum filter query validator. This class cannot be inherited.</summary>
	public sealed class MinimumFilterQueryValidator : FilterQueryValidator
	{
		/// <summary>Initializes a new instance of the <see cref="MinimumFilterQueryValidator"/> class.</summary>
		/// <param name="defaultQuerySettings">The default query settings.</param>
		/// <param name="minimumFilterProperties">Optional The minimum filter properties.</param>
		public MinimumFilterQueryValidator(DefaultQuerySettings defaultQuerySettings,
			string[] minimumFilterProperties = null) : base(defaultQuerySettings)
		{
			this.MinimumFilterProperties = minimumFilterProperties;
			this.IsValid = false;
		}

		/// <summary>Gets a value indicating whether this object is valid.</summary>
		/// <value>True if this object is valid, false if not.</value>
		public bool IsValid
		{
			get;
			private set;
		}

		/// <summary>Gets the minimum filter properties.</summary>
		/// <value>The minimum filter properties.</value>
		private IEnumerable<string> MinimumFilterProperties
		{
			get;
		}

		/// <summary>Validates the single value property access node.</summary>
		/// <param name="propertyAccessNode">The property access node.</param>
		/// <param name="settings">Options for controlling the operation.</param>
		public override void ValidateSingleValuePropertyAccessNode(
			SingleValuePropertyAccessNode propertyAccessNode,
			ODataValidationSettings settings)
		{
			if (this.IsValid || this.MinimumFilterProperties == null || !this.MinimumFilterProperties.Any())
			{
				this.IsValid = true;
			}
			else
			{
				string propertyName = null;

				if (propertyAccessNode != null)
				{
					propertyName = propertyAccessNode.Property.Name;
				}

				if (!string.IsNullOrWhiteSpace(propertyName) && this.MinimumFilterProperties.Contains(propertyName))
				{
					this.IsValid = true;
				}
			}

			base.ValidateSingleValuePropertyAccessNode(propertyAccessNode, settings);
		}
	}
}