using AccountsWebAuthentication.Helper;
using AndersonExamFunction;
using AndersonExamModel;
using System;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class ExamController : BaseController
    {
        private IFExam _iFExam;
        public ExamController(IFExam iFExam)
        {
            _iFExam = iFExam;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Exam());
        }

        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            exam = _iFExam.Create(exam);
            return RedirectToAction("Update", new { id = exam.ExamId });
        }
        #endregion



        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFExam.Read());
        }

        [CustomAuthorize(AllowedRoles = new string[0])]
        [HttpPost]
        public JsonResult ReadExamForExaminee()
        {
            int examineeId = Convert.ToInt32(Session["ExamineeId"]);
            return Json(_iFExam.ReadExamForExaminee(examineeId));
        }

        [HttpPost]
        public JsonResult ReadExamForPosition(int id)
        {
            return Json(_iFExam.ReadExamForPosition(id));
        }
        //Check if this is redundant business logic ang function with public ActionResult Update(int id)
        [HttpPost]
        public JsonResult ReadExamForTakeExam(int id)
        {
            return Json(_iFExam.ReadExamForTakeExam(id));
        }
        #endregion
  
        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFExam.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Exam exam)
        {
            return View(_iFExam.Update(exam));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(Exam exam)
        {
            //try
            //{
                _iFExam.Delete(exam);
                return Json(string.Empty);
            //}
            //catch (System.Exception ex)
            //{
            //    return Json(ex);
            //}
        }
        #endregion 


    }
}