using LoanService.Application.User.Commands.Login;
using LoanService.Application.User.Commands.Register;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Api.Controllers;

[Route("api/users")]
public class UserController : ApiControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IResult> Login(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var accessToken = await Mediator.Send(command, cancellationToken);
        return Results.Ok(accessToken);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IResult> CreateUser(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var accessToken = await Mediator.Send(command, cancellationToken);
        return Results.Ok(accessToken);
    }
}
