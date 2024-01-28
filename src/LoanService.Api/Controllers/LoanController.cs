using LoanService.Application.Loan.Command.ChangeLoanRequestStatus;
using LoanService.Application.Loan.Command.CreateLoanRequest;
using LoanService.Application.Loan.Command.UpdateLoanRequest;
using LoanService.Application.Loan.Queries.GetActiveLoanRequests;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Api.Controllers;

[Route("api/loans")]
public class LoanController : ApiControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IResult> CreateLoanRequest(CreateLoanRequestCommand command,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }

    [HttpPost("status")]
    [Authorize]
    public async Task<IResult> ChangeLoanRequestStatus(ChangeLoanRequestStatusCommand command,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }

    [HttpPut]
    [Authorize]
    public async Task<IResult> UpdateLoanRequest(UpdateLoanRequestCommand command,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }

    [HttpGet]
    [Authorize]
    public async Task<IResult> GetActiveLoans(CancellationToken cancellationToken)
    {
        var query = new GetActiveLoanRequestsQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return Results.Ok(response);
    }
}
