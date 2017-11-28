using AccountsWebAuthentication.Helper;
using AndersonExamFunction;
using AndersonExamModel;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class QuestionController : BaseController
    {
        private IFQuestion _iFQuestion;
        public QuestionController(IFQuestion iFQuestion)
        {
            _iFQuestion = iFQuestion;
        }
        #region Create
        [HttpPut]
        public JsonResult Create(Question question)
        {
            _iFQuestion.Create(question);
            return Json(string.Empty);
        }
        #endregion

        #region Read
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFQuestion.Read(id));
        }
        //check if this is a redundant function
        [CustomAuthorize(AllowedRoles = new string[0])]
        [HttpPost]
        public JsonResult ReadQuestionForTakeExam(int id)
        {
            return Json(_iFQuestion.ReadQuestionForTakeExam(id));
        }
        #endregion

        #region Update
        [HttpPost]
        public JsonResult Update(Question question)
        {
            return Json(_iFQuestion.Update(question));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(Question question)
        {
            _iFQuestion.Delete(question);
            return Json(string.Empty);
        }
        #endregion

    }
}