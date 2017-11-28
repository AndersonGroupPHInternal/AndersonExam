using AccountsWebAuthentication.Controllers;
using AccountsWebAuthentication.Helper;
using System.Web.Mvc;

namespace AndersonExamWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "ExamManager" })]
    public class BaseController : BaseAccountsController
    {
    }
}   