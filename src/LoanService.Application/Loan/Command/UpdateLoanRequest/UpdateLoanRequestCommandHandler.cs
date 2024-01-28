using Ardalis.Specification;

using LoanService.Application.Loan.Command.ChangeLoanRequestStatus;
using LoanService.Application.Loan.Command.CreateLoanRequest;
using LoanService.Core.Loan;
using LoanService.Core.User;

using MediatR;

namespace LoanService.Application.Loan.Command.UpdateLoanRequest;

public class UpdateLoanRequestCommandHandler
    : IRequestHandler<UpdateLoanRequestCommand, Unit>
{
    private readonly IRepositoryBase<LoanRequest> _loanRepository;
    private readonly IReadRepositoryBase<UserEntity> _userReadRepository;

    public UpdateLoanRequestCommandHandler(IRepositoryBase<LoanRequest> loanRepository,
        IReadRepositoryBase<UserEntity> userReadRepository)
    {
        _loanRepository = loanRepository;
        _userReadRepository = userReadRepository;
    }

    public async Task<Unit> Handle(UpdateLoanRequestCommand request, CancellationToken cancellationToken)
    {
        var loanRequest = await _loanRepository.GetByIdAsync(
            request.LoanRequestId,
            cancellationToken);

        if (loanRequest is null)
        {
            throw new LoanRequestNotFoundException($"loan request does not exist with id: {request.LoanRequestId}");
        }

        var user = await _userReadRepository.GetByIdAsync(
            request.UserId,
            cancellationToken);

        if (user is null)
        {
            throw new UserDoesNotExistException($"user does not exist with id: {request.UserId}");
        }

        loanRequest.Type = request.Type;
        loanRequest.RequestedAmount = request.RequestedAmount;
        loanRequest.Currency = request.Currency;
        loanRequest.LoanPeriod = request.LoanPeriod;

        await _loanRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

