using Ardalis.Specification;

namespace LoanService.Core.Loan.Specifications;

public class GetActiveLoanRequestsSpec : Specification<LoanRequest>
{
    public GetActiveLoanRequestsSpec()
    {
        Query
            .AsNoTracking()
            .Where(x =>
                x.Status != LoanStatus.Rejected
                && x.Status != LoanStatus.Approved);
    }
}
