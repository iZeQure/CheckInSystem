using CheckInSystem.Objects;
using CheckInSystem.Objects.Helpers;
using CheckInSystem.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CheckInSystem.Data
{
    public class RoleRepository : IRoleRepository
    {
        public void Add(Role role)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand createRoleCommand = new SqlCommand($"POST_CreateNewRole", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    createRoleCommand.Parameters.AddWithValue($"@RoleName", role.Name).Direction = ParameterDirection.Input;
                    createRoleCommand.Parameters.AddWithValue($"@Description", role.Description).Direction = ParameterDirection.Input;

                    createRoleCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Delete(Role role)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand deleteRoleCommand = new SqlCommand($"DELETE_DeleteRoleById", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    deleteRoleCommand.Parameters.AddWithValue($"@RoleName", role.Name).Direction = ParameterDirection.Input;

                    deleteRoleCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public Role GetRoleBydId(string roleName)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                Role role = new Role();

                try
                {
                    conn.Open();

                    using SqlCommand getRoleCommand = new SqlCommand($"GET_GetRoleById", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    getRoleCommand.Parameters.AddWithValue($"@RoleName", roleName).Direction = ParameterDirection.Input;

                    using SqlDataReader roleReader = getRoleCommand.ExecuteReader();
                    {
                        while (roleReader.Read())
                        {
                            role = new Role
                            {
                                Name = roleReader.GetString("Name"),
                                Description = roleReader.GetString("Description")
                            };
                        }
                    }
                    return role;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<Role> GetRoles()
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                List<Role> listOfRoles = new List<Role>();
                Role role = new Role();

                try
                {
                    conn.Open();

                    using SqlCommand getRolesCommand = new SqlCommand($"GET_GetAllRoles", conn) { CommandType = CommandType.StoredProcedure };

                    using SqlDataReader getRolesReader = getRolesCommand.ExecuteReader();
                    {
                        while (getRolesReader.Read())
                        {
                            role = new Role()
                            {
                                Name = getRolesReader.GetString("Name"),
                                Description = getRolesReader.GetString("Description")
                            };
                            listOfRoles.Add(role);
                        }
                    }
                    return listOfRoles;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Update(RoleHelper role)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand updateRoleCommand = new SqlCommand($"PUT_UpdateRoleById", conn) { CommandType = CommandType.StoredProcedure };
                    {
                        updateRoleCommand.Parameters.AddWithValue($"@RoleName", role.Name).Direction = ParameterDirection.Input;
                        updateRoleCommand.Parameters.AddWithValue($"@NewRoleName", role.NewRoleName).Direction = ParameterDirection.Input;
                        updateRoleCommand.Parameters.AddWithValue($"@NewDescription", role.NewRoleDescription).Direction = ParameterDirection.Input;

                        updateRoleCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UpdateRoleDescription(Role role)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand updateRoleDecriptionCommand = new SqlCommand($"PUT_UpdateRoleDescription", conn) { CommandType = CommandType.StoredProcedure };

                    updateRoleDecriptionCommand.Parameters.AddWithValue($"@RoleName", role.Name).Direction = ParameterDirection.Input;
                    updateRoleDecriptionCommand.Parameters.AddWithValue($"@Description", role.Description).Direction = ParameterDirection.Input;

                    updateRoleDecriptionCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void UpdateRoleName(RoleHelper role)
        {
            using SqlConnection conn = Database.Instance.SqlConnection;
            {
                try
                {
                    conn.Open();

                    using SqlCommand updateRoleNameCommand = new SqlCommand($"PUT_UpdateRoleName", conn) { CommandType = CommandType.StoredProcedure };
                    {
                        updateRoleNameCommand.Parameters.AddWithValue($"@RoleName", role.Name).Direction = ParameterDirection.Input;
                        updateRoleNameCommand.Parameters.AddWithValue($"@NewRoleName", role.NewRoleName).Direction = ParameterDirection.Input;

                        updateRoleNameCommand.ExecuteNonQuery();
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
