using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DAL_DatabaseHelper
{
    public interface IDatabaseHelper
    {
        string stringConllection { get; set; }
        SqlConnection sqlConnect { get; set; }
        SqlTransaction SqlTran { get; set; }

        void setConnection(string connectionString);
        string openConnection();
        string closeConnection();
        string ExcuteNonQueryProcedure(string proName, params object[] parameters);
        DataTable ExcuteProcedureToDataTable(out string msgError, string proName, params object[] paramester);
        DataTable ExcuteProcedureToDataTable(string proName);

        // Hai hàm này cực kỳ quan trọng để DAL_DichVu không bị lỗi
        List<T> ExecuteReader<T>(string sql, Dictionary<string, object> pars) where T : new();
        int ExecuteNonQuery(string sql, Dictionary<string, object> pars);
    }
}