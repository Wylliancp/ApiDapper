using ApiDrapper.Shared;
using System;
using System.Data;
using System.Data.SqlClient;


namespace ApiDrapper.Infra.DataContext
{
    public class ApiDapperContext : IDisposable
    {

        public ApiDapperContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public SqlConnection Connection { get; set; }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
