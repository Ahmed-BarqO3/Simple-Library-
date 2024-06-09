using DVDL_dataLayer;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Library_DataAccess
{
    public static class clsDataBook
    {
        public static DataTable GetAllBooks()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("SP_GetAllBooks", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = commmand.ExecuteReader())
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

        public static bool FindByID(int BookID, ref string Title, ref string ISBN, ref DateTime PublicationDate, ref string AdditionalDetails)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("SP_FindBookByID", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@BookID", BookID));

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = commmand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Title = (string)reader["Title"];
                                ISBN = (string)reader["ISBN"];
                                PublicationDate = (DateTime)reader["PublicationDate"];
                                if (reader[4] != DBNull.Value)
                                    AdditionalDetails = (string)reader["AdditionalDetails"];
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

        public static bool FindByTitle(ref int BookID, string Title, ref string ISBN, ref DateTime PublicationDate, ref string AdditionalDetails)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("[SP_FindBookByTitle]", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@Title", Title));

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = commmand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BookID = (int)reader["BookID"];
                                ISBN = (string)reader["ISBN"];
                                PublicationDate = (DateTime)reader["PublicationDate"];
                                if (reader[4] != DBNull.Value)
                                    AdditionalDetails = (string)reader["AdditionalDetails"];
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

        public static bool FindByISBN(ref int BookID, ref string Title, string ISBN, ref DateTime PublicationDate, ref string AdditionalDetails)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("[SP_FindBookByISBN]", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@ISBN", ISBN));

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = commmand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Title = (string)reader["Title"];
                                BookID = (int)reader["BookID"];
                                PublicationDate = (DateTime)reader["PublicationDate"];
                                if (reader[4] != DBNull.Value)
                                    AdditionalDetails = (string)reader["AdditionalDetails"];
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

        public static int? AddNew(string Title, string ISBN, DateTime PublicationDate, string AdditionalDetails)
        {

            int? newid = null;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("SP_AddNewBook", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@Title", Title));
                    commmand.Parameters.Add(new SqlParameter("@ISBN", ISBN));
                    commmand.Parameters.Add(new SqlParameter("@PublicationDate", PublicationDate));


                    if (AdditionalDetails != "")
                        commmand.Parameters.Add(new SqlParameter("@AdditionalDetails", AdditionalDetails));
                    else
                        commmand.Parameters.Add(new SqlParameter("@AdditionalDetails", DBNull.Value));


                    SqlParameter output = new SqlParameter("@newID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    commmand.Parameters.Add(output);

                    try
                    {
                        conn.Open();
                        commmand.ExecuteNonQuery();

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

        public static bool Update(int? ID, string Title, string ISBN, string AdditionalDetails)
        {
            int rowAffected = 0;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("SP_UpdateBook", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@ID", ID));
                    commmand.Parameters.Add(new SqlParameter("@Title", Title));
                    commmand.Parameters.Add(new SqlParameter("@ISBN", ISBN));


                    if (AdditionalDetails != null)
                        commmand.Parameters.Add(new SqlParameter("@AdditionalDetails", AdditionalDetails));
                    else
                        commmand.Parameters.Add(new SqlParameter("@AdditionalDetails", DBNull.Value));


                    try
                    {
                        conn.Open();
                        rowAffected = commmand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return rowAffected > 0;
        }

        public static bool Delete(int BookID)
        {
            int rowAffected = 0;
            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("SP_DeleteBook", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@BookID", BookID));

                    try
                    {
                        conn.Open();
                        rowAffected = commmand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.LogEx(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    }

                }
            }
            return rowAffected > 0;
        }

        public static bool IsBookExist(int BookID)
        {
            bool IsFound = false;

            using (SqlConnection conn = new SqlConnection(clsDataAccessSetting.stringConnection))
            {
                using (SqlCommand commmand = new SqlCommand("SP_IsbookExistByID", conn))
                {
                    commmand.CommandType = System.Data.CommandType.StoredProcedure;

                    commmand.Parameters.Add(new SqlParameter("@BookID", BookID));

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


