using DVDL_dataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Library_DataAccess
{
    public static class clsDataBookCopies
    {
        public static int? AddNew(int BookID)
        {
            int? newid = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewBookCoies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@BookID", BookID));


                    SqlParameter output = new SqlParameter("@CopyID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(output);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        newid = (int?)output.Value;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return newid;
        }

        public static bool Update(int? CopyID, int BookID, bool AvailabilityStatus)
        {

            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateBookCoies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CopyID", CopyID));
                    command.Parameters.Add(new SqlParameter("@BookID", BookID));
                    command.Parameters.Add(new SqlParameter("@AvailabilityStatus", AvailabilityStatus));

                    try
                    {
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return rowAffected > 0;
        }

        public static bool Delete(int CopyID)
        {

            int rowAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteBookCoies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CopyID", CopyID));

                    try
                    {
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return rowAffected > 0;
        }

        public static bool FindByID(int CopyID, ref int BookID, ref bool AvailabilityStatus)
        {

            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_FindBookCopyByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CopyID", CopyID));

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BookID = (int)reader["BookID"];
                                AvailabilityStatus = (bool)reader["AvailabilityStatus"];
                                IsFound = true;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return IsFound;
        }

        public static DataTable GetAllBookCopies()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllBookCopies", connection))
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
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return dt;
        }




    }
}
