using DVDL_dataLayer;
using System;
using System.Data.SqlClient;

namespace Library_DataAccess
{
    public static class clsDataSetting
    {

        public static bool Update(byte defultBorrowDays, decimal FinePerDay)
        {
            int rowaffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateSetting", connection))
                {
                    command.Parameters.Add(new SqlParameter("@BorrowDays", defultBorrowDays));
                    command.Parameters.Add(new SqlParameter("@@FinePerDaye", FinePerDay));


                    try
                    {
                        connection.Open();
                        rowaffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }

                }
            }
            return rowaffected > 0;

        }

        public static bool GetSetting(ref byte defultBorrowDays, ref decimal FinePerDay)
        {

            bool flag = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_GetSetting", connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                defultBorrowDays = (byte)reader[0];
                                FinePerDay = (decimal)reader[1];
                                flag = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);

                    }

                }
            }
            return flag;

        }


    }
}
