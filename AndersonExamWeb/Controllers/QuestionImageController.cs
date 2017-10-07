using System;
using System.Collections.Generic;
using AndersonExamFunction;
using AndersonExamModel;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Linq;

namespace AndersonExamWeb.Controllers
{
    public class QuestionImageController : Controller
    {
        public ActionResult Exam()
        {
            return View();
        }
        private IFQuestionImage _iFQuestionImage;
        public QuestionImageController(IFQuestionImage iFQuestionImage)
        {
            _iFQuestionImage = iFQuestionImage;
        }

        #region Create
        [HttpPost]
        public JsonResult Create(QuestionImage questionImage)
        {
            _iFQuestionImage.Create(questionImage);
            return Json(string.Empty);
        }
        #endregion 

        #region QuestionAddImage
        [HttpPost]
        public ActionResult QuestionAddImage(QuestionImage questionImage, int questionId, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                fileName = fileName.Split('\\').Last(); //This will fix problems when uploading using IE
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
                questionImage.Url = path;
            }
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