using AndersonExamFunction;
using AndersonExamModel;
using System;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class TakenExamController : Controller
    {
        private IFTakenExam _iFTakenExam;
        public TakenExamController(IFTakenExam iFTakenExam)
        {
            _iFTakenExam = iFTakenExam;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new TakenExam());
        }

        [HttpPost]
        public ActionResult Create(TakenExam takenExam)
        {
            takenExam.ExamineeId = Convert.ToInt32(Session["ExamineeId"]);
            takenExam = _iFTakenExam.Create(takenExam);
            return RedirectToAction("SelectExam");
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