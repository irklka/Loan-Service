using LoanService.Application.Loan.Command.ChangeLoanRequestStatus;
using LoanService.Application.Loan.Command.CreateLoanRequest;
using LoanService.Application.Loan.Command.UpdateLoanRequest;
using LoanService.Application.Loan.Queries.GetActiveLoanRequests;
using LoanService.Application.Loan.Queries.GetLoanRequests;
using LoanService.Application.Loan.Queries.GetUserActiveLoans;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.Api.Controllers;

[Authorize]
[Route("api/loans")]
public class LoanController : ApiControllerBase
{
    [HttpPost]
    public async Task<IResult> CreateLoanRequest(CreateLoanRequestCommand command,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }

    [HttpPut("status")]
    public async Task<IResult> ChangeLoanRequestStatus(ChangeLoanRequestStatusCommand command,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }

    [HttpPut]
    public async Task<IResult> UpdateLoanRequest(UpdateLoanRequestCommand command,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }

    [HttpGet("active")]
    public async Task<IResult> GetActiveLoans(CancellationToken cancellationToken)
    {
        var query = new GetActiveLoanRequestsQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return Results.Ok(response);
    }

    [HttpGet("{id:guid}/active")]
    public async Task<IResult> GetUserActriveLoans(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserActiveLoansQuery(id);
        var response = await Mediator.Send(query, cancellationToken);
        return Results.Ok(response);
    }

    [HttpGet]
    public async Task<IResult> GetLoans(CancellationToken cancellationToken)
    {
        var query = new GetLoanRequestsQuery();
        var response = await Mediator.Send(query, cancellationToken);
        return Results.Ok(response);
    }
}
