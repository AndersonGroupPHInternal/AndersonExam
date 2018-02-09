using AccountsWebAuthentication.Helper;
using AndersonExamFunction;
using AndersonExamModel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AndersonExamWeb.Controllers
{
    public class ExamineeController : BaseController
    {
        private IFExaminee _iFExaminee;
        private IFExam _iFExam;
        private IFPosition _iFPosition;
        public ExamineeController(IFExaminee iFExaminee, IFExam iFExam, IFPosition iFPosition)
        {
            _iFExaminee = iFExaminee;
            _iFExam = iFExam;
            _iFPosition = iFPosition;


        }


        #region Create
        [CustomAuthorize(AllowedRoles = new string[0])]
        [HttpGet]
        public ActionResult Create( string Firstname, string positionName, string firstName, string middleName, string lastName, string referencecode)
        {
            try
            {
                var examinee = new Examinee
                
                {
                    ReferenceCode = referencecode,
                    Lastname = lastName,
                    Firstname = firstName,
                    Middlename = middleName,
                };
                
                var position = _iFPosition.Read(positionName);
                if(position.PositionId != 0)
                {
                    examinee.PositionId = position.PositionId;
                    examinee = _iFExaminee.Create(examinee);
                    Session["ExamineeId"] = null;
                    Session["ExamineeId"] = examinee.ExamineeId;
                    return RedirectToAction("SelectExam", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View(examinee);
                }
            }  
             
           catch (Exception ex)
            {
                return RedirectToAction("Create") ;
            }
          }

        

        //[CustomAuthorize(AllowedRoles = new string[0])]
        //[HttpGet]
        //public ActionResult Create()
        //{

        //    try
        //    {
        //        return View(new Examinee());
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex);

        //    }
        //}

        [CustomAuthorize(AllowedRoles = new string[0])]
        [HttpGet]
        public ActionResult SelectExam()
        {
            try
            {
                return View(new Examinee());
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        [CustomAuthorize(AllowedRoles = new string[0])]
        [HttpPost]
        public ActionResult Create(Examinee examinee)
        {
            Session["ExamineeId"] = null;
            try
            {
                examinee = _iFExaminee.Create(examinee);
                Session["ExamineeId"] = examinee.ExamineeId;
                return RedirectToAction("SelectExam");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FindPromo()
        {
            var promoId = Convert.ToInt32(Request.Form["ddlPromotion"]);
            return RedirectToAction("GetPromo", new { id = promoId });
        }
        #endregion          

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(AllowedRoles = new string[0])]
        [HttpGet]
        public ActionResult TakeExam(int id)
        {
            return View(_iFExam.ReadExamForTakeExam(id));
        }

        [HttpPost]
        public JsonResult Percentage(int id)
        {
            return Json(_iFExaminee.Percentage(id));
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFExaminee.Read());
        }

        [HttpGet]
        public ActionResult TakenExam(int id)
        {
            return View(id);
        }

        [HttpPost]
        public JsonResult FilteredRead(ExamineeFilter examineeFilter)
         {
            return Json(_iFExaminee.Read(examineeFilter));
        }
    #endregion

        #region Update
    [HttpPost]
        public JsonResult Update(Examinee Examinee)
        {
            return Json(_iFExaminee.Update(Examinee));
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFExaminee.Delete(id);
            return Json(string.Empty);
        }
        #endregion


    

        

    }
}