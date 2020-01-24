using CheckInSystem.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Data
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        public bool AuthenticateLogInCredentials(string userName, string password)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand authLogInCredentialsCommand = new SqlCommand($"POST_AuthenticateLogInCredentials", conn) { CommandType = CommandType.StoredProcedure };
                    {
                        authLogInCredentialsCommand.Parameters.AddWithValue($"@UserName", userName).Direction = ParameterDirection.Input;
                        authLogInCredentialsCommand.Parameters.AddWithValue($"@Password", password).Direction = ParameterDirection.Input;
                        authLogInCredentialsCommand.Parameters.Add($"@Authentication", sqlDbType: SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

                        authLogInCredentialsCommand.ExecuteNonQuery();

                        return (bool)Convert.ToBoolean(authLogInCredentialsCommand.Parameters["@Authentication"].Value);
                    }
                }
                catch (SqlException)
                {
                    return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
