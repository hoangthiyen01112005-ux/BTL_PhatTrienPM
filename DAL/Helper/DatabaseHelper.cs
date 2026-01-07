using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace DAL_DatabaseHelper
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public string stringConllection { get; set; }
        public SqlConnection sqlConnect { get; set; }
        public SqlTransaction SqlTran { get; set; }

        // Constructor lấy chuỗi kết nối từ appsettings.json
        public DatabaseHelper(IConfiguration configuration)
        {
            stringConllection = configuration["ConnectionStrings:DefaultConnection"];
        }

        public void setConnection(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
                stringConllection = connectionString;
        }

        public string openConnection()
        {
            try
            {
                if (sqlConnect == null)
                    sqlConnect = new SqlConnection(stringConllection);
                if (sqlConnect.State != ConnectionState.Open)
                    sqlConnect.Open();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string closeConnection()
        {
            try
            {
                if (sqlConnect != null && sqlConnect.State != ConnectionState.Closed)
                    sqlConnect.Close();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string ExcuteNonQueryProcedure(string proName, params object[] parameters)
        {
            string result = "";
            using (SqlConnection sqlConnection = new SqlConnection(stringConllection))
            {
                sqlConnection.Open();
                using (SqlTransaction tran = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(proName, sqlConnection, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            for (int i = 0; i < parameters.Length; i += 2)
                            {
                                string paramName = Convert.ToString(parameters[i]);
                                object value = parameters[i + 1];

                                if (paramName == "@Result")
                                {
                                    cmd.Parameters.Add(new SqlParameter(paramName, SqlDbType.Int) { Direction = ParameterDirection.Output });
                                }
                                else if (paramName.ToLower().Contains("json"))
                                {
                                    cmd.Parameters.Add(new SqlParameter { ParameterName = paramName, Value = value ?? DBNull.Value, SqlDbType = SqlDbType.NVarChar });
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(paramName, value ?? DBNull.Value);
                                }
                            }
                            cmd.ExecuteNonQuery();
                            result = cmd.Parameters["@Result"].Value?.ToString() ?? "1";
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                        try { tran.Rollback(); } catch { }
                    }
                }
            }
            return result;
        }

        public DataTable ExcuteProcedureToDataTable(out string msgError, string proName, params object[] paramester)
        {
            msgError = "";
            DataTable result = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(stringConllection))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(proName, sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < paramester.Length; i += 2)
                        {
                            cmd.Parameters.AddWithValue(Convert.ToString(paramester[i]), paramester[i + 1] ?? DBNull.Value);
                        }
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(result);
                    }
                }
                catch (Exception ex) { msgError = ex.Message; }
            }
            return result;
        }

        public DataTable ExcuteProcedureToDataTable(string proName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(stringConllection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(proName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                    }
                }
                catch (Exception ex) { throw new Exception("Lỗi: " + ex.Message); }
            }
            return dt;
        }

        public List<T> ExecuteReader<T>(string sql, Dictionary<string, object> pars) where T : new()
        {
            List<T> list = new List<T>();
            using (SqlConnection con = new SqlConnection(stringConllection))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (pars != null)
                {
                    foreach (var item in pars)
                        cmd.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);
                }
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        T obj = new T();
                        foreach (PropertyInfo prop in typeof(T).GetProperties())
                        {
                            if (HasColumn(dr, prop.Name) && !dr.IsDBNull(dr.GetOrdinal(prop.Name)))
                                prop.SetValue(obj, dr[prop.Name]);
                        }
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        public int ExecuteNonQuery(string sql, Dictionary<string, object> pars)
        {
            using (SqlConnection con = new SqlConnection(stringConllection))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                if (pars != null)
                {
                    foreach (var item in pars)
                        cmd.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);
                }
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Hàm phụ kiểm tra cột tồn tại trong Reader
        private bool HasColumn(SqlDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}