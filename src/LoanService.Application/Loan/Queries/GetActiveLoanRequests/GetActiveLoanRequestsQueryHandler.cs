using Ardalis.Specification;

using LoanService.Core.Loan;
using LoanService.Core.Loan.Specifications;

using MediatR;

namespace LoanService.Application.Loan.Queries.GetActiveLoanRequests;

public class GetActiveLoanRequestsQueryHandler
    : IRequestHandler<GetActiveLoanRequestsQuery, GetActiveLoanRequestsQueryResponse>
{
    private readonly IReadRepositoryBase<LoanRequest> _loanReadRepository;

    public GetActiveLoanRequestsQueryHandler(
        IReadRepositoryBase<LoanRequest> loanReadRepository)
    {
        _loanReadRepository = loanReadRepository;
    }

    public async Task<GetActiveLoanRequestsQueryResponse> Handle(
        GetActiveLoanRequestsQuery query,
        CancellationToken cancellationToken)
    {
        var activeLoanRequests = await _loanReadRepository
            .ListAsync(new GetActiveLoanRequestsSpec(),
            cancellationToken);

        var activeLoansResponse =
            new GetActiveLoanRequestsQueryResponse(activeLoanRequests);

        return activeLoansResponse;
    }
}
