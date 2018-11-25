using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.OData;
using System.Web.OData.Query;
using Microsoft.OData;
using Microsoft.OData.UriParser.Aggregation;

namespace Performance.Data.Service.Components.Attributes
{
	/// <summary>Attribute for minimum filter query. This class cannot be inherited.</summary>
	[AttributeUsage(AttributeTargets.Method, Inherited = true)]
	public sealed class MinimumFilterQueryAttribute : EnableQueryAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="MinimumFilterQueryAttribute"/> class.</summary>
		public MinimumFilterQueryAttribute()
		{
		}

		/// <summary>
		/// Gets or sets when populated, at least one of these filter properties must be passed on the OData request.
		/// </summary>
		/// <value>The identifier of the minimum filter properties.</value>
		public string[] MinimumFilterProperties { get; set; }

		/// <summary>Validates the query.</summary>
		/// <exception cref="ODataException">Thrown when an O Data error condition occurs.</exception>
		/// <param name="request">The request.</param>
		/// <param name="queryOptions">Options for controlling the query.</param>
		public override void ValidateQuery(HttpRequestMessage request, ODataQueryOptions queryOptions)
		{
			if (queryOptions.Filter == null && queryOptions.Apply == null)
			{
				throw new ODataException(
							$"OData filter must include at least one of the following properties: {string.Join(", ", this.MinimumFilterProperties)} or $apply must be used with a filter.");
			}

			if (queryOptions.Apply != null)
			{
				bool isFiltered = queryOptions.Apply.ApplyClause.Transformations.Any(a => a.Kind == TransformationNodeKind.Filter);
				if (!isFiltered)
				{
					throw new ODataException($"When using $apply, a filter must be provided.");
				}
			}
			else if (queryOptions.Filter != null)
			{
				DefaultQuerySettings querySettings = new DefaultQuerySettings
				{
					EnableFilter = true,
					EnableCount = true,
					EnableOrderBy = true,
					EnableSelect = true
				};
				MinimumFilterQueryValidator queryValidator = new MinimumFilterQueryValidator(querySettings, this.MinimumFilterProperties);

				queryOptions.Filter.Validator = queryValidator;

				base.ValidateQuery(request, queryOptions);
				if (!queryValidator.IsValid)
				{
					throw new
						ODataException(
							$"OData filter must include at least one of the following properties: {string.Join(", ", this.MinimumFilterProperties)}");
				}
			}
		}

		/// <summary>Executes the action executed action.</summary>
		/// <param name="actionExecutedContext">Context for the action executed.</param>
		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			string filter = HttpUtility.ParseQueryString(actionExecutedContext.Request.RequestUri.Query).Get("$filter");
			string apply = HttpUtility.ParseQueryString(actionExecutedContext.Request.RequestUri.Query).Get("$apply");

			if (filter == null && !apply.Contains(nameof(filter)))
			{
				actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse
				(
					HttpStatusCode.BadRequest,
					$"OData filter must include at least one of the following properties: {string.Join(", ", this.MinimumFilterProperties)} or $apply must be used with a filter."
				);
			}
			base.OnActionExecuted(actionExecutedContext);
		}
	}
}