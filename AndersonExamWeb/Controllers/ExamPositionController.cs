using AndersonExamFunction;
using AndersonExamModel;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class ExamPositionController : Controller
    {
        private IFExamPosition _iFExamPosition;
        public ExamPositionController(IFExamPosition iFExamPosition)
        {
            _iFExamPosition = iFExamPosition;
        }

        #region Create
        [HttpPut]
        public JsonResult Create(ExamPosition examPosition)
        {
            _iFExamPosition.Create(examPosition);
            return Json(string.Empty);
        }
        #endregion

        #region Read
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFExamPosition.Read(id));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(ExamPosition examPosition)
        {
            _iFExamPosition.Delete(examPosition);
            return Json(string.Empty);
        }
        #endregion
    }
}