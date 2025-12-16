using App.Service.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpPost("register")]
    //public async Task<IActionResult> RegisterDoctor([FromBody] DoctorInputDto model)
    //{
    //    var command = new DoctorRegisterCommand(model);
    //    var result = await _mediator.Send(command);
    //    return Ok(result);
    //}

}
