using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Data
{
    public class Database : IDisposable
    {
        #region Attributes
        private static Database instance = null; // Create Database instance.
        private SqlConnection sqlConnection; // Get SqlConnection object.
        private string sqlConnectionString; // Connection string.
        private readonly IConfiguration configuration = null; // Get configuration properties.
        private readonly static object syncRoot = new Object();
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <value>
        /// The SQL connection.
        /// </value>
        public SqlConnection SqlConnection
        {
            get
            {
                sqlConnection = new SqlConnection(SqlConnectionString); // Instanciate new SqlConnection
                return sqlConnection;
            }
            private set
            {
                sqlConnection = value;
            }
        }

        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <value>
        /// The SQL connection string.
        /// </value>
        private string SqlConnectionString
        {
            get
            {
                //sqlConnectionString = configuration.GetConnectionString("LocalDatabase");
                sqlConnectionString = $"Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;";
                return sqlConnectionString;
            }
            set
            {
                sqlConnectionString = value; // Set ConnectionString
            }
        }
        #endregion

        private Database() { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null) return instance = new Database();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                SqlConnection.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
