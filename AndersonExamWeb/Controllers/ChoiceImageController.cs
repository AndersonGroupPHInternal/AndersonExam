using AndersonExamFunction;
using AndersonExamModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class ChoiceImageController : Controller
    {
        private IFChoiceImage _iFChoiceImage;
        public ChoiceImageController(IFChoiceImage iFChoiceImage)
        {
            _iFChoiceImage = iFChoiceImage;
        }

        #region Create
        [HttpPut]
        public JsonResult Create(ChoiceImage choiceImage)
        {
            _iFChoiceImage.Create(choiceImage);
            return Json(string.Empty);
        }
        #endregion
        [HttpPost]
        public ActionResult ChoiceAddImage(ChoiceImage choiceImage, int choiceId, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                fileName = fileName.Split('\\').Last(); //This will fix problems when uploading using IE
                var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                file.SaveAs(path);
                choiceImage.Url = fileName;
            }
            _iFChoiceImage.Create(choiceImage);
            return Json(string.Empty);
        }
        #region Read
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFChoiceImage.Read(id));
        }

        public JsonResult ReadForTakeExam(int id)
        {
            return Json(_iFChoiceImage.ReadForTakeExam(id));
        }
        #endregion

        #region Update
        //[HttpPost]
        //public JsonResult Update(ChoiceImage choiceImage)
        //{
        //    return Json(_iFChoiceImage.Update(choiceImage));
        //}
        #endregion

        #region Delete
        public JsonResult Delete(ChoiceImage choiceImage)
        {
            _iFChoiceImage.Delete(choiceImage);
            return Json(string.Empty);
        }
        #endregion
    }
}