using System.Linq;
using System.Web.Http;
using Performance.Data.Service;
using Swashbuckle.Application;
using Swashbuckle.OData;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(Global), "RegisterSwagger")]

namespace Performance.Data.Service
{
	/// <summary>Represents the application instance.</summary>
	public partial class Global
	{
		/// <summary>Initializes a new instance of the <see cref="Global"/> class.</summary>
		public Global()
		{
		}

		/// <summary>Register Swagger.</summary>
		public static void RegisterSwagger()
		{
			GlobalConfiguration.Configuration
				.EnableSwagger
				(c =>
				{
					c.SingleApiVersion("v1", "AssetMark Performance Data Micro-Service");
					c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
					c.IncludeXmlComments(GetXmlCommentsPath());
					c.CustomProvider
					(
						(defaultProvider) => new ODataSwaggerProvider
							(
								defaultProvider,
								c,
								GlobalConfiguration.Configuration
							)
							.Configure
							(
								config =>
								{
									config.IncludeNavigationProperties();
								}
							)
					);
				}
				)
				.EnableSwaggerUi(c => { });
		}

		private static string GetXmlCommentsPath()
		{
			string baseDirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory + @"bin\";
			string assemblyName = typeof(Global).Assembly.GetName().Name + ".xml";
			string path = baseDirectoryPath + assemblyName;
			return path;
		}
	}
}