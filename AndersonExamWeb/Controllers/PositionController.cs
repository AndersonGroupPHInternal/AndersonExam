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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFPosition.Read());
        }

        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFPosition.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Position position)
        {
            return View(_iFPosition.Update(position));
        }
        #endregion

        #region Delete
        #endregion

    }
}