using AndersonExamFunction;
using AndersonExamModel;
using System;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AndersonExamWeb.Controllers
{
    public class ExamineeController : Controller
    {
        private IFExaminee _iFExaminee;
        private IFExam _iFExam;
        public ExamineeController(IFExaminee iFExaminee, IFExam iFExam)
        {
            _iFExaminee = iFExaminee;
            _iFExam = iFExam;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {

            try
            {
                return View(new Examinee());
            }
            catch (Exception ex)
            {
                return Json(ex);

            }
        }

        [HttpGet]
        public ActionResult SelectExam()
        {
            try
            {
                return View(new Examinee());
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public ActionResult Create(Examinee examinee)
        {
            Session["ExamineeId"] = null;
            try
            {
                examinee = _iFExaminee.Create(examinee);
                Session["ExamineeId"] = examinee.ExamineeId;
                return RedirectToAction("SelectExam");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TakeExam(int id)
        {
            return View(_iFExam.ReadExamForTakeExam(id));
        }

        [HttpPost]
        public JsonResult Percentage(int id)
        {
            return Json(_iFExaminee.Percentage(id));
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFExaminee.Read());
        }

        [HttpGet]
        public ActionResult TakenExam(int id)
        {
            return View(id);
        }
        #endregion

        #region Update
        [HttpPost]
        public JsonResult Update(Examinee Examinee)
        {
            return Json(_iFExaminee.Update(Examinee));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFExaminee.Delete(id);
            return Json(string.Empty);
        }
        #endregion

    }
}