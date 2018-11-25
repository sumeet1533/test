namespace Performance.Data.Service.Data
{
	/// <summary>A database context settings. This class cannot be inherited.</summary>
	internal sealed class DbContextSettings
	{
		/// <summary>Initializes a new instance of the <see cref="DbContextSettings"/> class.</summary>
		/// <param name="connectionName">Name of the connection.</param>
		public DbContextSettings(string connectionName)
		{
			this.ConnectionName = connectionName;
		}

		/// <summary>Gets the name of the connection.</summary>
		/// <value>The name of the connection.</value>
		public string ConnectionName
		{
			get;
		}
	}
}