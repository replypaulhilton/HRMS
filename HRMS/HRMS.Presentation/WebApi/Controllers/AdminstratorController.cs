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
            var command = _mapper.Map<NewCustomerAccountCommand>(request);
            var authResult = await _mediator.Send(command);

            var response = _mapper.Map<NewUserAccountResponse>(authResult);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
           
            var request = new GetAccountsRequest(UserId);

            var query = _mapper.Map<GetAccountsQuery>(request);
            var authResult = await _mediator.Send(query);

            var response = _mapper.Map<GetAccountsResponse>(authResult);

            return Ok(response);
        }
    }
}
