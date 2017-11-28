using AccountsWebAuthentication.Helper;
using AndersonExamFunction;
using AndersonExamModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[0])]
    public class TakenExamController : BaseController
    {
        private IFTakenExam _iFTakenExam;
        private IFAnswer _iFAnswer;
        public TakenExamController(IFTakenExam iFTakenExam, IFAnswer iFAnswer)
        {
            _iFTakenExam = iFTakenExam;
            _iFAnswer = iFAnswer;
        }

        #region Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            var takenExam = new TakenExam
            {ExamId = id};
            return View(takenExam);
        }

        [HttpPost]
        public ActionResult Create(TakenExam takenExam)
        {
            takenExam.ExamineeId = Convert.ToInt32(Session["ExamineeId"]);
            var takenExamCreated = _iFTakenExam.Create(takenExam);
            _iFAnswer.Create(takenExamCreated.TakenExamId, takenExam.Answers.ToList());
            return RedirectToAction("SelectExam", "Examinee");
        }

        #endregion

        #region Read
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFTakenExam.Read(id));
        }
        #endregion

        #region Update
        [HttpPost]
        public JsonResult Update(TakenExam takenExam)
        {
            return Json(_iFTakenExam.Update(takenExam));
        }
        #endregion

        #region Delete
        #endregion

    }
}