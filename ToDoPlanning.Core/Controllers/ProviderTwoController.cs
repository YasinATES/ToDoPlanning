using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Core.Helper;

namespace ToDoPlanning.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderTwoController : ControllerBase
    {
        [HttpGet(Name = "ProviderTwo")]
        public string ProviderTwo()
        {
            return CreateTaskList.GetTaskList2().ToString();
        }
    }
}
