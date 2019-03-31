using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace REST_StudentCollege
{
    public class SqlHelper
    {
        public static DataSet ExecuteDataSet(string pConnectionString, CommandType pCommandType, string pCommandText)
        {
            try
            {
                return ExecuteDataSet(pConnectionString, pCommandType, pCommandText, null);
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static DataSet ExecuteDataSet(string pConnectionString, CommandType pCommandType, string pCommandText, SqlParameter[] pSqlParameters)
        {
            SqlConnection lSqlConnection = null;

            try
            {
                lSqlConnection = new SqlConnection(pConnectionString);

                SqlCommand lSqlCommand = new SqlCommand();
                lSqlCommand.CommandType = pCommandType;
                lSqlCommand.Connection = lSqlConnection;
                lSqlCommand.CommandText = pCommandText;
                lSqlCommand.CommandTimeout = 120000;

                if (pSqlParameters != null)
                {
                    foreach (SqlParameter lSqlParameter in pSqlParameters)
                        lSqlCommand.Parameters.Add(lSqlParameter);
                }

                DataSet lDataSet = new DataSet();
                SqlDataAdapter lSqlDataAdapter = new SqlDataAdapter(lSqlCommand);
                lSqlDataAdapter.Fill(lDataSet);

                return lDataSet;
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (lSqlConnection != null && lSqlConnection.State != ConnectionState.Closed)
                    lSqlConnection.Close();
            }
        }

        public static bool ExecuteNonQuery(string strConnString, string pProcedureName, SqlParameter[] pSqlParameters)
        {
            SqlConnection pSqlConnection = null;
            try
            {
                pSqlConnection = new SqlConnection(strConnString);
                SqlCommand lSqlCommand = new SqlCommand();
                lSqlCommand.CommandType = CommandType.StoredProcedure;
                lSqlCommand.Connection = pSqlConnection;
                lSqlCommand.CommandText = pProcedureName;
                lSqlCommand.CommandTimeout = 2000000000;
                if (pSqlParameters != null)
                {
                    foreach (SqlParameter lSqlParameter in pSqlParameters)
                        lSqlCommand.Parameters.Add(lSqlParameter);
                }

                pSqlConnection.Open();
                object obj;
                obj = lSqlCommand.ExecuteNonQuery();
                if (obj != null)
                {
                    if ((int)obj < 1)
                    {
                        return false;
                    }

                    else
                    {
                        return true;
                    }
                }

                else
                {
                    return false;
                }

            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (pSqlConnection.State != ConnectionState.Closed)
                    pSqlConnection.Close();
            }
        }
        public static int ExecuteNonQuery(string pConnectionString, CommandType pCommandType, string pCommandText, SqlParameter[] pSqlParameters)
        {
            SqlConnection lSqlConnection = null;

            try
            {
                lSqlConnection = new SqlConnection(pConnectionString);

                SqlCommand lSqlCommand = new SqlCommand();
                lSqlCommand.CommandType = pCommandType;
                lSqlCommand.Connection = lSqlConnection;
                lSqlCommand.CommandText = pCommandText;
                lSqlCommand.CommandTimeout = 120;

                if (pSqlParameters != null)
                {
                    foreach (SqlParameter lSqlParameter in pSqlParameters)
                        lSqlCommand.Parameters.Add(lSqlParameter);
                }

                lSqlConnection.Open();
                return lSqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (lSqlConnection != null && lSqlConnection.State != ConnectionState.Closed)
                    lSqlConnection.Close();
            }
        }

        //public static object ExecuteScalar(SqlConnection pSqlConnection, string pProcedureName, SqlParameter[] pSqlParameters)
        //{
        //    try
        //    {
        //        SqlCommand lSqlCommand = new SqlCommand();
        //        lSqlCommand.CommandType = CommandType.StoredProcedure;
        //        lSqlCommand.Connection = pSqlConnection;
        //        lSqlCommand.CommandText = pProcedureName;

        //        if (pSqlParameters != null)
        //        {
        //            foreach (SqlParameter lSqlParameter in pSqlParameters)
        //                lSqlCommand.Parameters.Add(lSqlParameter);
        //        }

        //        pSqlConnection.Open();
        //        return lSqlCommand.ExecuteScalar();
        //    }
        //    catch (SqlException sqlExp)
        //    {
        //        throw sqlExp;
        //    }
        //    catch (Exception exp)
        //    {
        //        throw exp;
        //    }
        //    finally
        //    {
        //        if (pSqlConnection.State != ConnectionState.Closed)
        //            pSqlConnection.Close();
        //    }
        //}
        public static object ExecuteScalar(string pConnectionString, CommandType pCommandType, string pCommandText, SqlParameter[] pSqlParameters)
        {
            SqlConnection lSqlConnection = null;

            try
            {
                lSqlConnection = new SqlConnection(pConnectionString);

                SqlCommand lSqlCommand = new SqlCommand();
                lSqlCommand.CommandType = pCommandType;
                lSqlCommand.Connection = lSqlConnection;
                lSqlCommand.CommandText = pCommandText;
                lSqlCommand.CommandTimeout = 120;

                if (pSqlParameters != null)
                {
                    foreach (SqlParameter lSqlParameter in pSqlParameters)
                        lSqlCommand.Parameters.Add(lSqlParameter);
                }

                lSqlConnection.Open();
                return lSqlCommand.ExecuteScalar();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (lSqlConnection != null && lSqlConnection.State != ConnectionState.Closed)
                    lSqlConnection.Close();
            }
        }
        public static DataTable ExecuteDataTable(SqlConnection pSqlConnection, string pProcedureName, SqlParameter[] pSqlParameters)
        {
            try
            {
                SqlCommand lSqlCommand = new SqlCommand();
                lSqlCommand.CommandType = CommandType.StoredProcedure;
                lSqlCommand.Connection = pSqlConnection;
                lSqlCommand.CommandText = pProcedureName;

                if (pSqlParameters != null)
                {
                    foreach (SqlParameter lSqlParameter in pSqlParameters)
                        lSqlCommand.Parameters.Add(lSqlParameter);
                }

                DataTable lDataTable = new DataTable();
                SqlDataAdapter lSqlDataAdapter = new SqlDataAdapter(lSqlCommand);
                lSqlDataAdapter.Fill(lDataTable);

                return lDataTable;
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (pSqlConnection.State != ConnectionState.Closed)
                    pSqlConnection.Close();
            }
        }

        public static SqlDataReader ExecuteDataReader(SqlConnection pSqlConnection, CommandType pCommandType, string pProcedureName, SqlParameter[] pSqlParameters)
        {
            try
            {
                SqlCommand lSqlCommand = new SqlCommand();
                lSqlCommand.CommandType = pCommandType;
                lSqlCommand.Connection = pSqlConnection;
                lSqlCommand.CommandText = pProcedureName;
                //--CHNG0001
                lSqlCommand.CommandTimeout = 240000;

                if (pSqlParameters != null)
                {
                    foreach (SqlParameter lSqlParameter in pSqlParameters)
                        lSqlCommand.Parameters.Add(lSqlParameter);
                }

                pSqlConnection.Open();
                return lSqlCommand.ExecuteReader();
            }
            catch (SqlException sqlExp)
            {
                throw sqlExp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {

            }
        }


        //public static SqlDataReader ExecuteDataReader(string pConnectionString, CommandType pCommandType, string pCommandText, SqlParameter[] pSqlParameters)
        //{
        //    SqlConnection lSqlConnection = null;

        //    try
        //    {
        //        lSqlConnection = new SqlConnection(pConnectionString);

        //        SqlCommand lSqlCommand = new SqlCommand();
        //        lSqlCommand.CommandType = pCommandType;
        //        lSqlCommand.Connection = lSqlConnection;
        //        lSqlCommand.CommandText = pCommandText;
        //        lSqlCommand.CommandTimeout = 120;

        //        if (pSqlParameters != null)
        //        {
        //            foreach (SqlParameter lSqlParameter in pSqlParameters)
        //                lSqlCommand.Parameters.Add(lSqlParameter);
        //        }

        //        lSqlConnection.Open();
        //        return lSqlCommand.ExecuteReader();
        //    }
        //    catch (SqlException sqlExp)
        //    {
        //        throw sqlExp;
        //    }
        //    catch (Exception exp)
        //    {
        //        throw exp;
        //    }
        //    finally
        //    {
        //        if (lSqlConnection != null && lSqlConnection.State != ConnectionState.Closed)
        //            lSqlConnection.Close();

        //    }
        //}
        public static DataSet GetDataSetFromReader(SqlDataReader pReader)
        {
            int cnt = 0;  //Record's count
            DataSet ds = new DataSet();
            DataTable dt;
            DataRow dr;
            dt = null;
            dr = null;

            try
            {
                dt = ds.Tables.Add();
                while (pReader.Read())
                {
                    dr = dt.NewRow();
                    if (cnt == 0)
                    {
                        //Setup the column's name
                        for (int i = 0; i < pReader.FieldCount; i++)
                        {
                            dt.Columns.Add(pReader.GetName(i));
                            dt.Columns[i].ReadOnly = true;
                        }
                    }

                    //Setup the column's value
                    for (int j = 0; j < pReader.FieldCount; j++)
                    {
                        dr[j] = pReader.GetValue(j);
                    }
                    dt.Rows.Add(dr);
                    cnt = cnt + 1;
                }
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}