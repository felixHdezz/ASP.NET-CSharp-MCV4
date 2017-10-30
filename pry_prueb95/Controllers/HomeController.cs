using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pry_prueb95.Models;
using System.Web.UI.WebControls;
using pry_prueb95.ViewModel;

namespace pry_prueb95.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            
            return View();
        }

        [HttpPost]
        public ActionResult DropSalect() {
            view_listFac _list = new view_listFac();
            return Json(_list._getAllFac(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult addUser(payments _payment) {
            if (ModelState.IsValid) {
                view_payments _payments = new view_payments();
                _payments.addNewPayment(_payment);
                return Json(_payments._getPayment(_payment._idFac.ToString()),JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        [HttpPost]
        public ActionResult statusPayments() {
            view_payments _payments = new view_payments();
            return Json(_payments._getAllPayment(), JsonRequestBehavior.AllowGet);
        }
    }
}