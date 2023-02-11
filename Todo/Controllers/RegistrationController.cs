using APIServices.Interfaces;
using APIServices.Models;
using APIServices.Models.Response;
using APIServices.Services;
using APIServices.Utils;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("Registration")]
    public class RegistrationController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StaticService _staticService;

        public RegistrationController(IDataService dataService,IHttpContextAccessor httpContextAccessor,StaticService staticService)
        {
            _dataService = dataService;
            _httpContextAccessor = httpContextAccessor;
            _staticService = staticService;
        }

        [Route("GetRegistrationDetails")]
        [HttpPost]
        public async Task<ResJsonOutput> GetRegistrationDetails([FromBody]Registration registration)
        {
            ResJsonOutput res = new ResJsonOutput();
            try
            {

                RegistrationResponse response = new RegistrationResponse();
                Registration resgistrationParam = new Registration();
                resgistrationParam = registration;
                //Check Email If Already Register


                Registration reg = await _staticService.ServiceRepository<Registration>().GetSingle(o => o.Email == registration.Email);

                if(reg != null)
                {
                    res.data = reg;
                    res.Status.IsSuccess = true;
                    res.Status.Message = ResponseMessages.EmailAlreadyExist;
                    res.Status.ResponseCode = Conflict().StatusCode.ToString();

                    return res;
                }


                resgistrationParam.Username = registration.Email;
                string spName = ProcedureConstants.GetRegistrationDetails;
                response = (await _staticService.ExecuteSP<RegistrationResponse, Registration>(spName, resgistrationParam)).FirstOrDefault();

                //Mail Triggering
                if(response != null)
                {

                }


                res.Status.IsSuccess = true;
                res.Status.Message = ResponseMessages.Successfully;
                res.Status.ResponseCode = Ok().StatusCode.ToString();
                res.data = response;
            }
            catch(Exception ex)
            {
                res.data = "";
                res.Status.IsSuccess = false;
                res.Status.Message = ex.Message;
                res.Status.ResponseCode = BadRequest().StatusCode.ToString();
            }

            return res;
        } 

    }
}
