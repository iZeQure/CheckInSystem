using CheckInSystem.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Data
{
    public class RFIDRepository : IRFIDRepository
    {
        public bool CreateDateTimeOnRFIDCardScanned(string rfidCard)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand rfidCommand = new SqlCommand($"POST_CreateNewCheckTimeOnRFIDCardScanned", conn) { CommandType = CommandType.StoredProcedure };
                    {
                        rfidCommand.Parameters.AddWithValue($"@RFIDCard", rfidCard).Direction = ParameterDirection.Input;
                        rfidCommand.Parameters.Add($"@RFIDExists", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

                        rfidCommand.ExecuteNonQuery();

                        return (bool)Convert.ToBoolean(rfidCommand.Parameters[$"@RFIDExists"].Value);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
