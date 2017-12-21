using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class ExamTimerController : BaseController
    {
        // GET: ExamTimer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CountDown()
        {
            
            return View();
        }

    }
}