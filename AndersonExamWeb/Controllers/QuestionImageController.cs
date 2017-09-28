using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AndersonExamFunction;
using AndersonExamModel;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class QuestionImageController : Controller
    {
        private IFQuestionImage _iFQuestionImage;
        public QuestionImageController(IFQuestionImage iFQuestionImage)
        {
            _iFQuestionImage = iFQuestionImage;
        }

        #region Create
        [HttpPut]
        public JsonResult Create(QuestionImage questionImage)
        {
            _iFQuestionImage.Create(questionImage);
            return Json(string.Empty);
        }
        #endregion

        #region Read
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFQuestionImage.Read(id));
        }
        #endregion

        #region Update
        //[HttpPost]
        //public JsonResult Update(QuestionImage questionImage)
        //{
        //    return Json(_iFQuestionImage.Update(questionImage));
        //}
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(QuestionImage questionImage)
        {
            _iFQuestionImage.Delete(questionImage);
            return Json(string.Empty);
        }
        #endregion
    }
}