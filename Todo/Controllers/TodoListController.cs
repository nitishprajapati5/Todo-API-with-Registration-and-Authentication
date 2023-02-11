using APIServices.Interfaces;
using APIServices.Models.Request;
using APIServices.Models.Response;
using APIServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    [ApiController]
    [Route("TodoList")]
    public class TodoListController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StaticService _staticService;

        public TodoListController(IDataService dataService, IHttpContextAccessor httpContextAccessor, StaticService staticService)
        {
            _dataService = dataService;
            _httpContextAccessor = httpContextAccessor;
            _staticService = staticService;
        }

        [HttpPost]
        [Route("PostList")]
        public async Task<ResJsonOutput> PostList([FromBody] TodoList list)
        {
            ResJsonOutput res = new ResJsonOutput();
            try
            {
                List<TodoListResponse> listResponses = new List<TodoListResponse>();
                string SpName = "PostList";
                listResponses = (await _staticService.ExecuteSP<TodoListResponse, TodoList>(SpName,list)).ToList();
            }
            catch(Exception)
            {

            }
            return res;
        }
    }
}
