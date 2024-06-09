using DVDL_dataLayer;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Library_DataAccess
{




    public static class clsDataFines
    {

        public static bool GetFineInfo(int CopyID, ref int BorrowingID, ref int FineID, ref int UserID,
            ref byte LateDays, ref decimal Amount, ref bool PaymentStatus)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_GetFineByCopyID", connection))
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
                                BorrowingID = (int)reader["BorrowingRecordID"];
                                FineID = (int)reader["FineID"];
                                UserID = (int)reader["UserID"];



                                Amount = (decimal)reader["FineAmount"];
                                PaymentStatus = (bool)reader["PaymentStatus"];
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

        public static DataTable GetAllFines(int FineID)
        {
            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllFines", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@FineID", FineID));

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
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

        public static int? AddNew(int UserID, int BorrowingRecordID, byte NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            int? newid = null;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_AddFine", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@UserID", UserID));
                    command.Parameters.Add(new SqlParameter("@BorrowingRecordID", BorrowingRecordID));
                    command.Parameters.Add(new SqlParameter("@NumberOfLateDays", NumberOfLateDays));
                    command.Parameters.Add(new SqlParameter("@FineAmount", FineAmount));
                    command.Parameters.Add(new SqlParameter("@PaymentStatus", PaymentStatus));


                    SqlParameter output = new SqlParameter("@newid", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    try
                    {
                        connection.Open();
                        newid = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }

            return newid;
        }

        public static bool Update(int UserID, int BorrowingRecordID, byte NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            int? rowAffected = null;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateFine", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@UserID", UserID));
                    command.Parameters.Add(new SqlParameter("@BorrowingRecordID", BorrowingRecordID));
                    command.Parameters.Add(new SqlParameter("@NumberOfLateDays", NumberOfLateDays));
                    command.Parameters.Add(new SqlParameter("@FineAmount", FineAmount));
                    command.Parameters.Add(new SqlParameter("@PaymentStatus", PaymentStatus));


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

        public static bool Delete(int FineID)
        {
            int? rowAffected = null;


            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteFine", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@FineID", FineID));



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

    }
}
