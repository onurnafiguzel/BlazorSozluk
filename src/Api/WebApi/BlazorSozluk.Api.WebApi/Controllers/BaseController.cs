using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorSozluk.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    public Guid? UserId => new(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>();

}
