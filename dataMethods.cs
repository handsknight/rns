using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Forms;




namespace rns
{
    class datamethods2
    {
        #pragma warning disable
      
        

        //string erd = Properties.Settings.Default.rnsConString;
        // to save to seetings: Properties.Settings.Default.Save();
        //OR
        public String connectionString = ConfigurationManager.ConnectionStrings["rnsConString"].ConnectionString;
        public String connectionString_RIMS = ConfigurationManager.ConnectionStrings["rnsConString_rims"].ConnectionString;
        public String connectionString_webdb = ConfigurationManager.ConnectionStrings["rnsConString_webdb"].ConnectionString;

        SqlDataAdapter daRecords = new SqlDataAdapter();
        DataSet dsRecords = new DataSet();
        DataTable dtRecords = new DataTable();
        SqlDataReader drSelect = null;
    

        public String sqlUserError = string.Empty;

        //----------------------  methods ---------------------- 

        public DataSet _dataSet_NoParameter(string queryString)
        {

            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                daRecords = new SqlDataAdapter(comm);
                daRecords.Fill(dsRecords);
                return dsRecords;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return dsRecords;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();

            }

        }
        public DataSet _dataSet_NoParameter(string queryString, string connString)
        {

            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                daRecords = new SqlDataAdapter(comm);
                daRecords.Fill(dsRecords);
                return dsRecords;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return dsRecords;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();

            }

        }
        public DataTable _dataTable_NoParameter(string queryString)
        {
            
            try
            {
               
   
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                daRecords = new SqlDataAdapter(comm);
                daRecords.Fill(dtRecords);
                return dtRecords;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message; 
                return dtRecords;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();

            }

        }
        public DataTable _dataTable_NoParameter(string queryString, string connString)
        {

            try
            {

                dtRecords.Rows.Clear();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                daRecords = new SqlDataAdapter(comm);
                daRecords.Fill(dtRecords);


                return dtRecords;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return dtRecords;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();

            }

        }
        public DataTable _dataTable_NoParameter_RIMS(string queryString)
        {

            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString_RIMS;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                daRecords = new SqlDataAdapter(comm);
                daRecords.Fill(dtRecords);
                return dtRecords;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return dtRecords;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();

            }

        }
        public DataTable _dataTable_NoParameter_webdb(string queryString)
        {

            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString_webdb;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                daRecords = new SqlDataAdapter(comm);
                daRecords.Fill(dtRecords);
                return dtRecords;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return dtRecords;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();

            }

        }
        public SqlDataReader _dataReader_NoParameter(string queryString)
        {
           
            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionString;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                drSelect = comm.ExecuteReader();
                return drSelect;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;

                return drSelect;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();
               
            }

        }
        public SqlDataReader _dataReader_NoParameter(string queryString, string connString)
        {

            try
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                drSelect = comm.ExecuteReader();
                return drSelect;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return drSelect;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();
                drSelect = null;
            }

        }
        public int _update_Insert_NoParameter(string queryString)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                Int32 int_success = comm.ExecuteNonQuery();
                return int_success;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return -1;
            }
        }
        public int _update_Insert_NoParameter(string queryString, string connString)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand comm = new SqlCommand(queryString, conn);
                Int32 int_success = comm.ExecuteNonQuery();
                return int_success;
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
                return -1;
            }
        }
        public int _update_Insert_WithParameter_Using_Query_Only(string queryString, string[] paraNames, string[] inputVals, SqlDbType[] inDataType)
        {

            // add the parameters 
            try
            {
                if (paraNames.Length == inputVals.Length && paraNames.Length == inDataType.Length)
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand comm = new SqlCommand(queryString, conn);

                    for (int i = 0; i <= paraNames.Length - 1; i++)
                    {
                        comm.Parameters.Add(paraNames[i], inDataType[i]);
                        comm.Parameters[paraNames[i]].Value = inputVals[i];
                    }
                    int intUpdatedRows = comm.ExecuteNonQuery();
                    return intUpdatedRows;
                }
                else
                {
                    sqlUserError = "Parameter lenght is not equal to the value lenght";
                    return -1;
                }

            }
            catch (SqlException er)
            {

                sqlUserError = er.Message;
                return -1;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();
                drSelect = null;
            }
        }
        public int _update_WithParameter_NoQuery_Using_Where(string[] paraNames, string[] inputVals, SqlDbType[] inDataType, string strTableName, string strWhere, string[] whereParameters, string[] whereParametersValues, string[] whereDataType)
        {
        
            
           // contrusct the update sql statment from the list of parameters 
            string strQuery = " update " + strTableName + " set ";
            foreach (string paraName in paraNames)
            {
                strQuery = strQuery + paraName + " = @" + paraName + ",";
            }

            // remove the last comma
            strQuery = strQuery.Substring(0, strQuery.Length - 1);


            // add the where parameters
            if (whereParameters.Length > 0 && strWhere != string.Empty && whereParameters.Length == whereParametersValues.Length)
            {
                strQuery = strQuery + " where ";
                foreach (string paraName in whereParameters)
                {
                    strQuery = strQuery + paraName + " = @" + paraName + " and ";
                }
            }
            

            // remove the last and
            strQuery = strQuery.Substring(0, strQuery.Length - 3);

            // add the parameters 
            try
            {
                if (paraNames.Length == inputVals.Length && paraNames.Length == inDataType.Length)
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand comm = new SqlCommand(strQuery, conn);

                    for (int i = 0; i <= paraNames.Length - 1; i++)
                    {
                        comm.Parameters.Add(paraNames[i], inDataType[i]);
                        comm.Parameters[paraNames[i]].Value = inputVals[i];
                    }

                    // where parameters
                    if (whereParameters.Length > 0 && strWhere != string.Empty && whereParameters.Length == whereParametersValues.Length)
                    {
                        for (int i = 0; i <= whereParameters.Length - 1; i++)
                        {
                            comm.Parameters.Add(whereParameters[i], whereDataType[i]);
                            comm.Parameters[paraNames[i]].Value = whereParametersValues[i];
                        }
                    }
                    int intUpdatedRows = comm.ExecuteNonQuery();
                    return intUpdatedRows;
                }
                else
                {
                    sqlUserError = "Parameter lenght is not equal to the value lenght";
                    return -1;
                }

            }
            catch (SqlException er)
            {
         
                sqlUserError = er.Message;
                return -1;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();
                drSelect = null;
            }
        }
        
        public int _Insert_WithParameter_NoQuery_Using_Where(string[] paraNames, string[] inputVals, SqlDbType[] inDataType, string strTableName)
        {


            // contrusct the insert sql statment from the list of columns from the parameter 
            string strQuery = " insert into " + strTableName + " ( ";
            foreach (string paraName in paraNames)
            {
                strQuery = strQuery + paraName + ",";
            }

            // remove the last comma
            strQuery = strQuery.Substring(0, strQuery.Length - 1);

            // add the last bracket
            strQuery = strQuery + ")";

            // add the begining if of the value character of the insert statement
            strQuery = strQuery + " value (";

            // intert the values paramter @ of the query 
            foreach (string paraName in paraNames)
            {
                strQuery = strQuery + " @" + paraName + "," ;
            }

            // remove the last comma
            strQuery = strQuery.Substring(0, strQuery.Length - 1);

   
            // add the last bracket
            strQuery = strQuery + ")";

                      
            // add the parameters 
            try
            {
                if (paraNames.Length == inputVals.Length && paraNames.Length == inDataType.Length)
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand comm = new SqlCommand(strQuery, conn);

                    for (int i = 0; i <= paraNames.Length - 1; i++)
                    {
                        comm.Parameters.Add(paraNames[i], inDataType[i]);
                        comm.Parameters[paraNames[i]].Value = inputVals[i];
                    }

                    
                    int intUpdatedRows = comm.ExecuteNonQuery();
                    return intUpdatedRows;
                }
                else
                {
                    sqlUserError = "Parameter lenght is not equal to the value lenght";
                    return -1;
                }

            }
            catch (SqlException er)
            {

                sqlUserError = er.Message;
                return -1;
            }
            finally
            {
                dtRecords.Dispose();
                daRecords.Dispose();
                dsRecords.Dispose();
                drSelect = null;
            }
        }
        public void audittray(string frmAction)
        {

            try
            {
               
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string sqlInsert = string.Empty;
                sqlInsert = @" insert into audittray (userid,username,frmName,action,cdate) 
                values (" + Program.pbUserID + "," + Program.pbUserName + "," + Program.pbFormName + "," + frmAction + ","
                 + DateTime.Now.ToString() + ")";

                SqlCommand comm = new SqlCommand(sqlInsert, conn);
                comm.ExecuteNonQuery();
                
            }
            catch (SqlException er)
            {
                sqlUserError = er.Message;
              
            } 

        }
    }
   
}
