using AndersonExamFunction;
using AndersonExamModel;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{

    public class ExamSetController : Controller
    {
        private IFExamSet _iFExamSet;
        public ExamSetController(IFExamSet iFExamSet)
        {
            _iFExamSet = iFExamSet;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ExamSet());
        }

        [HttpPost]
        public ActionResult Create(ExamSet examSet)
        {
            examSet = _iFExamSet.Create(examSet);
            return RedirectToAction("Update", new { id = examSet.ExamSetId });
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
            return Json(_iFExamSet.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFExamSet.Read(id));
        }

        [HttpPost]
        public ActionResult Update(ExamSet examSet)
        {
            return View(_iFExamSet.Update(examSet));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(ExamSet examSet)
        {
            //try
            //{
                _iFExamSet.Delete(examSet);
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