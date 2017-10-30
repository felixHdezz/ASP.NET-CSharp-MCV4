using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using pry_prueb95.Models;
using System.Data;
using System.Web.UI.WebControls;

namespace pry_prueb95.ViewModel
{
    public class view_listFac
    {
        private static configDB _conn;
        public  List<ListItem> _getAllFac() {
            List<ListItem> _allFac = new List<ListItem>();
            _conn = configDB._Instance;
            SqlDataReader _slqDataRead = _conn._query("_list_fac");
            while (_slqDataRead.Read()) {
                _allFac.Add(new ListItem
                {
                    Value = _slqDataRead["id_fac"].ToString(),
                    Text = _slqDataRead["name_fac"].ToString()
                });
            }
            _slqDataRead.Close();
            return _allFac;
        }
    }
}