using System.Data;
using Dapper;

namespace CodeApp.DB.Helpers
{
    public static class IDbConnectionHelpers
    {
        public static IDbConnection SetOracleDate(this IDbConnection sqlConnection, string dateTimeFormat = "DD/MM/RRRR")
        {
            var q2 = sqlConnection.Query<object>($"ALTER SESSION SET NLS_DATE_FORMAT = '{dateTimeFormat}'", null, commandType: CommandType.Text);
            return sqlConnection;
        }
    }
}