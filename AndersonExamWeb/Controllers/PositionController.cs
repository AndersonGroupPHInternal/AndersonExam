using AndersonExamFunction;
using AndersonExamModel;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class PositionController : Controller
    {
        private IFPosition _iFPosition;
        public PositionController(IFPosition iFPosition)
        {
            _iFPosition = iFPosition;
        }

        //#region Create
        //[HttpPut]
        //public JsonResult Create(Position position)
        //{
        //    _iFPosition.Create(position);
        //    return Json(string.Empty);
        //}

        //#endregion

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Position());
        }

        [HttpPost]
        public ActionResult Create(Position position)
        {
            position = _iFPosition.Create(position);
            return RedirectToAction("Update", new { id = position.PositionId });
        }
        #endregion

        #region Read
        [HttpPost]
        public JsonResult Read(int id)
        {
            return Json(_iFPosition.Read());
        }
        #endregion

        #region Update
        [HttpPost]
        public JsonResult Update(Position position)
        {
            return Json(_iFPosition.Update(position));
        }
        #endregion

        #region Delete
        #endregion

    }
}