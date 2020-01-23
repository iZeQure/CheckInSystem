using CheckInSystem.Objects;
using CheckInSystem.Objects.Helpers;
using CheckInSystem.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Data
{
    public class UserRepository : IUserRepository
    {
        public bool Add(User add)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand command = new SqlCommand($"POST_CreateNewUser", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue($"UserName", add.Id).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"FirstName", add.FirstName).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"LastName", add.LastName).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"PhoneNumber", add.PhoneNumber).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"Password", add.Password).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"RFIDCard", add.RFIDCard).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"UserRole", add.Role.Name).Direction = ParameterDirection.Input;
                    command.Parameters.Add($"@CheckUserCreated", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    return (bool)Convert.ToBoolean(command.Parameters[$"@CheckUserCreated"].Value);
                }
                catch (SqlException)
                {
                    return false;
                }
                catch (DuplicateNameException)
                {
                    return false;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<User> GetAll()
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                List<User> listOfUsers = new List<User>();

                try
                {
                    conn.Open();

                    using SqlCommand getUsers_Command = new SqlCommand($"GET_GetAllUsers", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using SqlDataReader reader = getUsers_Command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            listOfUsers.Add(new User()
                            {
                                Id = reader.GetString("UserName"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                PhoneNumber = reader.GetString("PhoneNumber"),
                                RFIDCard = reader.GetString("RFIDCard"),
                                Role = new Role()
                                {
                                    Name = reader.GetString("Role_Name"),
                                    Description = reader.GetString("Description")
                                },
                                IsDisabled = reader.GetBoolean("IsDisabled"),
                                CheckTime = new List<DateTime>()

                            });
                        }
                    }

                    reader.Close();

                    foreach (User user in listOfUsers)
                    {
                        using SqlCommand getCheckTimes = new SqlCommand($"GET_GetAllCheckTimesnUserNameByDynamicUserName", conn)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        getCheckTimes.Parameters.AddWithValue("@Username", user.Id);

                        using SqlDataReader sqlDataReader = getCheckTimes.ExecuteReader();

                        if (reader.IsClosed)
                        {
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    user.CheckTime.Add(sqlDataReader.GetDateTime("CardReadTime"));
                                }
                            }
                        }
                    }

                    return listOfUsers;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public User GetById(string userName)
        {

            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                User userDetails = new User();

                try
                {
                    conn.Open();

                    using SqlCommand getUserDetails_Command = new SqlCommand($"GET_GetUserDetailsByUserName", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    getUserDetails_Command.Parameters.AddWithValue($"@UserName", userName);

                    using SqlDataReader userDetailsReader = getUserDetails_Command.ExecuteReader();

                    if (userDetailsReader.HasRows)
                    {
                        while (userDetailsReader.Read())
                        {
                            userDetails = new User()
                            {
                                Id = userDetailsReader.GetString(0),
                                FirstName = userDetailsReader.GetString(1),
                                LastName = userDetailsReader.GetString(2),
                                PhoneNumber = userDetailsReader.GetString(3),
                                IsDisabled = userDetailsReader.GetBoolean(4),
                                RFIDCard = userDetailsReader.GetString(5),
                                Role = new Role()
                                {
                                    Name = userDetailsReader.GetString(6)
                                },
                                CheckTime = new List<DateTime>()

                            };
                        }
                    }

                    userDetailsReader.Close();

                    using SqlCommand userCheckTimesCommand = new SqlCommand($"GET_GetUserCheckTimeDetailsByUserName", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    userCheckTimesCommand.Parameters.AddWithValue("@UserName", userName);

                    using SqlDataReader userCheckTimesReader = userCheckTimesCommand.ExecuteReader();

                    if (userDetailsReader.IsClosed)
                    {
                        if (userCheckTimesReader.HasRows)
                        {
                            while (userCheckTimesReader.Read())
                            {
                                userDetails.CheckTime.Add(userCheckTimesReader.GetDateTime(0));
                            }
                        }
                    }

                    return userDetails;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Update(User update)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand command = new SqlCommand($"PUT_UpdateUsersInformationByUserName", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue($"@UserName", update.Id).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"@FirstName", update.FirstName).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"@LastName", update.LastName).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"@PhoneNumber", update.PhoneNumber).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"@Password", update.Password).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"@IsDisabled", update.IsDisabled).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"@RFIDCard", update.RFIDCard).Direction = ParameterDirection.Input;
                    command.Parameters.AddWithValue($"@UserRole", update.Role.Name).Direction = ParameterDirection.Input;

                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void DisableUser(string id)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand command = new SqlCommand($"PUT_DisableUserByUserName", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue($"@UserName", id).Direction = ParameterDirection.Input;

                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void ActivateUser(string id)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand activateUserCommand = new SqlCommand($"PUT_ActivateUserByUserName", conn) { CommandType = CommandType.StoredProcedure };
                    {
                        activateUserCommand.Parameters.AddWithValue($"@UserName", id).Direction = ParameterDirection.Input;

                        activateUserCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool ChangeUserPassword(UserHelper user)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand changeUserPasswordCommand = new SqlCommand($"PUT_ChangeUserPasswordByUserName", conn) { CommandType = CommandType.StoredProcedure };
                    {
                        changeUserPasswordCommand.Parameters.AddWithValue($"@UserName", user.Id).Direction = ParameterDirection.Input;
                        changeUserPasswordCommand.Parameters.AddWithValue($"@Password", user.Password).Direction = ParameterDirection.Input;
                        changeUserPasswordCommand.Parameters.AddWithValue($"@NewPassword", user.NewPassword).Direction = ParameterDirection.Input;
                        changeUserPasswordCommand.Parameters.Add($"@PasswordValidation", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

                        changeUserPasswordCommand.ExecuteNonQuery();

                        return Convert.ToBoolean(changeUserPasswordCommand.Parameters["@PasswordValidation"].Value);
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

        public bool ChangeUserRFID(User user)
        {
            throw new NotImplementedException();
        }

        public bool ChangeUserRole(User user)
        {
            throw new NotImplementedException();
        }
    }
}
