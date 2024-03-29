﻿using LoanService.Application.Loan.Queries.Common.Dtos;
using LoanService.Application.Loan.Queries.Common.Mappings;

namespace LoanService.Application.Loan.Queries.GetActiveLoanRequests;

public class GetActiveLoanRequestsQueryResponse
{
    public GetActiveLoanRequestsQueryResponse(List<Core.Loan.LoanRequest> loanRequests)
    {
        if (loanRequests is not null)
        {
            LoanRequests = loanRequests
                .Select(LoanRequestMap.MapLoanRequestEntityToLoanRequestDto)
                .ToArray();
        }
    }

    public LoanRequest[] LoanRequests { get; set; } = Array.Empty<LoanRequest>();
}
