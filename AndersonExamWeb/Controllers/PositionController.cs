using AccountsWebAuthentication.Helper;
using AndersonExamFunction;
using AndersonExamModel;
using System.Linq;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    public class PositionController : BaseController
    {
        private IFExamPosition _iFExamPosition;
        private IFPosition _iFPosition;
        public PositionController(IFExamPosition iFExamPosition, IFPosition iFPosition)
        {
            _iFExamPosition = iFExamPosition;
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
            var positionCreated = _iFPosition.Create(position);
            _iFExamPosition.Create(positionCreated.PositionId, position.ExamPositions.ToList());
            return RedirectToAction("Update", new { id = positionCreated.PositionId });
        }
        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(AllowedRoles = new string[0])]
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
            _iFExamPosition.Delete(position.PositionId);
            _iFExamPosition.Create(position.PositionId, position.ExamPositions.ToList());
            _iFPosition.Update(position);
            return RedirectToAction("Update", new { id = position.PositionId }); //Nagiging post ung refresh pag ung code kanina
        }
        #endregion

        #region Delete
        #endregion

    }
}