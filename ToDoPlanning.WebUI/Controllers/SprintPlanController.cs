using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Business.Abstract;
using ToDoPlanning.WebUI.Helper;

namespace ToDoPlanning.WebUI.Controllers
{
    public class SprintPlanController : Controller
    {
        private readonly IWorkTaskBusiness _business;

        public SprintPlanController(IWorkTaskBusiness workTaskBusiness)
        {
            _business = workTaskBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var taskList = await _business.GetAll();
            TempData["Week"] = taskList.GetTotalWeek();
            TempData["Hour"] = taskList.GetTotalWeek() * 45;

            return View(SprintPlan.GetSprintPlan(taskList.ToList()));
        }
    }
}