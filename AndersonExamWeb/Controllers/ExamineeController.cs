using AndersonExamFunction;
using AndersonExamModel;
using System;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class ExamineeController : Controller
    {
        private IFExaminee _iFExaminee;
        public ExamineeController(IFExaminee iFExaminee)
        {
            _iFExaminee = iFExaminee;
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

        [HttpPost]
        public ActionResult Create(Examinee examinee)
        {
            try
            {
                //delete
                examinee = _iFExaminee.Create(examinee);
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