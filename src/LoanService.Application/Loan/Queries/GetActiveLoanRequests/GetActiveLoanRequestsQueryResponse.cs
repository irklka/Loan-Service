using LoanService.Core.Loan;

namespace LoanService.Application.Loan.Queries.GetActiveLoanRequests;

public class GetActiveLoanRequestsQueryResponse
{
    public GetActiveLoanRequestsQueryResponse(List<LoanRequest> loanRequests)
    {
        if (loanRequests is not null)
        {
            LoanRequests = loanRequests
                .Select(MapToDto)
                .ToArray();
        }
    }

    public LoanRequestDto[] LoanRequests { get; set; } = Array.Empty<LoanRequestDto>();

    private static LoanRequestDto MapToDto(LoanRequest loanRequest)
    {
        return new LoanRequestDto
        {
            Id = loanRequest.Id,
            Type = loanRequest.Type,
            RequestedAmount = loanRequest.RequestedAmount,
            Currency = loanRequest.Currency,
            LoanPeriod = loanRequest.LoanPeriod,
            Status = loanRequest.Status,
            UserId = loanRequest.UserId,
            LoanOfficerId = loanRequest.LoanOfficerId.GetValueOrDefault()
        };
    }
}

public class LoanRequestDto
{
    public Guid Id { get; set; } = Guid.Empty;
    public LoanType Type { get; set; } = default!;
    public decimal RequestedAmount { get; set; } = default!;
    public CurrencyCode Currency { get; set; } = default!;
    public int LoanPeriod { get; set; } = default!; // months 
    public LoanStatus Status { get; set; } = default!;
    public Guid UserId { get; set; } = Guid.Empty!;
    public Guid LoanOfficerId { get; set; } = Guid.Empty!;
}
