using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.WebUI.Helper;

namespace ToDoPlanning.WebUI.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View(AppExtensions.CallCoreApi());
        }
    }
}
