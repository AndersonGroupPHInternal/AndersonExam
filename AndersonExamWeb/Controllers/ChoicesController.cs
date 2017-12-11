using AccountsWebAuthentication.Helper;
using AndersonExamFunction;
using AndersonExamModel;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class ChoiceController : BaseController
    {
        private IFChoice _iFChoice; 
        public ChoiceController(IFChoice iFChoice)
        {
            _iFChoice = iFChoice;
        }

        #region Create
        [HttpPut]
        public JsonResult Create(Choice choice)
        {
            _iFChoice.Create(choice);
            return Json(string.Empty);
        }
        #endregion

        #region Read
        [CustomAuthorize(AllowedRoles = new string[0])]
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFChoice.Read(id));
        }

        public JsonResult ReadForTakeExam(int id)
        {
            return Json(_iFChoice.ReadForTakeExam(id));
        }
        #endregion

        #region Update
        [HttpPost]
        public JsonResult Update(Choice choice)
        {
            return Json(_iFChoice.Update(choice));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(Choice choice)
        {
            _iFChoice.Delete(choice);
            return Json(string.Empty);
        }
        #endregion

    }
}