using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Core.Helper;

namespace ToDoPlanning.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderOneController : ControllerBase
    {
        [HttpGet(Name = "ProviderOne")]
        public string ProviderOne()
        {
            return CreateTaskList.GetTaskList1().ToString();
        }
    }
}
