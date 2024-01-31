using MediatR;

namespace LoanService.Application.Loan.Queries.GetUserActiveLoans;

public record GetUserActiveLoansQuery(Guid UserId)
    : IRequest<GetUserActiveLoansQueryResponse>
{ }
