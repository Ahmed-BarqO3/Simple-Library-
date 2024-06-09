using DVDL_dataLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Library_DataAccess
{
    public static class clsDataBorrow
    {

        public static int? AddNew(int CopyID, int? UserID, DateTime BorrowingDate, DateTime DueDate)
        {
            int? newid = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_AddBorrowingRecord", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CopyID", CopyID));
                    command.Parameters.Add(new SqlParameter("@UserID", UserID));
                    command.Parameters.Add(new SqlParameter("@BorrowingDate", BorrowingDate));
                    command.Parameters.Add(new SqlParameter("@DueDate", DueDate));

                    SqlParameter output = new SqlParameter("@NewID", DbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(output);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        newid = (int)output.Value;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return newid;
        }


        public static bool Update(int? BorrowingID, int CopyID, int? UserID, DateTime BorrowingDate, DateTime DueDate, DateTime? ActualReturnDate)
        {
            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateBorrowing", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@BorrowingID", BorrowingID));
                    command.Parameters.Add(new SqlParameter("@CopyID", CopyID));
                    command.Parameters.Add(new SqlParameter("@UserID", UserID));
                    command.Parameters.Add(new SqlParameter("@BorrowingDate", BorrowingDate));
                    command.Parameters.Add(new SqlParameter("@DueDate", DueDate));
                    command.Parameters.Add(new SqlParameter("@ActualReturnDate", ActualReturnDate));

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

        public static bool Delete(int BorrowingID)
        {
            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteBorrowing", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@BorrowingID", BorrowingID));

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

        public static bool FindByID(int CopyID, ref int UserID, ref int BorrowingID, ref DateTime BorrowingDate, ref DateTime DueDate, ref DateTime? ActualReturnDate)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_FindBorrowingByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CopyID", @CopyID));

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BorrowingID = (int)reader[0];
                                UserID = (int)reader[1];
                                BorrowingDate = (DateTime)reader[3];
                                DueDate = (DateTime)reader[4];
                                if (reader[5] != DBNull.Value)
                                    ActualReturnDate = (DateTime)reader[5];
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


        public static bool ReservationBook(int? UserID, int CopyID, DateTime ReservationDate)
        {

            bool rowAffected = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_ReservationBook", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@UserID", UserID));
                    command.Parameters.Add(new SqlParameter("@CopyID", CopyID));
                    command.Parameters.Add(new SqlParameter("@ReservationDate", ReservationDate));

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        rowAffected = true;

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }
                }
            }
            return rowAffected;
        }



        public static bool IsExist(int BorrowingID)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_IsBorrowingExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@BorrowingID", BorrowingID));

                    SqlParameter returnvalue = new SqlParameter
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnvalue);

                    try
                    {
                        connection.Open();
                        IsFound = Convert.ToInt32(command.ExecuteScalar()) == 1;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return IsFound;
        }

        public static DataTable GetAllBorrowing()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_BorrowingBooks", connection))
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

        public static bool CancelBorrow(int CopyID)
        {
            bool IsCanceled = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteBorrowing", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@CopyID", CopyID));

                    try
                    {
                        connection.Open();
                        IsCanceled = command.ExecuteNonQuery() == 1;
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
            }
            return IsCanceled;
        }
    }
}
