using AccountsWebAuthentication.Helper;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "ExamDeveloper" })]
    public class BaseController : Controller
    {
    }
}   