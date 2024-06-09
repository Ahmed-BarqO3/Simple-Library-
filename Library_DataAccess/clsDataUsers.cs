using DVDL_dataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Library_DataAccess
{
    public static class clsDataUsers
    {

        static public bool FindUserByID(int? id, ref string Name, ref string contact, ref string CardNum)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("spFindUserByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = id;

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Name = (string)reader["Name"];
                                contact = (string)reader["ContactInformation"];
                                CardNum = (string)reader["LibraryCardNumber"];
                                IsFound = true;
                            }


                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, EventLogEntryType.Error);
                    }
                    finally { connection.Close(); }
                }
            }
            return IsFound;
        }

        static public bool FindUserByCardNum(ref int id, ref string Name, ref string contact, string CardNum)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("spFindUserByCardNum", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@CardNum", CardNum));

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Name = (string)reader["Name"];
                                contact = (string)reader["ContactInformation"];
                                id = (int)reader["UserID"];
                            }

                            IsFound = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, EventLogEntryType.Error);
                    }
                    finally { connection.Close(); }
                }
            }
            return IsFound;
        }
        public static int? AddNew(string name, string email, string cardNumber)
        {
            int? newId = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("spAddUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@contact", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@CardNum", SqlDbType.NVarChar).Value = cardNumber;

                    SqlParameter outputIdParam = new SqlParameter("@UserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        newId = (int)outputIdParam.Value;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return newId;
        }


        static public bool Delete(int id)
        {
            bool IsTrue = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("spDeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = id;

                    try
                    {
                        connection.Open();
                        IsTrue = command.ExecuteNonQuery() > 0;

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, EventLogEntryType.Error);
                    }


                }
            }

            return IsTrue;
        }

        static public bool Update(string Name, string contact, int? id)
        {
            bool IsTrue = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("spUpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                    command.Parameters.Add("@contact", SqlDbType.NVarChar).Value = contact;
                    command.Parameters.Add("@UserID", SqlDbType.Int).Value = id;

                    try
                    {
                        connection.Open();
                        IsTrue = command.ExecuteNonQuery() > 0;

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, EventLogEntryType.Error);
                    }


                }
            }

            return IsTrue;
        }

        static public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("spGetAllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, EventLogEntryType.Error);
                    }
                    finally { connection.Close(); }
                }
            }
            return dt;
        }

        public static bool IsUserExist(int UserID)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("SP_IsUserExistByID", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@UserID", UserID));

                    SqlParameter returnvalue = new SqlParameter
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    commmand.Parameters.Add(returnvalue);

                    try
                    {
                        conn.Open();
                        commmand.ExecuteScalar();

                        IsFound = (int)returnvalue.Value == 1;

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return IsFound;
        }
    }
}



