using HRMS.HRMS.Application.Adminstrator.Commands;
using HRMS.HRMS.Application.Adminstrator.Queries;
using HRMS.HRMS.Application.Adminstrator.Response;
using HRMS.HRMS.Presentation.WebApi.Contracts.NewUserAccount;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.HRMS.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminstratorController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AdminstratorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("create-user")]
        public async Task<IActionResult> NewUserAccount(NewUserAccountRequest request)
        {
            var command = _mapper.Map<NewUserAccountCommand>(request);
            var result = await _mediator.Send(command);

            var response = _mapper.Map<NewUserAccountResponse>(result);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
           
            var query = _mapper.Map<GetUserQueryHandler>("");
            var result = await _mediator.Send(query);
            var response = _mapper.Map<GetUserListResults>(result);
            return Ok(response);
        }
    }
}
