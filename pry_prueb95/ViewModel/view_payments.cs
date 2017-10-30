using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using pry_prueb95.Models;

namespace pry_prueb95.ViewModel
{
    public class view_payments
    {
        private static configDB _conn;
        public List<payments> _getPayment(string _filter) {
            List<payments> _listPayment = new List<payments>();
            _conn = configDB._Instance;
            SqlDataReader _sqlDataRead = _conn._query("_prod_selectfac",_filter);
            while (_sqlDataRead.Read()) {
                payments _payment = new payments();
                _payment._idPayment = Convert.ToInt32(_sqlDataRead["id_payment"]);
                _payment._nameFac = _sqlDataRead["name_fac"].ToString();
                _payment._totalCost = Convert.ToInt32(_sqlDataRead["total_cost"]);
                _listPayment.Add(_payment);
            }
            _sqlDataRead.Close();
            return _listPayment;
        }

        public List<payments> _getAllPayment() {
            List<payments> _list = new List<payments>();
            _conn = configDB._Instance;
            SqlDataReader _sqlDataReader = _conn._query("_prod_statusPayments");
            while (_sqlDataReader.Read()) {
                payments _payment = new payments();
                _payment._idFac = Convert.ToInt32(_sqlDataReader["id_fac"]);
                _payment._nameFac = _sqlDataReader["name_fac"].ToString();
                _payment._totalCost = Convert.ToInt32(_sqlDataReader["Totalpagos"]);
                _list.Add(_payment);
            }
            return _list;
        }

        public void addNewPayment(payments _payment){
            _conn = configDB._Instance;
            _conn._insertPayments("_prod_payments", _payment._totalCost, _payment._idFac);
        }
    }
}