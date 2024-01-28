using MediatR;

namespace LoanService.Application.Loan.Queries.GetActiveLoanRequests;

public record GetActiveLoanRequestsQuery
    : IRequest<GetActiveLoanRequestsQueryResponse>
{ }
