using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Business.Abstract;
using ToDoPlanning.Core.Helper;
using ToDoPlanning.Entities.Concrete;

namespace ToDoPlanning.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IWorkTaskBusiness _business;

        public ProviderController(IWorkTaskBusiness workTaskBusiness)
        {
            _business = workTaskBusiness;
        }

        [HttpGet(Name = "Provider")]
        public bool Provider()
        {
            var api1Task = AppExtensions.CallApi(Constants.ProviderOne).Select(x => new WorkTask
            {
                Duration = x.GetIntField(Constants.sure),
                Level = x.GetIntField(Constants.zorluk),
                Name = x.GetStringField(Constants.id)
            }).ToList();

            var api2Task = AppExtensions.CallApi(Constants.ProviderTwo).Select(x => new WorkTask
            {
                Duration = x.GetSelectTokenInt(Constants.estimated_duration),
                Level = x.GetSelectTokenInt(Constants.level),
                Name = x.GetFirstFieldName()
            }).ToList();

            foreach (var item in api1Task.Concat(api2Task).ToList())
            {
                item.CreateHelper();
                _business.Create(item);
            }

            return true;
        }
    }
}