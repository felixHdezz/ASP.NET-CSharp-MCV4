using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace pry_prueb95.Models
{
    public class configDB
    {
        private static configDB _instance =  null;
        private static SqlConnection _connection = null;
        public static configDB _Instance {
            get {
                if (_instance == null) { 
                    _instance = new configDB();
                }
                return _instance;
            }
        }
        private configDB() {
            string _configDB = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            _connection = new SqlConnection(_configDB);
            _connection.Open();
        }

        public void _insertPayments(string _nameProcedure, int total_cost, int id_fac) {
            SqlCommand _command = new SqlCommand(_nameProcedure, _connection);
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@total_cost",total_cost);
            _command.Parameters.AddWithValue("@id_fac", id_fac);
            _command.ExecuteNonQuery();
        }

        public SqlDataReader _query(string _nameProcedure) {
            SqlDataReader _sqlDataReader = null;
            SqlCommand _command = new SqlCommand(_nameProcedure, _connection);
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlDataReader = _command.ExecuteReader();
            _command.Cancel();
            return _sqlDataReader;
        }

        public SqlDataReader _query(string _nameProcedure, string _filter)
        {
            SqlDataReader _sqlDataReader = null;
            SqlCommand _command = new SqlCommand(_nameProcedure, _connection);
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@id_fac",_filter);
            _sqlDataReader = _command.ExecuteReader();
            _command.Cancel();
            return _sqlDataReader;
        }
    }
}